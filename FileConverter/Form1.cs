using FileConverter.FileConverterService;
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

namespace FileConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName;
            }
            else
                return;
            
            IFileConverterService service = new FileConverterServiceClient();
            string content = File.ReadAllText(openFileDialog1.FileName);
            FileModel model = new FileModel
            {
                Name = openFileDialog1.FileName,
                Content = content
            };
            var resultFile = service.ConvertToCSV(model);
            File.WriteAllText(resultFile.Name , resultFile.Content);
            
            
        }
    }
}
