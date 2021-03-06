

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using STEP;
	
namespace IFC
{
	/// <summary>
	/// <see href="http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/ifcstructuralsurfaceconnection.htm"/>
	/// </summary>
	public  partial class IfcStructuralSurfaceConnection : IfcStructuralConnection
	{


		/// <summary>
		/// Construct a IfcStructuralSurfaceConnection with all required attributes.
		/// </summary>
		public IfcStructuralSurfaceConnection(IfcGloballyUniqueId globalId):base(globalId)
		{


		}
		/// <summary>
		/// Construct a IfcStructuralSurfaceConnection with required and optional attributes.
		/// </summary>
		[JsonConstructor]
		public IfcStructuralSurfaceConnection(IfcGloballyUniqueId globalId,IfcOwnerHistory ownerHistory,IfcLabel name,IfcText description,IfcLabel objectType,IfcObjectPlacement objectPlacement,IfcProductRepresentation representation,IfcBoundaryCondition appliedCondition):base(globalId,ownerHistory,name,description,objectType,objectPlacement,representation,appliedCondition)
		{


		}
		public static new IfcStructuralSurfaceConnection FromJSON(string json){ return JsonConvert.DeserializeObject<IfcStructuralSurfaceConnection>(json); }

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
			parameters.Add(AppliedCondition != null ? AppliedCondition.ToStepValue() : "$");

            return string.Join(", ", parameters.ToArray());
        }
	}
}
