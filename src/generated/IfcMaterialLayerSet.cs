/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public partial class IfcMaterialLayerSet : IfcMaterialDefinition 
	{
		public IfcMaterialLayerSet(IfcMaterialLayerSetMaterialLayers materialLayers,
				String layerSetName,
				String description,
				IfcMaterialDefinitionHasProperties hasProperties,
				String href,
				String reference,
				String id,
				String path,
				String[] pos) : base(hasProperties,
				href,
				reference,
				id,
				path,
				pos)
		{
			this.materialLayersField = materialLayers;
			this.layerSetNameField = layerSetName;
			this.descriptionField = description;
		}
	}
}