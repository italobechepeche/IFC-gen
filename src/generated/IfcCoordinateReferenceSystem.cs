/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public partial class IfcCoordinateReferenceSystem : Entity 
	{
		public IfcCoordinateReferenceSystem(String name,
				String description,
				String geodeticDatum,
				String verticalDatum,
				String href,
				String reference,
				String id,
				String path,
				String[] pos) : base(href,
				reference,
				id,
				path,
				pos)
		{
			this.nameField = name;
			this.descriptionField = description;
			this.geodeticDatumField = geodeticDatum;
			this.verticalDatumField = verticalDatum;
		}
	}
}