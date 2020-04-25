using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;

namespace VideoDownload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //verificação de mp3 ou mp4
            if (radioBtnMP3.Checked)
            {
                DownloadMP3();
            }
            else if (radioBtnMP4.Checked)
            {
                DownloadMP4();
            }
        }

        private void DownloadMP4()
        {
            try
            {
                string link = txturl.Text;
                if (link == "")
                {
                    MessageBox.Show("Link Nulo");
                }
                var youtube = YouTube.Default;
                var video   = youtube.GetVideo(link);
                File.WriteAllBytes(@"D:\" + video.FullName, video.GetBytes());
            }
            catch (Exception)
            {
                MessageBox.Show("Erro Inesperado", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DownloadMP3()
        {
            try
            {
                string link = txturl.Text;
                if (link == "")
                {
                    MessageBox.Show("Link Nulo","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                var youtube = YouTube.Default;
                var video   = youtube.GetVideo(link);
                File.WriteAllBytes(@"D:\" + video.FullName + ".mp3", video.GetBytes());
            }
            catch (Exception)
            {
                MessageBox.Show("Erro Inesperado","ALERTA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
