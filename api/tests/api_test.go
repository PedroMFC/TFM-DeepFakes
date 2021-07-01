
package tests

import (
	"net/http"
	"testing"
	//"errors"
	"io/ioutil"
	"bytes"

	"github.com/steinfletcher/apitest"
	"api/cmd/routes"
	"api/cmd/mocks"
	//"api/cmd/restclient"
)

func TestPrueba(t *testing.T) {
	client := &mocks.MockClient{} 
	handler := routes.NewAppGin(client).Router

	
	json := `{"name":"Test Name","full_name":"test full name","owner":{"login": "octocat"}}`
	// create a new reader with that JSON
	r := ioutil.NopCloser(bytes.NewReader([]byte(json)))
	mocks.GetDoFunc = func(*http.Request) (*http.Response, error) {
		return &http.Response{
			StatusCode: 200,
			Body:       r,
		}, nil
	}

	 
	apitest.New().
		Handler(handler).
		Get("/").
		// Body("{ \"servicio\":1 }").
		Expect(t).
		Status(http.StatusOK).
		End()

	apitest.New().
		Handler(handler).
		Post("/").
		Body("{ \"servicio\":1 }").
		Expect(t).
		Status(http.StatusOK).
		End()
}
