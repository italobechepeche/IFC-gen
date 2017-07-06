/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public class ReinforcingMesh : ReinforcingElement 
	{
		public Double MeshLength {get;set;}

		public Double MeshWidth {get;set;}

		public Double LongitudinalBarNominalDiameter {get;set;}

		public Double TransverseBarNominalDiameter {get;set;}

		public Double LongitudinalBarCrossSectionArea {get;set;}

		public Double TransverseBarCrossSectionArea {get;set;}

		public Double LongitudinalBarSpacing {get;set;}

		public Double TransverseBarSpacing {get;set;}

		public ReinforcingMeshTypeEnum PredefinedType {get;set;}

		public ReinforcingMesh(Double meshLength,
				Boolean meshLengthSpecified,
				Double meshWidth,
				Boolean meshWidthSpecified,
				Double longitudinalBarNominalDiameter,
				Boolean longitudinalBarNominalDiameterSpecified,
				Double transverseBarNominalDiameter,
				Boolean transverseBarNominalDiameterSpecified,
				Double longitudinalBarCrossSectionArea,
				Boolean longitudinalBarCrossSectionAreaSpecified,
				Double transverseBarCrossSectionArea,
				Boolean transverseBarCrossSectionAreaSpecified,
				Double longitudinalBarSpacing,
				Boolean longitudinalBarSpacingSpecified,
				Double transverseBarSpacing,
				Boolean transverseBarSpacingSpecified,
				ReinforcingMeshTypeEnum predefinedType,
				Boolean predefinedTypeSpecified,
				String steelGrade,
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
				ObjectDefinitionIsDecomposedBy isDecomposedBy) : base(steelGrade,
				hasProjections,
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
			this.MeshLength = meshLength;
			this.MeshWidth = meshWidth;
			this.LongitudinalBarNominalDiameter = longitudinalBarNominalDiameter;
			this.TransverseBarNominalDiameter = transverseBarNominalDiameter;
			this.LongitudinalBarCrossSectionArea = longitudinalBarCrossSectionArea;
			this.TransverseBarCrossSectionArea = transverseBarCrossSectionArea;
			this.LongitudinalBarSpacing = longitudinalBarSpacing;
			this.TransverseBarSpacing = transverseBarSpacing;
			this.PredefinedType = predefinedType;
		}
	}
}