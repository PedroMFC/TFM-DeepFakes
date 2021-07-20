import publicIp from "public-ip";

export const  CheckRequests = async() =>{
    var limit = 3;
    var timePeriod = 60 *1000;
    var now = Date.now();
    var requests
    var result = 0
    var ip = await publicIp.v4()

    await fetch("https://api-utoehvsqvq-ew.a.run.app/requests/" + ip, {
                "method": "GET",
                "headers": {
                    "content-type": "application/json",
                    "accept": "application/json"
                },
            })
            .then(response => response.json())
            .then(response => {
                requests = response.timestamps
            })
            .catch(err => {
                console.log(err);
            });

    console.log(requests)
    if (requests.length > 0 && (requests[0] < now - timePeriod) ){
        requests = requests.slice(1)
    }

    if (requests.length < limit){
        requests = [ ...requests, now ]
        SendTimeStamps(requests, ip)
        result = now;
    }

    console.log(requests)

    return result;
};


function SendTimeStamps(timestamps, ip){
    fetch("https://api-utoehvsqvq-ew.a.run.app/requests/" + ip, {
                "method": "POST",
                "headers": {
                    "content-type": "application/json",
                    "accept": "application/json"
                },
                "body": JSON.stringify({
                  timestamps: timestamps,
                })
            })
            .then(response => response.json())
            .then(response => {
                console.log(response)
            })
            .catch(err => {
                console.log(err);
            });
}

export default CheckRequests