/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// 
	/// </summary>
	public partial class IfcWorkTime : IfcSchedulingTime 
	{
		public IfcWorkTime(IfcRecurrencePattern recurrencePattern,
				String start,
				String finish,
				String name,
				IfcDataOriginEnum dataOrigin,
				Boolean dataOriginSpecified,
				String userDefinedDataOrigin,
				String href,
				String reference,
				String id,
				String path,
				String[] pos) : base(name,
				dataOrigin,
				dataOriginSpecified,
				userDefinedDataOrigin,
				href,
				reference,
				id,
				path,
				pos)
		{
			this.recurrencePatternField = recurrencePattern;
			this.startField = start;
			this.finishField = finish;
		}
	}
}