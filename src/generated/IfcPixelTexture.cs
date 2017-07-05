/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public partial class IfcPixelTexture : IfcSurfaceTexture 
	{
		public IfcPixelTexture(Int64 width,
				Boolean widthSpecified,
				Int64 height,
				Boolean heightSpecified,
				Int64 colourComponents,
				Boolean colourComponentsSpecified,
				Byte[][] pixel,
				IfcCartesianTransformationOperator2D textureTransform,
				Boolean repeatS,
				Boolean repeatSSpecified,
				Boolean repeatT,
				Boolean repeatTSpecified,
				String mode,
				String[] parameter,
				String href,
				String reference,
				String id,
				String path,
				String[] pos) : base(textureTransform,
				repeatS,
				repeatSSpecified,
				repeatT,
				repeatTSpecified,
				mode,
				parameter,
				href,
				reference,
				id,
				path,
				pos)
		{
			this.widthField = width;
			this.widthSpecifiedField = widthSpecified;
			this.heightField = height;
			this.heightSpecifiedField = heightSpecified;
			this.colourComponentsField = colourComponents;
			this.colourComponentsSpecifiedField = colourComponentsSpecified;
			this.pixelField = pixel;
		}
	}
}