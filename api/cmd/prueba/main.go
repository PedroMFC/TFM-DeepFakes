/*
Archivo de prueba para trabajar con diferentes frameworks y ver
cuál se adapta mejor
*/

package main

import (
	log "github.com/sirupsen/logrus"
	"net/http"
	"encoding/json"

	"github.com/gin-gonic/gin"

	"github.com/gorilla/mux"
	"github.com/pytimer/mux-logrus"

	"github.com/labstack/echo/v4"
  	"github.com/labstack/echo/v4/middleware"

	"strconv"
	"github.com/PedroMFC/EvaluaUGR/internal/microval/modelsval"

)



/*Single Source of Truth*/
var ValRepo modelsval.ValoracionRepositorio
var ValMap  modelsval.ValoracionMap
func StartData(){
	ValMap = *modelsval.NewValoracionMap()
	val := new(modelsval.Valoracion)
	val2 := new(modelsval.Valoracion)
	val.Valoracion = 2
	val2.Valoracion = 3
	ValMap.Valoraciones["AAA"] = []modelsval.Valoracion{*val, *val2}
	ValRepo = *modelsval.NewValoracionsRepositorio(&ValMap)
}

/*
MUX
*/

type applicationMux struct{
	Router *mux.Router
}

func (a *applicationMux) Start() {
	log.Fatal(http.ListenAndServe(":8081", a.Router))
}


func NewAppMux() *applicationMux {

	r := mux.NewRouter()
	r.Use(muxlogrus.NewLogger().Middleware)

	r.HandleFunc("/valoraciones/{asig}", getValoracionesMux(ValRepo) ).Methods(http.MethodGet)	
	r.HandleFunc("/valoraciones/{asig}/{val}", valorarMux(ValRepo) ).Methods("POST")	

	return &applicationMux{Router: r}
}

func getValoracionesMux(repo modelsval.ValoracionRepositorio) func(http.ResponseWriter, *http.Request){
	return func(w http.ResponseWriter, r *http.Request) { 
		asig:= mux.Vars(r)["asig"]
		valoraciones, err := repo.GetValoraciones(asig)

		if err != nil{
			w.WriteHeader(http.StatusNotFound) // We use not found for simplicity
			json.NewEncoder(w).Encode("Not found")
			return
		}

		var valoracionesNum []int
		for _, val :=range valoraciones{
				valoracionesNum = append(valoracionesNum, val.Valoracion)
		}

		w.WriteHeader(http.StatusOK)
		w.Header().Set("Content-Type", "application/json")
		mapV := map[string][]int{"Valoraciones": valoracionesNum}
		json.NewEncoder(w).Encode(mapV)
	}
}

func valorarMux(repo modelsval.ValoracionRepositorio) func(http.ResponseWriter, *http.Request){
	return func(w http.ResponseWriter, r *http.Request) { 
		asig:= mux.Vars(r)["asig"]
		val,err := strconv.Atoi(mux.Vars(r)["val"] )

		if err != nil{
			w.WriteHeader(http.StatusNotFound) // We use not found for simplicity
			json.NewEncoder(w).Encode("Not found")
			return
		}

		err = repo.Valorar(asig, val)

		if err != nil{
			w.WriteHeader(http.StatusNotFound) // We use not found for simplicity
			json.NewEncoder(w).Encode("Not found")
			return
		}

		w.WriteHeader(http.StatusOK)
		w.Header().Set("Content-Type", "application/json")
		mapV := map[string]string{"Valoraciones": "Valoración almacenada correctamente"}
		json.NewEncoder(w).Encode(mapV)
	}
}

/*
ECHO 
*/
type applicationEcho struct{
	Router *echo.Echo
}

func (a *applicationEcho) Start() {
	a.Router.Logger.Fatal(a.Router.Start(":8082"))
}

func NewAppEcho() *applicationEcho {
	router := echo.New()

	// Middleware
	router.Use(middleware.Logger())
	router.Use(middleware.Recover())

	router.GET("/valoraciones/:asig", getValoracionesEcho(ValRepo ) )
	router.POST("/valoraciones/:asig/:val", valorarEcho(ValRepo ) )

	return &applicationEcho{Router: router}
}

