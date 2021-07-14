import unittest
from unittest.mock import patch
import api
from webtest import TestApp

class TestMethods(unittest.TestCase):

    @patch('download.downloadImage')
    @patch('deepfake_detection_test.detect')
    @patch('connect_cache.get')
    @patch('connect_cache.send')
    def testOK(self, mock_send, mock_get, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = {}
        mock_detect.return_value = {"result":[{"0": "fake"}]}
        mock_send.return_value = ''
        mock_get.return_value = ''

        app.post_json('/', dict(image_path='http://some_path', model_path='0_32000_model_31_70-23.pickle'), status=200)

    @patch('download.downloadImage')
    @patch('deepfake_detection_test.detect')
    @patch('connect_cache.get')
    @patch('connect_cache.send')
    def testModel(self, mock_send, mock_get, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = {}
        mock_detect.return_value = {"result":[{"0": "fake"}]}
        mock_send.return_value = ''
        mock_get.return_value = ''

        app.post_json('/', dict(image_path='http://some_path', model_path='0_32000_model_29.pickle'), status=200)
        app.post_json('/', dict(image_path='http://some_path', model_path='0_64000_model_30.pickle'), status=200)
        app.post_json('/', dict(image_path='http://some_path', model_path='0_32000_model_31_70-.pickle'), status=400)
        app.post_json('/', dict(image_path='http://some_path', model_path=''), status=200)
        app.post_json('/', dict(image_path='http://some_path'), status=200)


if __name__ == '__main__':
    unittest.main()