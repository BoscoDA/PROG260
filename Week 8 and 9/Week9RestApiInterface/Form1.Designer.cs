namespace Week9RestApiInterface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_add = new Button();
            tb_fruit_name = new TextBox();
            tb_output = new TextBox();
            btn_delete = new Button();
            btn_get = new Button();
            btn_dailys = new Button();
            SuspendLayout();
            // 
            // btn_add
            // 
            btn_add.Location = new Point(142, 20);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(75, 23);
            btn_add.TabIndex = 0;
            btn_add.Text = "Add Fruit";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // tb_fruit_name
            // 
            tb_fruit_name.Location = new Point(23, 20);
            tb_fruit_name.Name = "tb_fruit_name";
            tb_fruit_name.Size = new Size(100, 23);
            tb_fruit_name.TabIndex = 1;
            // 
            // tb_output
            // 
            tb_output.Location = new Point(23, 60);
            tb_output.Multiline = true;
            tb_output.Name = "tb_output";
            tb_output.ReadOnly = true;
            tb_output.ScrollBars = ScrollBars.Both;
            tb_output.Size = new Size(223, 203);
            tb_output.TabIndex = 2;
            tb_output.TextChanged += tb_output_TextChanged;
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(223, 20);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(75, 23);
            btn_delete.TabIndex = 3;
            btn_delete.Text = "Delete Fruit";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // btn_get
            // 
            btn_get.Location = new Point(23, 281);
            btn_get.Name = "btn_get";
            btn_get.Size = new Size(75, 23);
            btn_get.TabIndex = 4;
            btn_get.Text = "Get Fruit";
            btn_get.UseVisualStyleBackColor = true;
            btn_get.Click += btn_get_Click;
            // 
            // btn_dailys
            // 
            btn_dailys.Location = new Point(109, 281);
            btn_dailys.Name = "btn_dailys";
            btn_dailys.Size = new Size(108, 23);
            btn_dailys.TabIndex = 5;
            btn_dailys.Text = "Get Daily Totals";
            btn_dailys.UseVisualStyleBackColor = true;
            btn_dailys.Click += btn_dailys_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(543, 418);
            Controls.Add(btn_dailys);
            Controls.Add(btn_get);
            Controls.Add(btn_delete);
            Controls.Add(tb_output);
            Controls.Add(tb_fruit_name);
            Controls.Add(btn_add);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_add;
        private TextBox tb_fruit_name;
        private TextBox tb_output;
        private Button btn_delete;
        private Button btn_get;
        private Button btn_dailys;
    }
}