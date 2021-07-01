package routes

import (
	"api/cmd/restclient"
	"net/http"
	//"strconv"
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
	Service int `json:"service"`
}


type ImageInput struct{
	ImagePath string `json:"image_path"`
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

		log.Println(service)

		if service.Service == 1{
			var input ImageInput

			json.Unmarshal([]byte(string(requestBody)), &input)

			jsonData = []byte(`{
				"image_path":"` + input.ImagePath + `",
				"job": "leader"
			}`)
			url = "https://reverse-utoehvsqvq-ew.a.run.app"
			
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
		c.JSON(http.StatusOK, string(body))
	}
}