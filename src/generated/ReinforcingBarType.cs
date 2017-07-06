/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public class ReinforcingBarType : ReinforcingElementType 
	{
		public ReinforcingBarTypeBendingParameters BendingParameters {get;set;}

		public ReinforcingBarTypeEnum PredefinedType {get;set;}

		public Double NominalDiameter {get;set;}

		public Double CrossSectionArea {get;set;}

		public Double BarLength {get;set;}

		public ReinforcingBarSurfaceEnum BarSurface {get;set;}

		public String BendingShapeCode {get;set;}

		public ReinforcingBarType(ReinforcingBarTypeBendingParameters bendingParameters,
				ReinforcingBarTypeEnum predefinedType,
				Boolean predefinedTypeSpecified,
				Double nominalDiameter,
				Boolean nominalDiameterSpecified,
				Double crossSectionArea,
				Boolean crossSectionAreaSpecified,
				Double barLength,
				Boolean barLengthSpecified,
				ReinforcingBarSurfaceEnum barSurface,
				Boolean barSurfaceSpecified,
				String bendingShapeCode,
				String elementType,
				TypeProductRepresentationMaps representationMaps,
				String tag,
				TypeObjectHasPropertySets hasPropertySets,
				String applicableOccurrence,
				ObjectDefinitionIsNestedBy isNestedBy,
				ObjectDefinitionIsDecomposedBy isDecomposedBy) : base(elementType,
				representationMaps,
				tag,
				hasPropertySets,
				applicableOccurrence,
				isNestedBy,
				isDecomposedBy)
		{
			this.BendingParameters = bendingParameters;
			this.PredefinedType = predefinedType;
			this.NominalDiameter = nominalDiameter;
			this.CrossSectionArea = crossSectionArea;
			this.BarLength = barLength;
			this.BarSurface = barSurface;
			this.BendingShapeCode = bendingShapeCode;
		}
	}
}