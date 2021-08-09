package tests

import (
	"bytes"
	"net/http"
	"encoding/json"
	"testing"

	"github.com/loov/hrtime/hrtesting"
)


func BenchmarkMux(b *testing.B) {
	postBody, _ := json.Marshal(map[string]string{

	})

   for i := 0; i < b.N; i++ {
	   http.Get("http://localhost:8081/valoraciones/AAA")
	   http.Post("http://localhost:8081/valoraciones/AAA/5", "",  bytes.NewBuffer(postBody))
   }
}

func BenchmarkEcho(b *testing.B) {
	postBody, _ := json.Marshal(map[string]string{

	})

   for i := 0; i < b.N; i++ {
	   http.Get("http://localhost:8082/valoraciones/AAA")
	   http.Post("http://localhost:8082/valoraciones/AAA/5", "",  bytes.NewBuffer(postBody))
   }
}

func BenchmarkGin(b *testing.B) {
	postBody, _ := json.Marshal(map[string]string{

	 })

	for i := 0; i < b.N; i++ {
		http.Get("http://localhost:8080/valoraciones/AAA")
		http.Post("http://localhost:8080/valoraciones/AAA/5", "",  bytes.NewBuffer(postBody))
	}
}

/*TEST DE VELOCIDAD*/

func BenchmarkGet(b *testing.B){
	bench := hrtesting.NewBenchmark(b)
	defer bench.Report()

	for bench.Next() {
        http.Get("http://localhost:8080/asignaturas/AAA/valoraciones")
    }
	
}

func BenchmarkPut(b *testing.B){
	bench := hrtesting.NewBenchmark(b)
	defer bench.Report()

	client := &http.Client{}
	request,_ := http.NewRequest("PUT", "http://localhost:8080/asignaturas/AAA/valoraciones", nil)
	for bench.Next() {
       client.Do(request)
    }
	
}

func BenchmarkPost(b *testing.B){
	bench := hrtesting.NewBenchmark(b)
	defer bench.Report()

	postBody, _ := json.Marshal(map[string]string{

	})

	for bench.Next() {
        http.Post("http://localhost:8080/asignaturas/AAA/valoraciones/2", "",  bytes.NewBuffer(postBody))
    }
	
}