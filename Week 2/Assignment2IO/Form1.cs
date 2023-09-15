using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        /// <summary>
        /// returns the name of the file found at the inputted filepath
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string ReadFileName(string filePath)
        {
            string output = String.Empty;

            FileInfo FileProps = new FileInfo(filePath);

            output = FileProps.Name;

            return output;
        }
        
        /// <summary>
        /// Reads the file found at the inputted filepath and enters each character into a dictionary paired with its frequency in the file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
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
                    if (c != ' ')
                    {
                        charCounts.Add(c, 1);
                    }

                }
            }

            return charCounts;
        }

        /// <summary>
        /// Outputs each file in the filepath box name and character frequency
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_parse_Click(object sender, EventArgs e)
        {
            lb_output.Items.Clear();

            if (lb_filepaths.Items.Count > 0)
            {
                foreach (var file in lb_filepaths.Items)
                {
                    lb_output.Items.Add($"{ReadFileName(file.ToString())}{Environment.NewLine}");
                    GetCharacterCounts(file.ToString()).ToList().ForEach(x => lb_output.Items.Add($"{x.Key}: {x.Value}"));
                }
            }
            else
            {
                lb_output.Items.Add("No files select!");
            }

        }

        /// <summary>
        /// Adds a file to the list box to be parsed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (lb_filepaths.Items.Contains(textBox1.Text))
            {
                MessageBox.Show("File already added to the parse list!");
            }
            else
            {
                try
                {
                    //if the creation of this string reader throws an exception then the inputted file path is invalid and should not be accepted.
                    StreamReader reader = new StreamReader(textBox1.Text);

                    lb_filepaths.Items.Add(textBox1.Text);
                    MessageBox.Show("File added to the parse list");
                }
                catch
                {
                    MessageBox.Show("Invalid file path entered!");
                }

            }

            textBox1.Text = string.Empty;
        }

        /// <summary>
        /// Clears the list box which outputs the filepaths to be parsed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clear_Click(object sender, EventArgs e)
        {
            lb_filepaths.Items.Clear();
            textBox1.Text = string.Empty;
        }

        /// <summary>
        /// Removes the filepath inputted into the textbox from the list to be parsed if it is already added.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (lb_filepaths.Items.Contains(textBox1.Text))
            {
                lb_filepaths.Items.Remove(textBox1.Text);
                MessageBox.Show("File removed from the parse list!");
            }
            else
            {
                MessageBox.Show($"\"{textBox1.Text}\" was not found in the file list!");
            }

            textBox1.Text = string.Empty;
        }

    }
}
