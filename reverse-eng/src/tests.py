import unittest
from unittest.mock import patch
import api
from webtest import TestApp

class TestMethods(unittest.TestCase):

    @patch('download.downloadImage')
    @patch('deepfake_detection_test.detect')
    def test(self, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = {}
        mock_detect.return_value = '{"fake": 1}'

        resp = app.post_json('/', dict(image_path='http://some_path'))
        #print(resp.request)
        self.assertEqual(resp.status, '200 OK')


if __name__ == '__main__':
    unittest.main()