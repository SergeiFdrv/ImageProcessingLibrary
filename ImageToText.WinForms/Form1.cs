using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToText.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ~Form1()
        {
            Graphics.Dispose();
            Pen.Dispose();
            OFD.Dispose();
        }

        private readonly OpenFileDialog OFD = new()
        {
            Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        };

        private Graphics Graphics;

        private Image _Image;

        private Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                pictureBox1.Image = _Image = value;
                Graphics = Graphics.FromImage(_Image);
            }
        }

        private readonly Pen Pen = new(Color.Red, 4);

        private void button1_Click(object sender, EventArgs e)
        {
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                Image = Image.FromFile(OFD.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Image == null) button1_Click(sender, e);
            MessageBox.Show(ImageToTextLibrary.Converter.DetectText(OFD.FileName));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Image == null) button1_Click(sender, e);
            var res = ImageToTextLibrary.Converter.DetectFace(OFD.FileName);
            Rectangle rectangle;
            foreach (Rectangle rect in res)
            {
                rectangle = new Rectangle(
                    rect.X,
                    rect.Y,
                    rect.Width,
                    rect.Height
                    );
                Graphics.DrawRectangle(Pen, rectangle);
            }
            pictureBox1.Image = Image;
            MessageBox.Show(res.Length.ToString());
        }
    }
}