func getValoracionesEcho(repo modelsval.ValoracionRepositorio) echo.HandlerFunc{ 
	return func(c echo.Context) error {
		asig := c.Param("asig")

		valoraciones, err := repo.GetValoraciones(asig)

		if err != nil{
			c.Response().Header().Set(echo.HeaderContentType, echo.MIMEApplicationJSONCharsetUTF8)
  			c.Response().WriteHeader(http.StatusBadRequest)
			return json.NewEncoder(c.Response()).Encode("Not found")
		}


		var valoracionesNum []int
		for _, val :=range valoraciones{
			valoracionesNum = append(valoracionesNum, val.Valoracion)
		}

		c.Response().Header().Set(echo.HeaderContentType, echo.MIMEApplicationJSONCharsetUTF8)
  		c.Response().WriteHeader(http.StatusOK)
		mapV := map[string][]int{"Valoraciones": valoracionesNum}

		return json.NewEncoder(c.Response()).Encode(mapV)
	}
}

func valorarEcho(repo modelsval.ValoracionRepositorio) echo.HandlerFunc{ 
	return func(c echo.Context) error {
		asig := c.Param("asig")
		val,err := strconv.Atoi(c.Param("val") )

		if err != nil{
			c.Response().Header().Set(echo.HeaderContentType, echo.MIMEApplicationJSONCharsetUTF8)
  			c.Response().WriteHeader(http.StatusBadRequest)
			return json.NewEncoder(c.Response()).Encode("Not found")
		}

		err = repo.Valorar(asig, val)

		if err != nil{
			c.Response().Header().Set(echo.HeaderContentType, echo.MIMEApplicationJSONCharsetUTF8)
  			c.Response().WriteHeader(http.StatusBadRequest)
			return json.NewEncoder(c.Response()).Encode("Not found")
		}

		c.Response().Header().Set(echo.HeaderContentType, echo.MIMEApplicationJSONCharsetUTF8)
  		c.Response().WriteHeader(http.StatusCreated)
		msg := map[string]string{"Mensaje": "Valoración creada correctamene"}

		return json.NewEncoder(c.Response()).Encode(msg)
	}
}

/*
GIN 
*/

type applicationGin struct {
	Router *gin.Engine
}

func (a *applicationGin) Start() {
	log.Fatal(http.ListenAndServe("localhost:" + "8080", a.Router))
}

func NewAppGin() *applicationGin {
	router := gin.Default()

	router.GET("/valoraciones/:asig", getValoracionesGin(ValRepo))
	router.POST("/valoraciones/:asig/:val", valorarGin(ValRepo))

	return &applicationGin{Router: router}
}

func getValoracionesGin(repo modelsval.ValoracionRepositorio) gin.HandlerFunc {
	return func(c *gin.Context) {
		asig := c.Param("asig")
		valoraciones, err := repo.GetValoraciones(asig)

		if err != nil{
			if err.Error() == "Algo salió mal en la valoración:  la asignatura no está registrada"{
				c.JSON(http.StatusNotFound, gin.H{"error": err })
			}
			c.JSON(http.StatusBadRequest, gin.H{"error": err })

		} else {
			var valoracionesNum []int
			for _, val :=range valoraciones{
				valoracionesNum = append(valoracionesNum, val.Valoracion)
			}

			c.JSON(http.StatusOK, gin.H{"valoraciones": valoracionesNum})
		} 
	}
}

func valorarGin(repo modelsval.ValoracionRepositorio) gin.HandlerFunc {
	return func(c *gin.Context) {

		asig := c.Param("asig")
		val,err := strconv.Atoi( c.Param("val") )

		if err != nil{
			c.JSON(http.StatusBadRequest, gin.H{"error": "Valoración no es un entero"})
			return
		}


		err = repo.Valorar(asig, val)
		if err != nil{
			if err.Error() == "Algo salió mal en la valoración:  la asignatura no está registrada"{
				c.JSON(http.StatusNotFound, gin.H{"error": err })
			}
			c.JSON(http.StatusBadRequest, gin.H{"error": err })

		}
		
		c.JSON(http.StatusCreated, gin.H{"Mensaje": "creada correctamente"}) 
		
	}
}

func main() {

	parar := make (chan int)

	StartData()

	go NewAppGin().Start() 
	go NewAppMux().Start()
	go NewAppEcho().Start()

	<-parar
}