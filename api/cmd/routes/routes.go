package routes

import (
	"api/cmd/requests"
	"api/cmd/restclient"
	"bytes"
	//"io"
	"net/http"
	"strconv"

	"encoding/json"
	"io/ioutil"
	"log"

	"github.com/gin-contrib/cors"
	"github.com/gin-gonic/gin"
	"github.com/tomasen/realip"
)


var RequestLogic = requests.RequestLogic

/* ESTRUCTURAS DE LOS JSON*/

type applicationGin struct {
	Router *gin.Engine
}

func (a *applicationGin) Start() {
	
	http.ListenAndServe("0.0.0.0:8081", a.Router)
}

type ReuquestIP struct{
	IP string `json:"ip"`
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
	PerFake float32 `json:"perFake"` 
	PerReal float32 `json:"perReal"` 
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


/* LÓGICA DE LA API */

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

	router.GET("/", func(c *gin.Context) {
		c.JSON(http.StatusOK, "OK")
	})

	return &applicationGin{Router: router}
}

/* LÓGICA FACEFORENSICS */

func FaceForensicsLogic(client restclient.HTTPClient) gin.HandlerFunc{
	return func(c *gin.Context) {
		var request *http.Request
		var url string
		var jsonData []byte
		var input VideoInput

		log.Println("Llamada servicio FaceForensics")

		
		//log.Println(c.Request.Header.Get("X-REAL-IP"))
		//log.Println(c.Request.RemoteAddr)

		//ip := "127.0.0.1:46344"
		ip, requestBody := getIP(c.Request)
		pass := RequestLogic(ip, client)

		if pass < 0{
			log.Println("Se han sueperado el número máximo de intentos  para la IP: ", ip)
			c.JSON(http.StatusForbidden, gin.H{
				"Error": "Ha superado el máximo de intentos",
			})
		} else{
			
		json.Unmarshal([]byte(string(requestBody)), &input)

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
		body, _ := ioutil.ReadAll(response.Body)

		if response.StatusCode == http.StatusOK {
			var ResultJSON ResultOut

			json.Unmarshal([]byte(string(body)), &ResultJSON)
			log.Println(ResultJSON)
			c.JSON(response.StatusCode, gin.H{
				"result": ResultJSON.Result,
				"perFake": ResultJSON.PerFake,
				"perReal": ResultJSON.PerReal,
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

		log.Println("Llamada servicio Keras vídeos")

		ip, requestBody := getIP(c.Request)
		pass := RequestLogic(ip, client)

		if pass < 0{
			log.Println("Se han sueperado el número máximo de intentos  para la IP: ", ip)
			c.JSON(http.StatusForbidden, gin.H{
				"Error": "Ha superado el máximo de intentos",
			})
		} else{
			
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
		body, _ := ioutil.ReadAll(response.Body)
		//log.Println("response Body:", string(body))

		if response.StatusCode == http.StatusOK {
			var ResultJSON ResultOut

			json.Unmarshal([]byte(string(body)), &ResultJSON)
			log.Println(ResultJSON)
			c.JSON(response.StatusCode, gin.H{
				"result": ResultJSON.Result,
				"perFake": ResultJSON.PerFake,
				"perReal": ResultJSON.PerReal,
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

		log.Println("Llamada servicio Keras imágenes")

		ip, requestBody := getIP(c.Request)
		pass := RequestLogic(ip, client)

		if pass < 0{
			log.Println("Se han sueperado el número máximo de intentos  para la IP: ", ip)
			c.JSON(http.StatusForbidden, gin.H{
				"Error": "Ha superado el máximo de intentos",
			})
		} else{

		json.Unmarshal([]byte(string(requestBody)), &input)

		jsonData = []byte(`{
			"image_path":"` + input.ImagePath + `",
			"model_path":"`+ input.ModelPath  +`",
			"image_size":`+ strconv.Itoa(input.ImageSize)  +`,
			"lime":` + strconv.Itoa(input.Lime) + `
		}`)
 
		log.Println(string(jsonData))
		url = "https://kerasioimg-utoehvsqvq-ew.a.run.app"
		//url = "http://localhost:8085"

		request, _ = http.NewRequest("POST", url, bytes.NewBuffer(jsonData))
		request.Header.Set("Content-Type", "application/json; charset=UTF-8")

		response, error := client.Do(request)
		if error != nil {
			panic(error)
		}
		defer response.Body.Close()

		log.Println("response Status:", response.Status)
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

		log.Println("Llamada servicio Reverse Engineering")

		ip, requestBody := getIP(c.Request)
		pass := RequestLogic(ip, client)

		if pass < 0{
			log.Println("Se han sueperado el número máximo de intentos  para la IP: ", ip)
			c.JSON(http.StatusForbidden, gin.H{
				"Error": "Ha superado el máximo de intentos",
			})
		} else{

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

/* FUNCIÓN COMÚN PARA OBTENER LA IP*/

func getIP(request *http.Request) (string, []byte){
	var ip string
	var input ReuquestIP
	requestBody, _ := ioutil.ReadAll(request.Body)
	json.Unmarshal([]byte(string(requestBody)), &input)

	if input.IP != ""{
		ip = input.IP
	} else{
		ip = realip.FromRequest(request)
	}

	log.Println("IP: ", ip)

	return ip, requestBody
}