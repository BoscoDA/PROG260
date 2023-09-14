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

namespace Assignment2IO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string ReadFileName(string filePath)
        {
            string output = String.Empty;

            FileInfo FileProps = new FileInfo(filePath);

            output = FileProps.Name;

            return output;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ReadFileName(textBox1.Text));
        }
    }
}
