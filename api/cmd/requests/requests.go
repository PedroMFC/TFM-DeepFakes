package requests

import (
	"api/cmd/restclient"
	"net/http"
	"bytes"
	"time"
	"io/ioutil"

	"encoding/json"
	"log"
)


const LIMIT_REQUESTS = 2
const MINUTES_INTERVAL = 5

type Timestamps struct{
	Timestamps []time.Time `json:"timestamps"`
}

type Requests struct{
	Timestamps []time.Time `json:"timestamps"`
}

func RequestLogic(user string, client restclient.HTTPClient) int{

	timestamps := getUser(user, client)

	if timestamps == nil{
		return -1
	}

	now:= time.Now()

	limit := now.Add(-MINUTES_INTERVAL*time.Minute)
	if len(timestamps) > 0 && (timestamps[0].Before(limit)){
		timestamps = timestamps[1:]
	}

	if len(timestamps) < LIMIT_REQUESTS {
		timestamps = append(timestamps, now)
		saveUser(user, timestamps, client)
		return 1
	}

	return -1

}

func getUser(user string, client restclient.HTTPClient) []time.Time {
		var request *http.Request
		var result []time.Time

		url := "https://cache-utoehvsqvq-ew.a.run.app/requests/"
		request, _ = http.NewRequest("GET", url + user, nil)
		request.Header.Set("Content-Type", "application/json; charset=UTF-8")

		response, error := client.Do(request)
		if error != nil {
			panic(error)
		}
		defer response.Body.Close()

		log.Println("response Status getUser:", response.Status)
		body, _ := ioutil.ReadAll(response.Body)

		if response.StatusCode == http.StatusOK {
			var ResultJSON Requests

			json.Unmarshal([]byte(string(body)), &ResultJSON)
			log.Println(ResultJSON)

			result = ResultJSON.Timestamps
			
		} else {
			result = nil
		}

		return result
}

func saveUser(user string, timestamps []time.Time, client restclient.HTTPClient){
		var request *http.Request

		url := "https://cache-utoehvsqvq-ew.a.run.app/requests/"

		postBody, _ := json.Marshal(Timestamps{
			Timestamps:        timestamps,
		})

		request, _ = http.NewRequest("POST", url + user, bytes.NewBuffer(postBody))
		request.Header.Set("Content-Type", "application/json; charset=UTF-8")

		response, error := client.Do(request)
		if error != nil {
			panic(error)
		}
		defer response.Body.Close()

		log.Println("response Status saveUser:", response.Status)
}