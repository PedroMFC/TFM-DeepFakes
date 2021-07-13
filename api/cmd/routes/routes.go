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
	// "github.com/gin-contrib/cors"
)

type applicationGin struct {
	Router *gin.Engine
}

func (a *applicationGin) Start() {
	
	http.ListenAndServe("0.0.0.0:8081", a.Router)
}

type ImageInput struct{
	ImagePath string `json:"image_path"`
	ModelPath string `json:"model_path"`
}


type VideoInput struct{
	VideoPath string `json:"video_path"`
	StartFrame int `json:"start_frame"`
	EndFrame int `json:"end_frame"`
	ModelPath string `json:"model_path"`
	Full int `json:"full"`
}

type KerasIOInput struct{
	VideoPath string `json:"video_path"`
}

type ResultOut struct{
	Result []map[string]string `json:"result"`
}

func CORS(c *gin.Context) {

	// First, we add the headers with need to enable CORS
	// Make sure to adjust these headers to your needs
	c.Header("Access-Control-Allow-Origin", "*")
	c.Header("Access-Control-Allow-Methods", "*")
	c.Header("Access-Control-Allow-Headers", "*")
	c.Header("Content-Type", "application/json")

	// Second, we handle the OPTIONS problem
	if c.Request.Method != "OPTIONS" {
		
		c.Next()

	} else {
        
		// Everytime we receive an OPTIONS request, 
		// we just return an HTTP 200 Status Code
		c.AbortWithStatus(http.StatusOK)
	}
}

func NewAppGin(client restclient.HTTPClient) *applicationGin {
	router := gin.New()

	router.Use(CORS)

	router.POST("/faceforensics", FaceForensicsLogic(client))
	router.POST("/reverse", ReverseLogic(client))
	router.POST("/kerasio", KerasIOLogic(client))

	router.GET("/", func(c *gin.Context) {
		c.JSON(http.StatusOK, "OK")
	})

	return &applicationGin{Router: router}
}

func FaceForensicsLogic(client restclient.HTTPClient) gin.HandlerFunc{
	return func(c *gin.Context) {
		var request *http.Request
		var url string
		var jsonData []byte
		var input VideoInput

		requestBody, _ := ioutil.ReadAll(c.Request.Body)
		json.Unmarshal([]byte(string(requestBody)), &input)

		log.Println(input.EndFrame)

		if strconv.Itoa(input.StartFrame) < strconv.Itoa(input.EndFrame){
			jsonData = []byte(`{
				"video_path":"` + input.VideoPath + `",
				"start_frame":`+ strconv.Itoa(input.StartFrame)  +`,
				"end_frame":`+ strconv.Itoa(input.EndFrame)  +`,
				"model_path":"` + input.ModelPath + `",
				"full":`+ strconv.Itoa(input.Full)  +`
			}`)
		} else {
			jsonData = []byte(`{
				"video_path":"` + input.VideoPath + `",
				"model_path":"` + input.ModelPath + `",
				"full":`+ strconv.Itoa(input.Full)  +`
			}`)	
		}
			
		log.Println(string(jsonData))
		url = "https://faceforensics-utoehvsqvq-ew.a.run.app"
		//url = "http://localhost:8080"

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
		//log.Println("response Body:", string(body))

		var ResultJSON ResultOut

		json.Unmarshal([]byte(string(body)), &ResultJSON)
		log.Println(ResultJSON)
		c.JSON(response.StatusCode, gin.H{
			"result": ResultJSON.Result,
		})
	}
}

func KerasIOLogic(client restclient.HTTPClient) gin.HandlerFunc{
	return func(c *gin.Context) {
		var request *http.Request
		var url string
		var jsonData []byte
		var input KerasIOInput

		requestBody, _ := ioutil.ReadAll(c.Request.Body)

		json.Unmarshal([]byte(string(requestBody)), &input)

		jsonData = []byte(`{
			"video_path":"` + input.VideoPath + `"
		}`)
 
		log.Println(string(jsonData))
		url = "https://kerasio-utoehvsqvq-ew.a.run.app"
		//url = "http://localhost:8083"

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
		//log.Println("response Body:", string(body))

		var ResultJSON ResultOut

		json.Unmarshal([]byte(string(body)), &ResultJSON)
		log.Println(ResultJSON)
		c.JSON(response.StatusCode, gin.H{
			"result": ResultJSON.Result,
		})
	}
}


func ReverseLogic(client restclient.HTTPClient) gin.HandlerFunc{
	return func(c *gin.Context) {
		var request *http.Request
		var url string
		var jsonData []byte
		var input ImageInput

		requestBody, _ := ioutil.ReadAll(c.Request.Body)

		json.Unmarshal([]byte(string(requestBody)), &input)

		jsonData = []byte(`{
			"image_path":"` + input.ImagePath + `",
			"model_path":"`+ input.ModelPath  +`"
		}`)
 
		log.Println(string(jsonData))
		url = "https://reverse-utoehvsqvq-ew.a.run.app"
		//url = "http://localhost:8082"

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
		//log.Println("response Body:", string(body))

		var ResultJSON ResultOut

		json.Unmarshal([]byte(string(body)), &ResultJSON)
		log.Println(ResultJSON)
		c.JSON(response.StatusCode, gin.H{
			"result": ResultJSON.Result,
		})
	}
}