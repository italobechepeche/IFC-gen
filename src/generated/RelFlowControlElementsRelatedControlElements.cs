/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public class RelFlowControlElementsRelatedControlElements : Object 
	{
		public DistributionControlElement[] Items {get;set;}

		public String[] itemType {get;set;}

		public aggregateType[] cType {get;set;}

		public String[] arraySize {get;set;}

		public RelFlowControlElementsRelatedControlElements(DistributionControlElement[] items,
				String[] itemType,
				aggregateType[] cType,
				String[] arraySize) : base()
		{
			this.Items = items;
			this.itemType = itemType;
			this.cType = cType;
			this.arraySize = arraySize;
		}
	}
}