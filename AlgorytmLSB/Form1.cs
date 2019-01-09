using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace AlgorytmLSB
{
    public partial class Form1 : Form
    {

        public string imagePath { get; set; }
        public string messageToCode { get; set; }
        public Bitmap firstImage { get; set; }
        public string keyH { get; set; }
        public Bitmap secondImage { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertImage insertImage = new InsertImage();
            string path = insertImage.GetImagePath();
            readFileBox.Text = path;
            this.imagePath = path;
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            this.firstImage = new Bitmap(this.imagePath);
            pictureBox1.Image = this.firstImage;
        }

        private void insertMessage_Click(object sender, EventArgs e)
        {
            byte[] Key = Encoding.ASCII.GetBytes(this.keyH);
            Coding coding = new Coding();
            this.secondImage = coding.CodingMessage(this.messageToCode, this.firstImage, this.keyH);
            pictureBox2.Image = this.secondImage;
        }

        private void message1_TextChanged(object sender, EventArgs e)
        {
            this.messageToCode = message1.Text;
        }

        private void key_TextChanged(object sender, EventArgs e)
        {
            this.keyH = key.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Coding decode = new Coding();

            this.message2.Text = decode.DecodeMessage(this.secondImage, this.keyH);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
