package routes

import (
	"api/cmd/restclient"
	"net/http"
	"strconv"
	"bytes"

	"encoding/json"
	"io/ioutil"
	"log"

	"github.com/gin-gonic/gin"
)

type applicationGin struct {
	Router *gin.Engine
}

func (a *applicationGin) Start() {
	
	http.ListenAndServe("0.0.0.0:8081", a.Router)
}

type Service struct{
	Service int `json:"servicio"`
}


type ImageInput struct{
	ImagePath string `json:"image_path"`
}


type VideoInput struct{
	VideoPath string `json:"video_path"`
	StartFrame int `json:"start_frame"`
	EndFrame int `json:"end_frame"`
	ModelPath string `json:"model_path"`
}


func NewAppGin(client restclient.HTTPClient) *applicationGin {
	router := gin.New()

	router.POST("/", DefineLogic(client))

	router.GET("/", func(c *gin.Context) {
		c.JSON(http.StatusOK, "OK")
	})

	return &applicationGin{Router: router}
}

func DefineLogic(client restclient.HTTPClient) gin.HandlerFunc{
	return func(c *gin.Context) {
		var service Service
		var request *http.Request
		var url string
		var jsonData []byte

		requestBody, _ := ioutil.ReadAll(c.Request.Body)
		json.Unmarshal([]byte(string(requestBody)), &service)

		switch service.Service {
		case 1: // Reverse Engineering GM
			var input ImageInput

			json.Unmarshal([]byte(string(requestBody)), &input)

			jsonData = []byte(`{
				"image_path":"` + input.ImagePath + `",
			}`)

			url = "https://reverse-utoehvsqvq-ew.a.run.app"

		case 2: // FaceForensics
			var input VideoInput

			json.Unmarshal([]byte(string(requestBody)), &input)

			log.Println(input.EndFrame)

			jsonData = []byte(`{
				"video_path":"` + input.VideoPath + `",
				"start_frame":`+ strconv.Itoa(input.StartFrame)  +`,
				"end_frame":`+ strconv.Itoa(input.EndFrame)  +`,
				"model_path":"` + input.ModelPath + `"
			}`)
			
			log.Println(string(jsonData))
			url = "https://faceforensics-utoehvsqvq-ew.a.run.app"
			//url = "http://localhost:8080"
		default:
			c.JSON(http.StatusBadRequest, "El servicio indicado no corresponde con ninguno almacenado")
			return
		}
		
		request, _ = http.NewRequest("POST", url, bytes.NewBuffer(jsonData))
		request.Header.Set("Content-Type", "application/json; charset=UTF-8")

		response, error := client.Do(request)
		if error != nil {
			panic(error)
		}
		defer response.Body.Close()

		log.Println("response Status:", response.Status)
		log.Println("response Headers:", response.Header)
		body, _ := ioutil.ReadAll(response.Body)
		log.Println("response Body:", string(body))
		c.JSON(response.StatusCode, string(body))
	}
}