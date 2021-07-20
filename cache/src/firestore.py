
import firebase_admin
from firebase_admin import credentials
from firebase_admin import firestore

cred = credentials.Certificate("serviceAccountKey.json")
firebase_admin.initialize_app(cred)
db = firestore.client()

def save(sha, service, result):
    db.collection('deepfakes-' + service).document(sha).set({
        u'result': result,
    })


def get(sha, service):
    entry = db.collection('deepfakes-' + service).document(sha).get()

    if entry.exists:
        return entry.to_dict()["result"]
    else:
        return ""


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

