

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using STEP;
	
namespace IFC
{
	/// <summary>
	/// <see href="http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/ifcstructuralsurfacereaction.htm"/>
	/// </summary>
	public  partial class IfcStructuralSurfaceReaction : IfcStructuralReaction
	{
		public IfcStructuralSurfaceActivityTypeEnum PredefinedType{get;set;} 


		/// <summary>
		/// Construct a IfcStructuralSurfaceReaction with all required attributes.
		/// </summary>
		public IfcStructuralSurfaceReaction(IfcGloballyUniqueId globalId,IfcStructuralLoad appliedLoad,IfcGlobalOrLocalEnum globalOrLocal,IfcStructuralSurfaceActivityTypeEnum predefinedType):base(globalId,appliedLoad,globalOrLocal)
		{

			PredefinedType = predefinedType;

		}
		/// <summary>
		/// Construct a IfcStructuralSurfaceReaction with required and optional attributes.
		/// </summary>
		[JsonConstructor]
		public IfcStructuralSurfaceReaction(IfcGloballyUniqueId globalId,IfcOwnerHistory ownerHistory,IfcLabel name,IfcText description,IfcLabel objectType,IfcObjectPlacement objectPlacement,IfcProductRepresentation representation,IfcStructuralLoad appliedLoad,IfcGlobalOrLocalEnum globalOrLocal,IfcStructuralSurfaceActivityTypeEnum predefinedType):base(globalId,ownerHistory,name,description,objectType,objectPlacement,representation,appliedLoad,globalOrLocal)
		{

			PredefinedType = predefinedType;

		}
		public static new IfcStructuralSurfaceReaction FromJSON(string json){ return JsonConvert.DeserializeObject<IfcStructuralSurfaceReaction>(json); }

        public override string GetStepParameters()
        {
            var parameters = new List<string>();
			parameters.Add(GlobalId != null ? GlobalId.ToStepValue() : "$");
			parameters.Add(OwnerHistory != null ? OwnerHistory.ToStepValue() : "$");
			parameters.Add(Name != null ? Name.ToStepValue() : "$");
			parameters.Add(Description != null ? Description.ToStepValue() : "$");
			parameters.Add(ObjectType != null ? ObjectType.ToStepValue() : "$");
			parameters.Add(ObjectPlacement != null ? ObjectPlacement.ToStepValue() : "$");
			parameters.Add(Representation != null ? Representation.ToStepValue() : "$");
			parameters.Add(AppliedLoad != null ? AppliedLoad.ToStepValue() : "$");
			parameters.Add(GlobalOrLocal.ToStepValue());
			parameters.Add(PredefinedType.ToStepValue());

            return string.Join(", ", parameters.ToArray());
        }
	}
}
