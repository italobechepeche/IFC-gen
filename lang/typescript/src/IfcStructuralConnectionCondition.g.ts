
import {BaseIfc} from "./BaseIfc"
import {IfcLabel} from "./IfcLabel.g"

/**
 * http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/ifcstructuralconnectioncondition.htm
 */
export abstract class IfcStructuralConnectionCondition extends BaseIfc {
	Name : IfcLabel // optional

    constructor() {
        super()
    }
}