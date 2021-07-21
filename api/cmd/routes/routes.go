package routes

import (
	"api/cmd/restclient"
	"api/cmd/requests"
	"net/http"
	"strconv"
	"bytes"

	"encoding/json"
	"io/ioutil"
	"log"

	"github.com/gin-gonic/gin"
	"github.com/gin-contrib/cors"
)


var RequestLogic = requests.RequestLogic

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


type KerasIOImgInput struct{
	ImagePath string `json:"image_path"`
	ModelPath string `json:"model_path"`
	ImageSize int `json:"image_size"`
	Lime int `json:"lime"`
}


type ResultOut struct{
	Result []map[string]string `json:"result"`
}

type ResultKerasImgOut struct{
	Result []map[string]string `json:"result"`
	File string `json:"file"`
}

type Error struct{
	Error string `json:"Error"`
}

type ResultCreated struct{
	Result string `json:"result"`
}

func NewAppGin(client restclient.HTTPClient) *applicationGin {
	router := gin.New()

	router.Use(cors.New(cors.Config{
		AllowOrigins:     []string{"*"},
		AllowMethods: []string{"POST"},
		AllowHeaders:    []string{"content-type"},
	}))

	router.POST("/faceforensics", FaceForensicsLogic(client))
	router.POST("/reverse", ReverseLogic(client))
	router.POST("/kerasio", KerasIOLogic(client))
	router.POST("/kerasioimg", KerasIOImgLogic(client))
	// router.GET("/requests/:user", getUser(client))
	// router.POST("/requests/:user", saveUser(client))

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

		
		//log.Println(c.Request.Header.Get("X-REAL-IP"))
		//log.Println(c.Request.RemoteAddr)

		//ip := "127.0.0.1:46344"
		ip := c.Request.RemoteAddr
		log.Println("IP: ", ip)
		pass := RequestLogic(ip, client)

		if pass < 0{
			c.JSON(http.StatusForbidden, gin.H{
				"Error": "Ha superado el máximo de intentos",
			})
		} else{
			
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

		if response.StatusCode == http.StatusOK {
			var ResultJSON ResultOut

			json.Unmarshal([]byte(string(body)), &ResultJSON)
			log.Println(ResultJSON)
			c.JSON(response.StatusCode, gin.H{
				"result": ResultJSON.Result,
			})
		} else {
			var ResultJSON Error

			json.Unmarshal([]byte(string(body)), &ResultJSON)
			log.Println(ResultJSON)
			c.JSON(response.StatusCode, gin.H{
				"Error": ResultJSON.Error,
			})
		}
	}
	}
}

func KerasIOLogic(client restclient.HTTPClient) gin.HandlerFunc{
	return func(c *gin.Context) {
		var request *http.Request
		var url string
		var jsonData []byte
		var input KerasIOInput

		ip := c.Request.RemoteAddr
		log.Println("IP: ", ip)
		pass := RequestLogic(ip, client)

		if pass < 0{
			c.JSON(http.StatusForbidden, gin.H{
				"Error": "Ha superado el máximo de intentos",
			})
		} else{

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

		if response.StatusCode == http.StatusOK {
			var ResultJSON ResultOut

			json.Unmarshal([]byte(string(body)), &ResultJSON)
			log.Println(ResultJSON)
			c.JSON(response.StatusCode, gin.H{
				"result": ResultJSON.Result,
			})
		} else {
			var ResultJSON Error

			json.Unmarshal([]byte(string(body)), &ResultJSON)
			log.Println(ResultJSON)
			c.JSON(response.StatusCode, gin.H{
				"Error": ResultJSON.Error,
			})
		}
	}
	}
}


func KerasIOImgLogic(client restclient.HTTPClient) gin.HandlerFunc{
	return func(c *gin.Context) {
		var request *http.Request
		var url string
		var jsonData []byte
		var input KerasIOImgInput
		ip := c.Request.RemoteAddr
		log.Println("IP: ", ip)
		pass := RequestLogic(ip, client)

		if pass < 0{
			c.JSON(http.StatusForbidden, gin.H{
				"Error": "Ha superado el máximo de intentos",
			})
		} else{

		requestBody, _ := ioutil.ReadAll(c.Request.Body)

		json.Unmarshal([]byte(string(requestBody)), &input)

		jsonData = []byte(`{
			"image_path":"` + input.ImagePath + `",
			"model_path":"`+ input.ModelPath  +`",
			"image_size":`+ strconv.Itoa(input.ImageSize)  +`,
			"lime":` + strconv.Itoa(input.Lime) + `
		}`)
 
		log.Println(string(jsonData))
		//url = "https://kerasioimg-utoehvsqvq-ew.a.run.app"
		url = "http://localhost:8085"

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

		if response.StatusCode == http.StatusOK {
			var ResultJSON ResultKerasImgOut

			json.Unmarshal([]byte(string(body)), &ResultJSON)
			log.Println(ResultJSON)
			c.JSON(response.StatusCode, gin.H{
				"result": ResultJSON.Result,
				"file": ResultJSON.File,
			})
		} else {
			var ResultJSON Error

			json.Unmarshal([]byte(string(body)), &ResultJSON)
			log.Println(ResultJSON)
			c.JSON(response.StatusCode, gin.H{
				"Error": ResultJSON.Error,
			})
		}
	}
	}
}


func ReverseLogic(client restclient.HTTPClient) gin.HandlerFunc{
	return func(c *gin.Context) {
		var request *http.Request
		var url string
		var jsonData []byte
		var input ImageInput

		ip := c.Request.RemoteAddr
		log.Println("IP: ", ip)
		pass := RequestLogic(ip, client)

		if pass < 0{
			c.JSON(http.StatusForbidden, gin.H{
				"Error": "Ha superado el máximo de intentos",
			})
		} else{

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

		if response.StatusCode == http.StatusOK {
			var ResultJSON ResultOut

			json.Unmarshal([]byte(string(body)), &ResultJSON)
			log.Println(ResultJSON)
			c.JSON(response.StatusCode, gin.H{
				"result": ResultJSON.Result,
			})
		} else {
			var ResultJSON Error

			json.Unmarshal([]byte(string(body)), &ResultJSON)
			log.Println(ResultJSON)
			c.JSON(response.StatusCode, gin.H{
				"Error": ResultJSON.Error,
			})
		}
	}
	}
}

