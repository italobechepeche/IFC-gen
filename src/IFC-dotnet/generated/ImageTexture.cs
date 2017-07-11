/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/ifcimagetexture.htm
	/// </summary>
	internal  partial class ImageTexture : SurfaceTexture 
	{
		public String URLReference {get;set;}

		public ImageTexture(String uRLReference,
				CartesianTransformationOperator2D textureTransform,
				Boolean repeatS,
				Boolean repeatT,
				String mode,
				String[] parameter) : base(textureTransform,
				repeatS,
				repeatT,
				mode,
				parameter)
		{
			this.URLReference = uRLReference;
		}
	}
}