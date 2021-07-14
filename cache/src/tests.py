import unittest
from unittest.mock import patch
import api
from webtest import TestApp

class TestMethods(unittest.TestCase):

    @patch('firestore.get')
    @patch('firestore.save')
    def testPutCorrecto(self, get, save):
        app = TestApp(api.app)
        get.return_value = 'fake'
        save.return_value = ''

        app.put_json('/results', dict(sha='sha', service='service', result='result'), status=201)
        app.put_json('/results', dict(sha='sha', service='service'), status=400)
        app.put_json('/results', dict(sha='sha', result='result'), status=400)
        app.put_json('/results', dict(service='service', result='result'), status=400)

    @patch('firestore.get')
    @patch('firestore.save')
    def testGetCorrecto(self, get, save):
        app = TestApp(api.app)
        get.return_value = 'fake'
        save.return_value = ''

        app.get('/results', status=405)
        app.get('/results/ej1/faceforensics', status=200)

if __name__ == '__main__':
    unittest.main()