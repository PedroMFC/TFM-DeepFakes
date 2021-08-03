import unittest
from unittest.mock import patch
import api
from webtest import TestApp

class TestMethods(unittest.TestCase):

    @patch('firestore.get')
    @patch('firestore.save')
    def testPutCorrecto(self, save, get):
        app = TestApp(api.app)
        get.return_value = 'fake', 50.0, 50.0
        save.return_value = ''

        app.put_json('/results', dict(sha='sha', service='service', result='result'), status=201)
        app.put_json('/results', dict(sha='sha', service='service', result='result', perFake=50), status=201)
        app.put_json('/results', dict(sha='sha', service='service', result='result', perReal=50), status=201)
        app.put_json('/results', dict(sha='sha', service='service', result='result', perFake=50, perReal=50), status=201)
        app.put_json('/results', dict(sha='sha', service='service'), status=400)
        app.put_json('/results', dict(sha='sha', result='result'), status=400)
        app.put_json('/results', dict(service='service', result='result'), status=400)

    @patch('firestore.get')
    @patch('firestore.save')
    def testGetCorrecto(self, save, get):
        app = TestApp(api.app)
        get.return_value = 'fake', 50.0, 50.0
        save.return_value = ''

        app.get('/results', status=405)
        app.get('/results/ej1/faceforensics', status=200)


    @patch('firestore.getUser')
    @patch('firestore.saveUser')
    def testGetUserCorrecto(self, get, save):
        app = TestApp(api.app)
        get.return_value = ''
        save.return_value = ''

        app.get('/requests', status=404)
        app.get('/requests/IP', status=200)

    
    @patch('firestore.getUser')
    @patch('firestore.saveUser')
    def testPostUserCorrecto(self, get, save):
        app = TestApp(api.app)
        get.return_value = ''
        save.return_value = ''

        app.post_json('/requests', dict(timestamps=[55,22]), status=404)
        app.post_json('/requests/IP', status=400)
        app.post_json('/requests/IP', dict(timestamps=[55,22]), status=201)

if __name__ == '__main__':
    unittest.main()