import SwaggerUI from "swagger-ui-react"
import "swagger-ui-react/swagger-ui.css"

function Openapi (){
    return (
    <>
     <SwaggerUI url="https://raw.githubusercontent.com/PedroMFC/TFM-DeepFakes/main/api/doc/openapi.yaml" />
     </>
  );

}
export default Openapi 