package tests

import (
	"net/http"
	"testing"

	//"errors"
	"bytes"
	"io/ioutil"

	"api/cmd/mocks"
	"api/cmd/routes"
	"api/cmd/restclient"

	"github.com/steinfletcher/apitest"
	//"api/cmd/restclient"
)

func TestPrueba(t *testing.T) {
	client := &mocks.MockClient{} 
	handler := routes.NewAppGin(client).Router



	apitest.New().
		Handler(handler).
		Get("/").
		Expect(t).
		Status(http.StatusOK).
		End()

}

func TestRevEngOK(t *testing.T) {
	client := &mocks.MockClient{} 
	handler := routes.NewAppGin(client).Router

	
	json := `[{"0":"fake"}]`
	// create a new reader with that JSON
	r := ioutil.NopCloser(bytes.NewReader([]byte(json)))
	mocks.GetDoFunc = func(*http.Request) (*http.Response, error) {
		return &http.Response{
			StatusCode: 200,
			Body:       r,
		}, nil
	}

	routes.RequestLogic = func(user string, client restclient.HTTPClient) int {
		return 1
	}

	apitest.New().
		Handler(handler).
		Post("/reverse").
		// Body("{ \"servicio\":1 }").
		Expect(t).
		Status(http.StatusOK).
		End()
}


func TestRevEngError(t *testing.T) {
	client := &mocks.MockClient{} 
	handler := routes.NewAppGin(client).Router

	
	json := `{"Error":"Un error"}`
	// create a new reader with that JSON
	r := ioutil.NopCloser(bytes.NewReader([]byte(json)))
	mocks.GetDoFunc = func(*http.Request) (*http.Response, error) {
		return &http.Response{
			StatusCode: 400,
			Body:       r,
		}, nil
	}

	routes.RequestLogic = func(user string, client restclient.HTTPClient) int {
		return 1
	}

	apitest.New().
		Handler(handler).
		Post("/reverse").
		Expect(t).
		Status(http.StatusBadRequest).
		End()
}

func TestFaceForensicsOK(t *testing.T) {
	client := &mocks.MockClient{} 
	handler := routes.NewAppGin(client).Router

	
	json := `[{"0":"fake"}]`
	// create a new reader with that JSON
	r := ioutil.NopCloser(bytes.NewReader([]byte(json)))
	mocks.GetDoFunc = func(*http.Request) (*http.Response, error) {
		return &http.Response{
			StatusCode: 200,
			Body:       r,
		}, nil
	}

	routes.RequestLogic = func(user string, client restclient.HTTPClient) int {
		return 1
	}


	apitest.New().
		Handler(handler).
		Post("/faceforensics").
		Expect(t).
		Status(http.StatusOK).
		End()
}


func TestFaceForensicsError(t *testing.T) {
	client := &mocks.MockClient{} 
	handler := routes.NewAppGin(client).Router

	
	json := `{"Error":"Un error"}`
	// create a new reader with that JSON
	r := ioutil.NopCloser(bytes.NewReader([]byte(json)))
	mocks.GetDoFunc = func(*http.Request) (*http.Response, error) {
		return &http.Response{
			StatusCode: 400,
			Body:       r,
		}, nil
	}

	routes.RequestLogic = func(user string, client restclient.HTTPClient) int {
		return 1
	}

	apitest.New().
		Handler(handler).
		Post("/faceforensics").
		Expect(t).
		Status(http.StatusBadRequest).
		End()
}


func TestKerasOK(t *testing.T) {
	client := &mocks.MockClient{} 
	handler := routes.NewAppGin(client).Router

	
	json := `[{"0":"fake"}]`
	// create a new reader with that JSON
	r := ioutil.NopCloser(bytes.NewReader([]byte(json)))
	mocks.GetDoFunc = func(*http.Request) (*http.Response, error) {
		return &http.Response{
			StatusCode: 200,
			Body:       r,
		}, nil
	}

	routes.RequestLogic = func(user string, client restclient.HTTPClient) int {
		return 1
	}


	apitest.New().
		Handler(handler).
		Post("/kerasio").
		Expect(t).
		Status(http.StatusOK).
		End()
}


func TestKerasError(t *testing.T) {
	client := &mocks.MockClient{} 
	handler := routes.NewAppGin(client).Router

	
	json := `{"Error":"Un error"}`
	// create a new reader with that JSON
	r := ioutil.NopCloser(bytes.NewReader([]byte(json)))
	mocks.GetDoFunc = func(*http.Request) (*http.Response, error) {
		return &http.Response{
			StatusCode: 400,
			Body:       r,
		}, nil
	}

	routes.RequestLogic = func(user string, client restclient.HTTPClient) int {
		return 1
	}


	apitest.New().
		Handler(handler).
		Post("/kerasio").
		Expect(t).
		Status(http.StatusBadRequest).
		End()
}


func TestNoService(t *testing.T) {
	client := &mocks.MockClient{} 
	handler := routes.NewAppGin(client).Router

	
	json := `[{"0":"fake"}]`
	// create a new reader with that JSON
	r := ioutil.NopCloser(bytes.NewReader([]byte(json)))
	mocks.GetDoFunc = func(*http.Request) (*http.Response, error) {
		return &http.Response{
			StatusCode: 200,
			Body:       r,
		}, nil
	}

	routes.RequestLogic = func(user string, client restclient.HTTPClient) int {
		return 1
	}


	apitest.New().
		Handler(handler).
		Post("/otroservicio").
		Expect(t).
		Status(http.StatusNotFound).
		End()
}