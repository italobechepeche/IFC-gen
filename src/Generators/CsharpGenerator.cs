using Express;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFC4.Generators
{
    public class CsharpLanguageGenerator : ILanguageGenerator
    {

        public string Begin()
        {
            return
            @"/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using STEP;
	
namespace IFC4
{
	public abstract class BaseIfc : IConvertibleToSTEP
	{
		[JsonProperty(""id"")]
		public Guid Id{get;}

		public int StepId{get;set;}

		public BaseIfc()
		{
			Id = Guid.NewGuid();
		}

		public virtual string ToJSON()
		{
			var settings = new JsonSerializerSettings()
			{
				Formatting = Formatting.Indented,
				TypeNameHandling = TypeNameHandling.Objects
			};
			return JsonConvert.SerializeObject(this);
		}

		public virtual string ToSTEP()
		{
			string IfcClass = this.GetType().Name.ToUpper();
			return $""#{StepId} = {IfcClass}({this.GetStepParameters()});"";
		}

		public virtual string ToStepValue(bool isSelectOption = false)
		{
			return $""#{StepId}"";
		}

		public virtual string GetStepParameters()
		{
			return """";
		}
    }
    ";
        }

        public string End()
        {
            return "}";
        }

        public string Assignment(AttributeData data)
        {
            return $"\t\t\t{data.Name} = {data.ParameterName};\n";
        }

        public string Allocation(AttributeData data)
        {
            if (data.IsCollection)
            {
                return $"\t\t\t{data.Name} = new {data.Type}();\n";
            }
            return string.Empty;
        }

        public string AttributeDataType(bool isCollection, int rank, string type, bool isGeneric)
        {
            if (isCollection)
            {
                return $"{string.Join("", Enumerable.Repeat("List<", rank))}{type}{string.Join("", Enumerable.Repeat(">", rank))}";
            }

            // Item is used in functions.
            if(isGeneric)
            {
                return "T";
            }

            // https://github.com/ikeough/IFC-gen/issues/25
            if(type == "IfcSiUnitName")
            {
                return "IfcSIUnitName";
            }

            return type;
        }

        public string AttributeDataString(AttributeData data)
        {
            var prop = string.Empty;
            if(data.IsDerived)
            {
                var isNew = data.IsDerived && data.Name.Contains("SELF") ? "new " : string.Empty;
                var name = data.Name;
                if(name.Contains("SELF\\"))
                {
                    // This path points to a property in the inheritance chain.
                    name = name.Split(".").Last();
                }
                prop = $"\t\t{isNew}public {data.Type} {name}{{get{{throw new NotImplementedException(\"Derived property logic has been implemented for {name}.\");}}}} // derived\n";
            }
            else
            {   
                var tags = new List<string>();
                if(data.IsOptional) tags.Add("optional");
                if(data.IsInverse) tags.Add("inverse");
                var opt = data.IsOptional ? "optional" : string.Empty;
                var inverse = data.IsInverse ? "inverse" : string.Empty;
                prop = $"\t\tpublic {data.Type} {data.Name}{{get;set;}} {(tags.Any()? "// " + string.Join(",",tags) : string.Empty)}\n";
            }

            return prop;
        }

        public string AttributeStepString(AttributeData data)
        {
            var step = $"\t\t\tparameters.Add({data.Name} != null ? {data.Name}.ToStepValue() : \"$\");\n";

            // TODO: Not all enums are called xxxEnum. This emits code which causes 
            // 'never equal to null' errors. Find a better way to handle enums which don't
            // end in 'enum'.
            if (data.Type.EndsWith("Enum") | data.Type == "bool" | data.Type == "int" | data.Type == "double")
            {
                step = $"\t\t\tparameters.Add({data.Name}.ToStepValue());\n";
            }
            return step;
        }

        private string WrappedType(WrapperType data)
        {
            if (data.IsCollectionType)
            {
                return $"{string.Join("", Enumerable.Repeat("List<", data.Rank))}{data.WrappedType}{string.Join("", Enumerable.Repeat(">", data.Rank))}";
            }
            return data.WrappedType;
        }

        public string SimpleTypeString(WrapperType data)
        {
            var result =
    $@"	/// <summary>
	/// http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/{data.Name.ToLower()}.htm
	/// </summary>
	public class {data.Name} : BaseIfc
	{{
		internal {WrappedType(data)} value;

		public {data.Name}({WrappedType(data)} value){{ this.value = value; }}	
		public static implicit operator {WrappedType(data)}({data.Name} v){{ return v.value; }}
		public static implicit operator {data.Name}({WrappedType(data)} v){{ return new {data.Name}(v); }}	
		public static {data.Name} FromJSON(string json){{ return JsonConvert.DeserializeObject<{data.Name}>(json); }}
        public override string ToString(){{ return value.ToString(); }}
		public override string ToStepValue(bool isSelectOption = false){{
			if(isSelectOption){{ return $""{{GetType().Name.ToUpper()}}({{value.ToStepValue(isSelectOption)}})""; }}
			else{{ return value.ToStepValue(isSelectOption); }}
        }}
	}}
";
            return result;
        }

        public string EnumTypeString(EnumType data)
        {
            var result =
    $@"	/// <summary>
    /// http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/{data.Name.ToLower()}.htm
    /// </summary>
    public enum {data.Name} {{{string.Join(",", data.Values)}}}
";
            return result;
        }

        public string SelectTypeString(SelectType data)
        {
            var subTypes = new StringBuilder();
            foreach(var value in data.Values)
            {
                // There is one select in IFC that 
                // has an option which is an enum, which
                // does not inherit from BaseIfc.
                if(value == "IfcNullStyle")
                {
                    continue;
                }

                var subType = 
    $@"
    public class {data.Name}{value} : {data.Name}
    {{
        private readonly {value} value;
        public {data.Name}{value}({value} value) : base({data.Name}Type.{value}){{ this.value = value; }}
        public override string ToStepValue(bool isSelectOption = false){{ return value.ToStepValue(isSelectOption); }}
        public override string ToSTEP(){{ return $""#{{value.StepId}} = {{value.GetType().Name.ToUpper()}}({{value.GetStepParameters()}});""; }}
    }}";
                subTypes.AppendLine(subType);
            }

            var constructors = new StringBuilder();
            foreach (var value in data.Values)
            {
                constructors.AppendLine($"\t\tpublic {data.Name}({value} value):base(value){{}}");
            }
            var result =
    $@"	
    public enum {data.Name}Type{{ {string.Join(",", data.Values)} }}
    
    /// <summary>
	/// http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/{data.Name.ToLower()}.htm
	/// </summary>
	public abstract class {data.Name} : BaseIfc
    {{
        private readonly {data.Name}Type selectType;
        public {data.Name}({data.Name}Type selectType){{ this.selectType = selectType; }}
        public static {data.Name} FromJSON(string json){{ return JsonConvert.DeserializeObject<{data.Name}>(json); }}
    }}
{subTypes}
";
            return result;
        }

        public string EntityConstructorParams(Entity data, bool includeOptional)
        {
            // Constructor parameters include the union of this type's attributes and all super type attributes.
            // A constructor parameter is created for every attribute which does not derive
            // from IFCRelationship.

            var parents = data.ParentsAndSelf().Reverse();
            var attrs = parents.SelectMany(p => p.Attributes);

            if (!attrs.Any())
            {
                return string.Empty;
            }

            var validAttrs = includeOptional ? AttributesWithOptional(attrs) : AttributesWithoutOptional(attrs);

            return string.Join(",", validAttrs.Select(a => $"{a.Type} {a.ParameterName}"));
        }

        public string EntityBaseConstructorParams(Entity data, bool includeOptional)
        {
            // Base constructor parameters include the union of all super type attributes.
            var parents = data.Parents().Reverse();

            var attrs = parents.SelectMany(p => p.Attributes);

            if (!attrs.Any())
            {
                return string.Empty;
            }

            var validAttrs = includeOptional ? AttributesWithOptional(attrs) : AttributesWithoutOptional(attrs);

            return string.Join(",", validAttrs.Select(a => $"{a.ParameterName}"));
        }

        public string EntityString(Entity data)
        {
            var super = "BaseIfc";
            var newMod = string.Empty;
            if (data.Subs.Any())
            {
                super = data.Subs[0].Name; ;
                newMod = "new";
            }

            var modifier = data.IsAbstract ? "abstract" : string.Empty;

            // Create two constructors, one which includes optional parameters and 
            // one which does not. We need to check whether any of the parent types
            // have optional attributes as well, to avoid the case where the current type
            // doesn't have optional parameters, but a base type does.
            string constructors;
            if (data.ParentsAndSelf().SelectMany(e => e.Attributes.Where(a => a.IsOptional)).Any())
            {
                constructors = $@"
		/// <summary>
		/// Construct a {data.Name} with all required attributes.
		/// </summary>
		public {data.Name}({ConstructorParams(data, false)}):base({BaseConstructorParams(data, false)})
		{{
{Allocations(data, true)}
{Assignments(data, false)}
		}}
		/// <summary>
		/// Construct a {data.Name} with required and optional attributes.
		/// </summary>
		[JsonConstructor]
		public {data.Name}({ConstructorParams(data, true)}):base({BaseConstructorParams(data, true)})
		{{
{Allocations(data, false)}
{Assignments(data, true)}
		}}";
            }
            else
            {
                constructors = $@"
		/// <summary>
		/// Construct a {data.Name} with all required attributes.
		/// </summary>
		[JsonConstructor]
		public {data.Name}({ConstructorParams(data, false)}):base({BaseConstructorParams(data, false)})
		{{
{Allocations(data, true)}
{Assignments(data, false)}
		}}";
            }

            var classStr =
$@"
	/// <summary>
	/// <see href=""http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/{data.Name.ToLower()}.htm""/>
	/// </summary>
	public {modifier} partial class {data.Name} : {super}
	{{{data.Properties()}{constructors}
		public static {newMod} {data.Name} FromJSON(string json)
		{{
			return JsonConvert.DeserializeObject<{data.Name}>(json);
		}}

		public override string GetStepParameters()
		{{
			var parameters = new List<string>();
            string baseStepParameters = base.GetStepParameters();
            if (!string.IsNullOrEmpty(baseStepParameters)) {{ parameters.Add(baseStepParameters);}}
			{data.StepProperties()}
			return string.Join("", "", parameters.ToArray());
		}}
	}}";
            return classStr;
        }

        public string EntityTest(Entity data)
        {
            return string.Empty;
        }

        public string FileName
        {
            get { return "IFC.g.cs"; }
        }

        public string TestFileName
        {
            get { return "IFC.tests.g.cs"; }
        }

        public string ParseSimpleType(ExpressParser.SimpleTypeContext context)
        {
            var type = string.Empty;
            if (context.binaryType() != null)
            {
                type = "byte[]";
            }
            else if (context.booleanType() != null)
            {
                type = "bool";
            }
            else if (context.integerType() != null)
            {
                type = "int";
            }
            else if (context.logicalType() != null)
            {
                type = "bool?";
            }
            else if (context.numberType() != null)
            {
                type = "double";
            }
            else if (context.realType() != null)
            {
                type = "double";
            }
            else if (context.stringType() != null)
            {
                type = "string";
            }
            return type;
        }

        private string Assignments(Entity entity, bool includeOptional)
        {
            var attrs = includeOptional ? AttributesWithOptional(entity.Attributes) : AttributesWithoutOptional(entity.Attributes);
            if (!attrs.Any())
            {
                return string.Empty;
            }

            var assignBuilder = new StringBuilder();
            foreach (var a in attrs)
            {
                var assign = Assignment(a);
                if (!string.IsNullOrEmpty(assign))
                {
                    assignBuilder.Append(assign);
                }
            }
            return assignBuilder.ToString();
        }

        private string Allocations(Entity entity, bool includeOptional)
        {

            var allocBuilder = new StringBuilder();

            var attrs = entity.Attributes.Where(a => !a.IsDerived)
                                            .Where(a => a.IsInverse || includeOptional && a.IsOptional);

            foreach (var a in attrs)
            {
                var alloc = Allocation(a);
                if (!string.IsNullOrEmpty(alloc))
                {
                    allocBuilder.Append(alloc);
                }
            }
            return allocBuilder.ToString();
        }

        internal IEnumerable<AttributeData> AttributesWithOptional(IEnumerable<AttributeData> ad)
        {
            return ad.Where(a => !a.IsInverse)
                        .Where(a => !a.IsDerived);
        }

        internal IEnumerable<AttributeData> AttributesWithoutOptional(IEnumerable<AttributeData> ad)
        {
            return ad.Where(a => !a.IsInverse)
                        .Where(a => !a.IsDerived)
                        .Where(a => !a.IsOptional);
        }

        /// <summary>
        /// Return a set of constructor parameters in the form 'Type name1, Type name2'
        /// </summary>
        /// <returns></returns>
        private string ConstructorParams(Entity data, bool includeOptional)
        {
            return EntityConstructorParams(data, includeOptional);
        }

        /// <summary>
        /// Return a set of constructor params in the form `name1, name2`.
        /// </summary>
        /// <returns></returns>
        private string BaseConstructorParams(Entity data, bool includeOptional)
        {
            return EntityBaseConstructorParams(data, includeOptional);
        }
    }
}