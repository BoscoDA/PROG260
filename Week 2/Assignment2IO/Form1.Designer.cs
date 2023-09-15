namespace Assignment2IO
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_parse = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lb_output = new System.Windows.Forms.ListBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.lb_filepaths = new System.Windows.Forms.ListBox();
            this.btn_remove = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_parse
            // 
            this.btn_parse.Location = new System.Drawing.Point(12, 245);
            this.btn_parse.Name = "btn_parse";
            this.btn_parse.Size = new System.Drawing.Size(75, 23);
            this.btn_parse.TabIndex = 0;
            this.btn_parse.Text = "Parse Files";
            this.btn_parse.UseVisualStyleBackColor = true;
            this.btn_parse.Click += new System.EventHandler(this.btn_parse_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 20);
            this.textBox1.TabIndex = 1;
            // 
            // lb_output
            // 
            this.lb_output.FormattingEnabled = true;
            this.lb_output.Location = new System.Drawing.Point(430, 75);
            this.lb_output.Name = "lb_output";
            this.lb_output.Size = new System.Drawing.Size(345, 290);
            this.lb_output.TabIndex = 2;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(241, 76);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(56, 23);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lb_filepaths
            // 
            this.lb_filepaths.FormattingEnabled = true;
            this.lb_filepaths.Location = new System.Drawing.Point(12, 105);
            this.lb_filepaths.Name = "lb_filepaths";
            this.lb_filepaths.Size = new System.Drawing.Size(294, 134);
            this.lb_filepaths.TabIndex = 4;
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(303, 75);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(56, 23);
            this.btn_remove.TabIndex = 5;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(231, 245);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.lb_filepaths);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lb_output);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_parse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_parse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox lb_output;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ListBox lb_filepaths;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Button button4;
    }
}

