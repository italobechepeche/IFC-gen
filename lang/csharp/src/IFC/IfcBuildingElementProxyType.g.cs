

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using STEP;
	
namespace IFC
{
	/// <summary>
	/// <see href="http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/ifcbuildingelementproxytype.htm"/>
	/// </summary>
	public  partial class IfcBuildingElementProxyType : IfcBuildingElementType
	{
		public IfcBuildingElementProxyTypeEnum PredefinedType{get;set;} 


		/// <summary>
		/// Construct a IfcBuildingElementProxyType with all required attributes.
		/// </summary>
		public IfcBuildingElementProxyType(IfcGloballyUniqueId globalId,IfcBuildingElementProxyTypeEnum predefinedType):base(globalId)
		{

			PredefinedType = predefinedType;

		}
		/// <summary>
		/// Construct a IfcBuildingElementProxyType with required and optional attributes.
		/// </summary>
		[JsonConstructor]
		public IfcBuildingElementProxyType(IfcGloballyUniqueId globalId,IfcOwnerHistory ownerHistory,IfcLabel name,IfcText description,IfcIdentifier applicableOccurrence,List<IfcPropertySetDefinition> hasPropertySets,List<IfcRepresentationMap> representationMaps,IfcLabel tag,IfcLabel elementType,IfcBuildingElementProxyTypeEnum predefinedType):base(globalId,ownerHistory,name,description,applicableOccurrence,hasPropertySets,representationMaps,tag,elementType)
		{

			PredefinedType = predefinedType;

		}
		public static new IfcBuildingElementProxyType FromJSON(string json){ return JsonConvert.DeserializeObject<IfcBuildingElementProxyType>(json); }

        public override string GetStepParameters()
        {
            var parameters = new List<string>();
			parameters.Add(GlobalId != null ? GlobalId.ToStepValue() : "$");
			parameters.Add(OwnerHistory != null ? OwnerHistory.ToStepValue() : "$");
			parameters.Add(Name != null ? Name.ToStepValue() : "$");
			parameters.Add(Description != null ? Description.ToStepValue() : "$");
			parameters.Add(ApplicableOccurrence != null ? ApplicableOccurrence.ToStepValue() : "$");
			parameters.Add(HasPropertySets != null ? HasPropertySets.ToStepValue() : "$");
			parameters.Add(RepresentationMaps != null ? RepresentationMaps.ToStepValue() : "$");
			parameters.Add(Tag != null ? Tag.ToStepValue() : "$");
			parameters.Add(ElementType != null ? ElementType.ToStepValue() : "$");
			parameters.Add(PredefinedType.ToStepValue());

            return string.Join(", ", parameters.ToArray());
        }
	}
}
