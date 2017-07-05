/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public partial class IfcLightSourceSpot : IfcLightSourcePositional 
	{
		public IfcLightSourceSpot(IfcDirection orientation,
				Double concentrationExponent,
				Boolean concentrationExponentSpecified,
				Double spreadAngle,
				Boolean spreadAngleSpecified,
				Double beamWidthAngle,
				Boolean beamWidthAngleSpecified,
				IfcCartesianPoint position,
				Double radius,
				Boolean radiusSpecified,
				Double constantAttenuation,
				Boolean constantAttenuationSpecified,
				Double distanceAttenuation,
				Boolean distanceAttenuationSpecified,
				Double quadricAttenuation,
				Boolean quadricAttenuationSpecified,
				IfcColourRgb lightColour,
				String name,
				Double ambientIntensity,
				Boolean ambientIntensitySpecified,
				Double intensity,
				Boolean intensitySpecified,
				IfcStyledItem styledByItem,
				String href,
				String reference,
				String id,
				String path,
				String[] pos) : base(position,
				radius,
				radiusSpecified,
				constantAttenuation,
				constantAttenuationSpecified,
				distanceAttenuation,
				distanceAttenuationSpecified,
				quadricAttenuation,
				quadricAttenuationSpecified,
				lightColour,
				name,
				ambientIntensity,
				ambientIntensitySpecified,
				intensity,
				intensitySpecified,
				styledByItem,
				href,
				reference,
				id,
				path,
				pos)
		{
			this.orientationField = orientation;
			this.concentrationExponentField = concentrationExponent;
			this.concentrationExponentSpecifiedField = concentrationExponentSpecified;
			this.spreadAngleField = spreadAngle;
			this.spreadAngleSpecifiedField = spreadAngleSpecified;
			this.beamWidthAngleField = beamWidthAngle;
			this.beamWidthAngleSpecifiedField = beamWidthAngleSpecified;
		}
	}
}