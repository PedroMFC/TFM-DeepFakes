using System;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;

namespace FocaPluginExample
{
    public partial class Form1 : Form
    {
        private string URL_API = "https://api-utoehvsqvq-ew.a.run.app"; 
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
            panelKIOIMG.Visible = false;
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
            panelKIOIMG.Visible = false;

            comboAlgoritmo.SelectedIndex = -1;
        }

        private void comboAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAlgoritmo.SelectedIndex == 0 )
            {
                panelReverse.Visible = false;
                panelFaceforensics.Visible = true;
                panelKeras.Visible = false;
                panelKIOIMG.Visible = false;
            }
            else if (comboAlgoritmo.SelectedIndex == 1)
            {
                panelReverse.Visible = true;
                panelFaceforensics.Visible = false;
                panelKeras.Visible = false;
                panelKIOIMG.Visible = false;
            }
            else if (comboAlgoritmo.SelectedIndex == 2)
            {
                panelReverse.Visible = false;
                panelFaceforensics.Visible = false;
                panelKeras.Visible = true;
                panelKIOIMG.Visible = false;
            }
            else if (comboAlgoritmo.SelectedIndex == 3)
            {
                panelReverse.Visible = false;
                panelFaceforensics.Visible = false;
                panelKeras.Visible = false;
                panelKIOIMG.Visible = true;
            }
            else
            {
                panelReverse.Visible = false;
                panelFaceforensics.Visible = false;
                panelKeras.Visible = false;
                panelKIOIMG.Visible = false;
            }
        }

        private async void buttonRE_Click(object sender, EventArgs e)
        {
            setLoading();
            string url = URL_API + "/reverse";
            //string url = "https://reverse-utoehvsqvq-ew.a.run.app";
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

                generarPDF(URLREBox.Text, "reverse", resultJSON.result[0]["0"]);
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
            string url = URL_API + "/faceforensics";
            //string url = "https://faceforensics-utoehvsqvq-ew.a.run.app";
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

                generarPDF(URLFFBox.Text, "faceforensics", resultJSON.result[0]["0"], resultJSON.perFake, resultJSON.perReal);
            }
            else
            {
                setError();
            }

        }

        private async void buttonKIO_Click(object sender, EventArgs e)
        {
            setLoading();
            string url = URL_API + "/kerasio";
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

                generarPDF(URLKIOBox.Text, "keras", resultJSON.result[0]["0"], resultJSON.perFake, resultJSON.perReal);
            }
            else
            {
                //MessageBox.Show("Ha habido algún error");
                setError();
            }
        }

        private async void buttonKIOIMG_Click(object sender, EventArgs e)
        {
            setLoading();
            string url = URL_API + "/kerasioimg";
            //string url = "https://kerasioimg-utoehvsqvq-ew.a.run.app";
            var client = new HttpClient();
            Models.PostKerasIMG post;

            if (comboBoxLIME.SelectedIndex == -1)
            {
                comboBoxLIME.SelectedIndex = 1;
            }

            var limeAux = 0;
            if (comboBoxLIME.SelectedIndex == 0)
            {
                limeAux = 1;
            }

            post = new Models.PostKerasIMG()
            {
                image_path = URLKIOIMG.Text,
                model_path = URLModelKIOIMG.Text,
                image_size = int.Parse(tamanioIMG.Text),
                lime = limeAux
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

                if (limeAux == 1)
                {
                    MessageBox.Show("Almacenado en: https://storage.googleapis.com/imgs-mask/" + resultJSON.file);
                }
                
                //result.Text = resultHttp;

                if (resultJSON.result[0]["0"] == "fake")
                {
                    setFake();
                }
                else
                {
                    setReal();
                }

                generarPDF(URLKIOIMG.Text, "kerasioimg", resultJSON.result[0]["0"]);
            }
            else
            {
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

        private void generarPDF(string url, string servicio, string result, float perFake = -1, float perReal = -1)
        {
            string currentDateTime = DateTime.Now.ToString();
            var currentDateTimeMod = currentDateTime.Replace(@"/", "-").Replace(":", "-").Replace(" ","_");
            
            Document doc = new Document();
            var writer = PdfWriter.GetInstance(doc, new FileStream(servicio + "_" + currentDateTimeMod + ".pdf", FileMode.Create));
            doc.Open();

            Paragraph title = new Paragraph();
            title.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLUE);
            title.Add("Resultados del análisis");
            doc.Add(title);
            doc.Add(new Paragraph("\n"));

            doc.Add(new Paragraph("* Fecha: " + currentDateTime));
            doc.Add(new Paragraph("* URL: " + url));
            doc.Add(new Paragraph("* Algoritmo utilizado: " + servicio));
            doc.Add(new Paragraph("* Resultado: " + result));
            
            if(perFake != -1 && perReal != -1)
            {
                string[] captions = { "FAKE", "REAL" };
                double[] values = { perFake, perReal };
                var chartColors = new[] { Color.Red, Color.Green };
                var chart = new Models.PieChart(values, captions, chartColors);

                var canvas = writer.DirectContent;
                DrawPieChart(canvas, chart, 410, 730, 60);
            }

            doc.Close();
        }

        private void DrawPieChart(PdfContentByte canvas,
                   Models.PieChart chart,
                   float x0,
                   float y0,
                   float r = 50f,
                   bool showCaption = true,
                   iTextSharp.text.Font font = null)
        {

            if (chart.Values.Length != chart.Captions.Length)
            {
                return;
            }

            if (font == null)
            {
                font = FontFactory.GetFont(FontFactory.TIMES, 8);
            }

            canvas.SetLineWidth(0f);

            canvas.SetLineWidth(1f);
            var cRadius = (float)(r + 0.5);
            canvas.Circle(x0, y0, cRadius);
            canvas.SetColorStroke(BaseColor.GRAY);
            canvas.Stroke();

            canvas.SetLineWidth(0f);
            var rectX1 = x0 - r;
            var rectY1 = y0 - r;

            var xPoint = x0 + r;
            var yPoint = y0 + r;

            double startAngleDouble = 0;
            double angle = 0;

            var captionY = y0 + (chart.Values.Length - 1) * 6;

            for (var counter = 0; counter < chart.Values.Length; counter++)
            {
                double percentage = 0;
                if (chart.TotalValues > 0)
                    percentage = chart.Angles[counter] * 100 / 360;

                if (showCaption)
                {
                    //captions from here
                    canvas.SetColorStroke(chart.ChartColors[counter]);
                    canvas.SetColorFill(chart.ChartColors[counter]);
                    canvas.Rectangle(x0 + r + 10, captionY, 7, 7);
                    canvas.ClosePathFillStroke();

                    var percentageCaption = string.Format("{0:N}", percentage);
                    var text2 = new ColumnText(canvas);
                    var phrase = new Phrase(string.Format("{0} ({1}%)", chart.Captions[counter], percentageCaption), font);
                    text2.SetSimpleColumn(phrase, x0 + r + 20, captionY, x0 + r + 200, captionY, 0f, 0);
                    text2.Go();

                    captionY -= 12;
                    if ((int)percentage == 0)
                    {
                        continue;
                    }
                    //end of caption
                }

                if (chart.TotalValues <= 0)
                    continue;

                double y1Double;
                double x1Double;
                float startAngle = 0;
                double x2Double;
                double y2Double;
                float x1;
                float y1;
                float x2;
                float y2;
                if (percentage <= 50)
                {
                    //get coordinate on circle
                    x1Double = x0 + r * Math.Cos(startAngleDouble * Math.PI / 180);
                    y1Double = y0 + r * Math.Sin(startAngleDouble * Math.PI / 180);

                    x1 = (float)x1Double;
                    y1 = (float)y1Double;

                    angle += chart.Angles[counter];
                    x2Double = x0 + r * Math.Cos(angle * Math.PI / 180);
                    y2Double = y0 + r * Math.Sin(angle * Math.PI / 180);

                    x2 = (float)x2Double;
                    y2 = (float)y2Double;

                    startAngle = (float)startAngleDouble;

                    //set the colors to be used
                    canvas.SetColorStroke(chart.ChartColors[counter]);
                    canvas.SetColorFill(chart.ChartColors[counter]);

                    //draw the triangle within the circle
                    canvas.MoveTo(x0, y0);
                    canvas.LineTo(x1, y1);
                    canvas.LineTo(x2, y2);
                    canvas.LineTo(x0, y0);
                    canvas.ClosePathFillStroke();
                    //draw the arc
                    canvas.Arc(rectX1, rectY1, xPoint, yPoint, startAngle, (float)chart.Angles[counter]);
                    canvas.ClosePathFillStroke();
                    startAngleDouble += chart.Angles[counter];
                }
                else
                {
                    //DO THE FIRST PART
                    //get coordinate on circle
                    x1Double = x0 + r * Math.Cos(startAngleDouble * Math.PI / 180);
                    y1Double = y0 + r * Math.Sin(startAngleDouble * Math.PI / 180);
                    x1 = (float)x1Double;
                    y1 = (float)y1Double;

                    angle += 180;
                    x2Double = x0 + r * Math.Cos(angle * Math.PI / 180);
                    y2Double = y0 + r * Math.Sin(angle * Math.PI / 180);
                    x2 = (float)x2Double;
                    y2 = (float)y2Double;

                    startAngle = (float)startAngleDouble;

                    //set the colors to be used
                    canvas.SetColorStroke(chart.ChartColors[counter]);
                    canvas.SetColorFill(chart.ChartColors[counter]);

                    //draw the triangle within the circle
                    canvas.MoveTo(x0, y0);
                    canvas.LineTo(x1, y1);
                    canvas.LineTo(x2, y2);
                    canvas.LineTo(x0, y0);
                    canvas.ClosePathFillStroke();
                    //draw the arc
                    canvas.Arc(rectX1, rectY1, xPoint, yPoint, startAngle, 180);
                    canvas.ClosePathFillStroke();

                    //DO THE SECOND PART
                    //get coordinate on circle
                    x1Double = x0 + r * Math.Cos((startAngleDouble + 180) * Math.PI / 180);
                    y1Double = y0 + r * Math.Sin((startAngleDouble + 180) * Math.PI / 180);
                    x1 = (float)x1Double;
                    y1 = (float)y1Double;

                    angle += chart.Angles[counter] - 180;
                    x2Double = x0 + r * Math.Cos(angle * Math.PI / 180);
                    y2Double = y0 + r * Math.Sin(angle * Math.PI / 180);
                    x2 = (float)x2Double;
                    y2 = (float)y2Double;

                    startAngle = (float)startAngleDouble;

                    //set the colors to be used
                    canvas.SetColorStroke(chart.ChartColors[counter]);
                    canvas.SetColorFill(chart.ChartColors[counter]);

                    //draw the triangle within the circle
                    canvas.MoveTo(x0, y0);
                    canvas.LineTo(x1, y1);
                    canvas.LineTo(x2, y2);
                    canvas.LineTo(x0, y0);
                    canvas.ClosePathFillStroke();
                    //draw the arc
                    canvas.Arc(rectX1, rectY1, xPoint, yPoint, startAngle + 180, (float)(chart.Angles[counter] - 180));
                    canvas.ClosePathFillStroke();

                    startAngleDouble += chart.Angles[counter];
                }

            }
        }
    }
}
