using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AddYouTubeVideo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveNameToFolder = new SaveFileDialog();
            if (!File.Exists(@"C:\AddedVideoFiles\YouTubeVideoNames.txt"))
            {
                Directory.CreateDirectory(@"C:\AddedVideoFiles");
                File.Create(@"C:\AddedVideoFiles\YouTubeVideoNames.txt");
                
            }
            if (!File.Exists(@"C:\AddedVideoFiles\YouTubeVideoAddress.txt"))
            {
                File.Create(@"C:\AddedVideoFiles\YouTubeVideoAddress.txt");
            }
            
            saveNameToFolder.FileName = @"C:\AddedVideoFiles\YouTubeVideoNames.txt";
            string nameFolder = saveNameToFolder.FileName;
            saveNameToFolder.Filter = "Text File |*.txt";


            if (txtBxName.Text != "" && txtBxAddress.Text != "")
            {
                using (StreamWriter swName = File.AppendText(nameFolder))
                {
                    swName.WriteLine(txtBxName.Text.ToString());
                    swName.Flush();
                }

            }


            SaveFileDialog saveAddressToFolder = new SaveFileDialog();

            saveAddressToFolder.FileName = @"C:\AddedVideoFiles\YouTubeVideoAddress.txt";
            string addressFolder = saveAddressToFolder.FileName;
            saveAddressToFolder.Filter = "Text File |*.txt";

            if (txtBxName.Text != "" && txtBxAddress.Text != "")
            {
                using (StreamWriter swAddress = File.AppendText(addressFolder))
                {
                    string newAddress = txtBxAddress.Text.Replace("watch?v=", "v/");
                    swAddress.WriteLine(newAddress.ToString());
                    swAddress.Flush();
                }
            }

            txtBxAddress.Text = "";
            txtBxName.Text = "";
            

        }
    }
}
