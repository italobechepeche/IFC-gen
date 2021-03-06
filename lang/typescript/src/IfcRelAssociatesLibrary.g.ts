
import {BaseIfc} from "./BaseIfc"
import {IfcGloballyUniqueId} from "./IfcGloballyUniqueId.g"
import {IfcOwnerHistory} from "./IfcOwnerHistory.g"
import {IfcLabel} from "./IfcLabel.g"
import {IfcText} from "./IfcText.g"
import {IfcObjectDefinition} from "./IfcObjectDefinition.g"
import {IfcPropertyDefinition} from "./IfcPropertyDefinition.g"
import {IfcLibraryInformation} from "./IfcLibraryInformation.g"
import {IfcLibraryReference} from "./IfcLibraryReference.g"
import {IfcRelAssociates} from "./IfcRelAssociates.g"

/**
 * http://www.buildingsmart-tech.org/ifc/IFC4/final/html/link/ifcrelassociateslibrary.htm
 */
export class IfcRelAssociatesLibrary extends IfcRelAssociates {
	RelatingLibrary : IfcLibraryInformation|IfcLibraryReference

    constructor(globalId : IfcGloballyUniqueId, relatedObjects : Array<IfcObjectDefinition|IfcPropertyDefinition>, relatingLibrary : IfcLibraryInformation|IfcLibraryReference) {
        super(globalId,relatedObjects)
		this.RelatingLibrary = relatingLibrary

    }
    getStepParameters() : string {
        var parameters = new Array<string>();
		parameters.push(BaseIfc.toStepValue(this.GlobalId))
		parameters.push(BaseIfc.toStepValue(this.OwnerHistory))
		parameters.push(BaseIfc.toStepValue(this.Name))
		parameters.push(BaseIfc.toStepValue(this.Description))
		parameters.push(BaseIfc.toStepValue(this.RelatedObjects))
		parameters.push(BaseIfc.toStepValue(this.RelatingLibrary))

        return parameters.join();
    }
}