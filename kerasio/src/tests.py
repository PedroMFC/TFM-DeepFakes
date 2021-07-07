import unittest
from unittest.mock import patch
import api
from webtest import TestApp

class TestMethods(unittest.TestCase):

    @patch('download.download_youtube')
    @patch('video_clasification.detect')
    def testCorrecto(self, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = 0
        mock_detect.return_value = [{"0": "fake"}]

        app.post_json('/', dict(video_path='http://some_path'), status=200)


    @patch('download.download_youtube')
    @patch('video_clasification.detect')
    def testDownload(self, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = -1
        mock_detect.return_value = [{"0": "fake"}]
        
        app.post_json('/', dict(video_path='http://some_error_path'), status=400)


if __name__ == '__main__':
    unittest.main()