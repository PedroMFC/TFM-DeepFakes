package main

import (
	"api/cmd/routes"
	"net/http"
)

func main() {
	parar := make(chan int)

	client := &http.Client{}
	go routes.NewAppGin(client).Start()

	<-parar
}
