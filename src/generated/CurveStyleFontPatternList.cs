/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public class CurveStyleFontPatternList : Object 
	{
		public CurveStyleFontPattern[] IfcCurveStyleFontPattern {get;set;}

		public String[] itemType {get;set;}

		public aggregateType[] cType {get;set;}

		public String[] arraySize {get;set;}

		public CurveStyleFontPatternList(CurveStyleFontPattern[] ifcCurveStyleFontPattern,
				String[] itemType,
				aggregateType[] cType,
				String[] arraySize) : base()
		{
			this.IfcCurveStyleFontPattern = ifcCurveStyleFontPattern;
			this.itemType = itemType;
			this.cType = cType;
			this.arraySize = arraySize;
		}
	}
}