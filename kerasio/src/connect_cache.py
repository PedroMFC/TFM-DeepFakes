
from hash import getHash
import requests

def get(path, service):
    hash_value = getHash(path)

    url = 'https://cache-utoehvsqvq-ew.a.run.app/results/' + hash_value + '/' + service

    r = requests.get(url)

    data = r.json()

    # print("En cache " + data['result'])
    # print("Resultado cache: " + data.result)

    return data['result'], data['perFake'], data['perReal']

def send(path, result, service, perFake, perReal):
    hash_value = getHash(path)

    url = 'https://cache-utoehvsqvq-ew.a.run.app/results'

    data = {'sha': hash_value,
        'result':result,
        'service':service,
        'perFake': perFake,
        'perReal': perReal
        }

    requests.put(url, json = data)


