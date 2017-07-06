/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public class StairFlight : BuildingElement 
	{
		public Int64 NumberOfRisers {get;set;}

		public Int64 NumberOfTreads {get;set;}

		public Double RiserHeight {get;set;}

		public Double TreadLength {get;set;}

		public StairFlightTypeEnum PredefinedType {get;set;}

		public StairFlight(Int64 numberOfRisers,
				Boolean numberOfRisersSpecified,
				Int64 numberOfTreads,
				Boolean numberOfTreadsSpecified,
				Double riserHeight,
				Boolean riserHeightSpecified,
				Double treadLength,
				Boolean treadLengthSpecified,
				StairFlightTypeEnum predefinedType,
				Boolean predefinedTypeSpecified,
				RelProjectsElement hasProjections,
				RelVoidsElement hasOpenings,
				String tag,
				ObjectPlacement objectPlacement,
				ProductRepresentation representation,
				RelDefinesByObject isDeclaredBy,
				RelDefinesByType isTypedBy,
				ObjectIsDefinedBy isDefinedBy,
				String objectType,
				ObjectDefinitionIsNestedBy isNestedBy,
				ObjectDefinitionIsDecomposedBy isDecomposedBy) : base(hasProjections,
				hasOpenings,
				tag,
				objectPlacement,
				representation,
				isDeclaredBy,
				isTypedBy,
				isDefinedBy,
				objectType,
				isNestedBy,
				isDecomposedBy)
		{
			this.NumberOfRisers = numberOfRisers;
			this.NumberOfTreads = numberOfTreads;
			this.RiserHeight = riserHeight;
			this.TreadLength = treadLength;
			this.PredefinedType = predefinedType;
		}
	}
}