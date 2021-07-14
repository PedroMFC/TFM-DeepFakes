
import firebase_admin
from firebase_admin import credentials
from firebase_admin import firestore

cred = credentials.Certificate("serviceAccountKey.json")
firebase_admin.initialize_app(cred)
db = firestore.client()

def save(sha, service, result):
    db.collection(u'deepfakes').document(sha).set({
        u'result': result,
        u'service': service
    })


def get(sha, service):
    entry = db.collection(u'deepfakes').document(sha).get()

    if entry.exists:
        if entry.to_dict()["service"] == service:
            return entry.to_dict()["result"]
    else:
        return ""