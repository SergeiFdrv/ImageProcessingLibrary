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
        public static string DetectText(string imgPath)
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

        public static Rectangle[] DetectFace(string imgPath)
        {
            string haar = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\haarcascades\";
            using var faceCascadeClassifier = new CascadeClassifier(haar + @"haarcascade_frontalface_default.xml");
            // Файлы каскадов: https://github.com/opencv/opencv/tree/master/data/haarcascades
            using Image<Gray, byte> grayscaleImage = new Image<Gray, byte>(imgPath);
            grayscaleImage._EqualizeHist();
            var facesDetected = faceCascadeClassifier.DetectMultiScale(grayscaleImage, minNeighbors: 2);

            return facesDetected;
        }
    }
}
