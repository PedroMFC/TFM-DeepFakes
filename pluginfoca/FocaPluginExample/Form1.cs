using System;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FocaPluginExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            volver();
        }

        private void setLoading()
        {
            panelReverse.Visible = false;
            panelFaceforensics.Visible = false;
            panelKeras.Visible = false;
            panelLoading.Visible = true;
            panelReal.Visible = false;
            panelFake.Visible = false;
        }

        private void setReal()
        {
            panelLoading.Visible = false;
            panelReal.Visible = true;
        }

        private void setFake()
        {
            panelLoading.Visible = false;
            panelFake.Visible = true;
        }

        private void setError()
        {
            panelLoading.Visible = false;
            panelError.Visible = true;
        }

        private void volver()
        {
            panelReverse.Visible = false;
            panelFaceforensics.Visible = false;
            panelKeras.Visible = false;
            panelLoading.Visible = false;
            panelReal.Visible = false;
            panelFake.Visible = false;
            panelError.Visible = false;

            comboAlgoritmo.SelectedIndex = -1;
        }

        private void comboAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAlgoritmo.SelectedIndex == 0 )
            {
                panelReverse.Visible = false;
                panelFaceforensics.Visible = true;
                panelKeras.Visible = false;
            }
            else if (comboAlgoritmo.SelectedIndex == 1)
            {
                panelReverse.Visible = true;
                panelFaceforensics.Visible = false;
                panelKeras.Visible = false;
            }
            else if (comboAlgoritmo.SelectedIndex == 2)
            {
                panelReverse.Visible = false;
                panelFaceforensics.Visible = false;
                panelKeras.Visible = true;
            }
            else
            {
                panelReverse.Visible = false;
                panelFaceforensics.Visible = false;
                panelKeras.Visible = false;
            }
        }

        private async void buttonRE_Click(object sender, EventArgs e)
        {
            setLoading();
            //string url = "https://api-utoehvsqvq-ew.a.run.app/reverse";
            string url = "https://reverse-utoehvsqvq-ew.a.run.app";
            var client = new HttpClient();

            if (BoxModelRE.SelectedIndex == -1)
            {
                BoxModelRE.SelectedIndex = 0;
            }

            Models.PostReverseEngineering post = new Models.PostReverseEngineering()
            {
                image_path = URLREBox.Text,
                model_path = BoxModelRE.SelectedItem.ToString()
            };

            var serializer = new JavaScriptSerializer();
            var data = serializer.Serialize(post);
            HttpContent content =
                 new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await client.PostAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var resultHttp = await httpResponse.Content.ReadAsStringAsync();
                resultHttp = resultHttp.Replace("\r\n","").Replace("\\n", System.Environment.NewLine).Replace("\\","");
                //MessageBox.Show(resultHttp);
                var resultJSON = serializer.Deserialize<Models.Result>(resultHttp);

                //MessageBox.Show(resultJSON.result[0]["0"]);
                //result.Text = resultHttp;

                if(resultJSON.result[0]["0"] == "fake")
                {
                    setFake();
                }
                else
                {
                    setReal();
                }
            }
            else
            {

                //MessageBox.Show("Ha habido algún error");
                setError();
            }
        }

        private async void buttonFF_Click(object sender, EventArgs e)
        {
            setLoading();
            //string url = "https://api-utoehvsqvq-ew.a.run.app/faceforensics";
            string url = "https://faceforensics-utoehvsqvq-ew.a.run.app";
            var client = new HttpClient();
            Models.PostFaceforensics post;

            if (BoxModelFF.SelectedIndex == -1)
            {
                BoxModelFF.SelectedIndex = 0;
            }

            if ((frameInitial.Text != "" && frameInitial.Text != null) &&
               (frameFinal.Text != "" && frameFinal.Text != null))
            {
                post = new Models.PostFaceforensics()
                {
                    video_path = URLFFBox.Text,
                    model_path = BoxModelFF.SelectedItem.ToString(),
                    start_frame = int.Parse(frameInitial.Text),
                    end_frame = int.Parse(frameFinal.Text)
                };
            }
            else
            {
                post = new Models.PostFaceforensics()
                {
                    video_path = URLFFBox.Text,
                    model_path = BoxModelFF.SelectedItem.ToString()
                };
            }

            var serializer = new JavaScriptSerializer();
            var data = serializer.Serialize(post);
            HttpContent content =
                 new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await client.PostAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var resultHttp = await httpResponse.Content.ReadAsStringAsync();
                resultHttp = resultHttp.Replace("\r\n", "").Replace("\\n", System.Environment.NewLine).Replace("\\", "");
                //MessageBox.Show(resultHttp);
                var resultJSON = serializer.Deserialize<Models.Result>(resultHttp);

                //MessageBox.Show(resultJSON.result[0]["0"]);
                //result.Text = resultHttp;

                if (resultJSON.result[0]["0"] == "fake")
                {
                    setFake();
                }
                else
                {
                    setReal();
                }
            }
            else
            {
                setError();
            }

        }

        private async void buttonKIO_Click_1(object sender, EventArgs e)
        {
            setLoading();
            string url = "https://api-utoehvsqvq-ew.a.run.app/kerasio";
            //string url = "https://kerasio-utoehvsqvq-ew.a.run.app";
            var client = new HttpClient();
            Models.PostFaceforensics post;

            post = new Models.PostFaceforensics()
            {
                video_path = URLKIOBox.Text,
            };

            var serializer = new JavaScriptSerializer();
            var data = serializer.Serialize(post);
            HttpContent content =
                 new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await client.PostAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var resultHttp = await httpResponse.Content.ReadAsStringAsync();
                resultHttp = resultHttp.Replace("\r\n", "").Replace("\\n", System.Environment.NewLine).Replace("\\", "");
                //MessageBox.Show(resultHttp);
                var resultJSON = serializer.Deserialize<Models.Result>(resultHttp);

                //MessageBox.Show(resultJSON.result[0]["0"]);
                //result.Text = resultHttp;
                if (resultJSON.result[0]["0"] == "fake")
                {
                    setFake();
                }
                else
                {
                    setReal();
                }
            }
            else
            {
                //MessageBox.Show("Ha habido algún error");
                setError();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            volver();
        }

        private void buttonAgain_Click(object sender, EventArgs e)
        {
            volver();
        }

        private void buttonAgain3_Click(object sender, EventArgs e)
        {
            volver();
        }

        private void panelFaceforensics_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
