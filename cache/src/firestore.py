
import firebase_admin
from firebase_admin import credentials
from firebase_admin import firestore

cred = credentials.Certificate("/app/credentials/serviceAccountKey.json")
firebase_admin.initialize_app(cred)
db = firestore.client()

def save(sha, service, result, perFake, perReal):
    db.collection('deepfakes-' + service).document(sha).set({
        u'result': result,
        u'perFake': perFake,
        u'perReal': perReal,
    })


def get(sha, service):
    entry = db.collection('deepfakes-' + service).document(sha).get()

    if entry.exists:
        return entry.to_dict()["result"], entry.to_dict()["perFake"], entry.to_dict()["perReal"]
    else:
        return "","",""


def saveUser(user, requests):
    db.collection('requests').document(user).set({
        u'timestamps': requests,
    })


def getUser(user):
    entry = db.collection('requests').document(user).get()

    if entry.exists:
        return entry.to_dict()["timestamps"]
    else:
        return []

