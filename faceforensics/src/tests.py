import unittest
from unittest.mock import patch
import api
from webtest import TestApp

class TestMethods(unittest.TestCase):

    @patch('download.download_youtube')
    @patch('detect.test_full_image_network')
    def testCorrecto(self, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = 0
        mock_detect.return_value = '{"fake": 1}'

        resp = app.post_json('/', dict(video_path='http://some_path', start_frame=1, end_frame=2, model_path='ffpp_c40.pth'), status=200)
        #print(resp.request)


    @patch('download.download_youtube')
    @patch('detect.test_full_image_network')
    def testModelo(self, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = 0
        mock_detect.return_value = '{"fake": 1}'

        app.post_json('/', dict(video_path='http://some_path', start_frame=1, end_frame=2, model_path='ffpp_c4.pth'), status=400)
        app.post_json('/', dict(video_path='http://some_path', start_frame=1, end_frame=2), status=200)

    @patch('download.download_youtube')
    @patch('detect.test_full_image_network')
    def testStartFrame(self, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = 0
        mock_detect.return_value = '{"fake": 1}'

        app.post_json('/', dict(video_path='http://some_path', start_frame="asasd", end_frame=2, model_path='ffpp_c40.pth'), status=400)
        app.post_json('/', dict(video_path='http://some_path', start_frame=-3, end_frame=2, model_path='ffpp_c40.pth'), status=400)
        app.post_json('/', dict(video_path='http://some_path', start_frame=0.5, end_frame=2, model_path='ffpp_c40.pth'), status=400)

    @patch('download.download_youtube')
    @patch('detect.test_full_image_network')
    def testEndFrame(self, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = 0
        mock_detect.return_value = '{"fake": 1}'

        app.post_json('/', dict(video_path='http://some_path', start_frame=0, end_frame="asd", model_path='ffpp_c40.pth'), status=400)
        app.post_json('/', dict(video_path='http://some_path', start_frame=0, end_frame=-2, model_path='ffpp_c40.pth'), status=400)
        app.post_json('/', dict(video_path='http://some_path', start_frame=0, end_frame=2.5, model_path='ffpp_c40.pth'), status=400)


    @patch('download.download_youtube')
    @patch('detect.test_full_image_network')
    def testDownload(self, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = -1
        mock_detect.return_value = '{"fake": 1}'

        resp = app.post_json('/', dict(video_path='http://some_error_path', start_frame=1, end_frame=2, model_path='ffpp_c40.pth'), status=400)


if __name__ == '__main__':
    unittest.main()