/*
This code was generated by a tool. DO NOT MODIFY this code manually, unless you really know what you are doing.
 */
using System;
				
namespace IFC4
{
	/// <summary>
	/// http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/ifcstructuralconnectioncondition.htm
	/// </summary>
	internal abstract partial class StructuralConnectionCondition : Entity 
	{
		public String Name {get;set;}

		public StructuralConnectionCondition(String name) : base()
		{
			this.Name = name;
		}
	}
}