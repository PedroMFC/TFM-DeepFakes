from os import path
import unittest
from unittest.mock import patch
import api
from webtest import TestApp

class TestMethods(unittest.TestCase):

    @patch('image_clasification.detect')
    def testCorrecto(self,mock_detect):
        app = TestApp(api.app)
        mock_detect.return_value = '', ''

        app.post_json('/', dict(image_path='http://some_path', model_path='http://some_model'), status=200)
        app.post_json('/', dict(image_path='http://some_path', model_path='http://some_model', image_size=299), status=200)
        app.post_json('/', dict(image_path='http://some_path', model_path='http://some_model', lime=0), status=200)
        app.post_json('/', dict(image_path='http://some_path', model_path='http://some_model', image_size=299, lime=0), status=200)

    @patch('image_clasification.detect')
    def testError(self,mock_detect):
        app = TestApp(api.app)
        mock_detect.return_value = '', ''

        app.post_json('/', dict(model_path='http://some_model'), status=400)
        app.post_json('/', dict(image_path='http://some_path'), status=400)
        app.post_json('/', dict(lime=0), status=400)
        app.post_json('/', dict(image_size=299), status=400)


if __name__ == '__main__':
    unittest.main()