/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public class VirtualGridIntersection : Entity 
	{
		public VirtualGridIntersectionIntersectingAxes IntersectingAxes {get;set;}

		public Double[] OffsetDistances {get;set;}

		public VirtualGridIntersection(VirtualGridIntersectionIntersectingAxes intersectingAxes,
				Double[] offsetDistances) : base()
		{
			this.IntersectingAxes = intersectingAxes;
			this.OffsetDistances = offsetDistances;
		}
	}
}