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

        private Dictionary<char, int> GetCharacterCounts(string filePath)
        {
            Dictionary<char, int> charCounts = new Dictionary<char, int>();

            StreamReader reader = new StreamReader(filePath);
            string file = reader.ReadToEnd();

            file = Utilities.RemoveWhiteSpace(file);

            file = Utilities.RemoveEscapeChars(file);

            foreach (char c in file)
            {
                if ((charCounts.ContainsKey(c) == true) && (c != ' '))
                {
                    charCounts[c]++;
                }
                else
                {
                    if(c != ' ')
                    {
                        charCounts.Add(c, 1);
                    }
                    
                }
            }
            reader.Close();

            return charCounts;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add($"{ReadFileName(textBox1.Text)}{Environment.NewLine}");
            GetCharacterCounts(textBox1.Text).ToList().ForEach(x => listBox1.Items.Add($"{x.Key}: {x.Value}"));
        }
    }
}
