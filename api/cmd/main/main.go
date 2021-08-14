package main

import (
	"api/cmd/routes"
	"net/http"
	"github.com/gin-gonic/gin"
)

func main() {
	parar := make(chan int)

	client := &http.Client{}
	gin.SetMode(gin.ReleaseMode)
	go routes.NewAppGin(client).Start()

	<-parar
}
