import unittest
from unittest.mock import patch
import api
from webtest import TestApp

class TestMethods(unittest.TestCase):

    @patch('download.downloadImage')
    @patch('deepfake_detection_test.detect')
    def testOK(self, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = {}
        mock_detect.return_value = '{"fake": 1}'

        app.post_json('/', dict(image_path='http://some_path', model_path='0_32000_model_31_70-23.pickle'), status=200)

    @patch('download.downloadImage')
    @patch('deepfake_detection_test.detect')
    def testModel(self, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = {}
        mock_detect.return_value = '{"fake": 1}'

        app.post_json('/', dict(image_path='http://some_path', model_path='0_32000_model_29.pickle'), status=200)
        app.post_json('/', dict(image_path='http://some_path', model_path='0_64000_model_30.pickle'), status=200)
        app.post_json('/', dict(image_path='http://some_path', model_path='0_32000_model_31_70-.pickle'), status=400)



if __name__ == '__main__':
    unittest.main()