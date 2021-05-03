using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace ImageToTextLibrary
{
    public class Converter
    {
        public string DetectText(string imgPath)
        {
            string text;
            using (var img = new Image<Bgr, byte>(imgPath))
            {
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\tessdata\";
                // Языковые пакеты: https://github.com/tesseract-ocr/tessdata
                using (var ocrProvider = new Tesseract(path, "rus", OcrEngineMode.TesseractLstmCombined))
                {
                    ocrProvider.SetImage(img);
                    ocrProvider.Recognize();
                    text = ocrProvider.GetUTF8Text().TrimEnd();
                }
            }
            return text;
        }

        public bool DetectFace(string path)
        {
            /*
            var HaarCascadeXML = new HaarCascade("haarcascade_frontalface_alt.xml");
            var faces = HaarCascadeXML.Detect(face, 1.1, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                              new Size(20, 20), new Size(BaseImage.Width, BaseImage.Height));
            */
            return true;
        }
    }
}
