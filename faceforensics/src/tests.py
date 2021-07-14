import unittest
from unittest.mock import patch
import api
from webtest import TestApp

class TestMethods(unittest.TestCase):

    @patch('download.download_youtube')
    @patch('detect.test_full_image_network')
    @patch('connect_cache.get')
    @patch('connect_cache.send')
    def testCorrecto(self, mock_send, mock_get, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = 0
        mock_detect.return_value = [{"0": "fake"}, {"1":"fake"}]
        mock_send.return_value = ''
        mock_get.return_value = ''

        resp = app.post_json('/', dict(video_path='http://some_path', start_frame=1, end_frame=2, model_path='ffpp_c40.pth'), status=200)
        #print(resp.request)


    @patch('download.download_youtube')
    @patch('detect.test_full_image_network')
    @patch('connect_cache.get')
    @patch('connect_cache.send')
    def testModelo(self, mock_send, mock_get, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = 0
        mock_detect.return_value = [{"0": "fake"}, {"1":"fake"}]
        mock_send.return_value = ''
        mock_get.return_value = ''

        app.post_json('/', dict(video_path='http://some_path', start_frame=1, end_frame=2, model_path='ffpp_c4.pth'), status=400)
        app.post_json('/', dict(video_path='http://some_path', start_frame=1, end_frame=2, model_path='ffpp_c23.pth'), status=200)
        app.post_json('/', dict(video_path='http://some_path', start_frame=1, end_frame=2, model_path=''), status=200)
        app.post_json('/', dict(video_path='http://some_path', start_frame=1, end_frame=2), status=200)

    @patch('download.download_youtube')
    @patch('detect.test_full_image_network')
    @patch('connect_cache.get')
    @patch('connect_cache.send')
    def testStartFrame(self, mock_send, mock_get, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = 0
        mock_detect.return_value = [{"0": "fake"}, {"1":"fake"}]
        mock_send.return_value = ''
        mock_get.return_value = ''

        app.post_json('/', dict(video_path='http://some_path', start_frame="asasd", end_frame=2, model_path='ffpp_c40.pth'), status=400)
        app.post_json('/', dict(video_path='http://some_path', start_frame=-3, end_frame=2, model_path='ffpp_c40.pth'), status=400)
        app.post_json('/', dict(video_path='http://some_path', start_frame=0.5, end_frame=2, model_path='ffpp_c40.pth'), status=400)

    @patch('download.download_youtube')
    @patch('detect.test_full_image_network')
    @patch('connect_cache.get')
    @patch('connect_cache.send')
    def testEndFrame(self, mock_send, mock_get, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = 0
        mock_detect.return_value = [{"0": "fake"}, {"1":"fake"}]
        mock_send.return_value = ''
        mock_get.return_value = ''

        app.post_json('/', dict(video_path='http://some_path', start_frame=0, end_frame="asd", model_path='ffpp_c40.pth'), status=400)
        app.post_json('/', dict(video_path='http://some_path', start_frame=0, end_frame=-2, model_path='ffpp_c40.pth'), status=400)
        app.post_json('/', dict(video_path='http://some_path', start_frame=0, end_frame=2.5, model_path='ffpp_c40.pth'), status=400)


    @patch('download.download_youtube')
    @patch('detect.test_full_image_network')
    @patch('connect_cache.get')
    @patch('connect_cache.send')
    def testDownload(self, mock_send, mock_get, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = -1
        mock_detect.return_value = [{"0": "fake"}, {"1":"fake"}]
        mock_send.return_value = ''
        mock_get.return_value = ''

        resp = app.post_json('/', dict(video_path='http://some_error_path', start_frame=1, end_frame=2, model_path='ffpp_c40.pth'), status=400)

    
    @patch('download.download_youtube')
    @patch('detect.test_full_image_network')
    @patch('connect_cache.get')
    @patch('connect_cache.send')
    def testFullFake(self, mock_send, mock_get, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = 0
        mock_detect.return_value = [{"0": "fake"}, {"1":"fake"}]
        mock_send.return_value = ''
        mock_get.return_value = ''
        
        resp = app.post_json('/', dict(video_path='http://some_path', start_frame=1, end_frame=2, model_path='ffpp_c40.pth', full=0), status=200)
        assert resp.body == b'{\n  "result": [\n    {\n      "0": "fake"\n    }\n  ]\n}\n'

        resp = app.post_json('/', dict(video_path='http://some_path', start_frame=1, end_frame=2, model_path='ffpp_c40.pth', full=1), status=200)
        assert resp.body == b'{\n  "result": [\n    {\n      "0": "fake"\n    }, \n    {\n      "1": "fake"\n    }\n  ]\n}\n'

    @patch('download.download_youtube')
    @patch('detect.test_full_image_network')
    @patch('connect_cache.get')
    @patch('connect_cache.send')
    def testFullReal(self, mock_send, mock_get, mock_detect, mock_download):
        app = TestApp(api.app)
        mock_download.return_value = 0
        mock_detect.return_value = [{"0": "real"}, {"1":"real"}]
        mock_send.return_value = ''
        mock_get.return_value = ''
        
        resp = app.post_json('/', dict(video_path='http://some_path', start_frame=1, end_frame=2, model_path='ffpp_c40.pth', full=0), status=200)
        assert resp.body == b'{\n  "result": [\n    {\n      "0": "real"\n    }\n  ]\n}\n'

        resp = app.post_json('/', dict(video_path='http://some_path', start_frame=1, end_frame=2, model_path='ffpp_c40.pth', full=1), status=200)
        assert resp.body == b'{\n  "result": [\n    {\n      "0": "real"\n    }, \n    {\n      "1": "real"\n    }\n  ]\n}\n'


if __name__ == '__main__':
    unittest.main()