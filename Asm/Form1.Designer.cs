namespace Asm
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
            int coreCount = (Environment.ProcessorCount)/2;
            
        pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            Upload = new Button();
            Save = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            Blur = new Button();
            trackBar1 = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            radioButton3 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(26, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(343, 201);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(429, 27);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(343, 201);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // Upload
            // 
            Upload.Location = new Point(26, 234);
            Upload.Name = "Upload";
            Upload.Size = new Size(107, 36);
            Upload.TabIndex = 2;
            Upload.Text = "Upload";
            Upload.UseVisualStyleBackColor = true;
            Upload.Click += button1_Click;
            // 
            // Save
            // 
            Save.Location = new Point(665, 234);
            Save.Name = "Save";
            Save.Size = new Size(107, 36);
            Save.TabIndex = 3;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(26, 302);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(35, 23);
            textBox1.TabIndex = 4;
            textBox1.Text = "1";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(67, 302);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(35, 23);
            textBox2.TabIndex = 5;
            textBox2.Text = "1";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(108, 302);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(35, 23);
            textBox3.TabIndex = 6;
            textBox3.Text = "1";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(26, 331);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(35, 23);
            textBox4.TabIndex = 7;
            textBox4.Text = "1";
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(67, 331);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(35, 23);
            textBox5.TabIndex = 8;
            textBox5.Text = "1";
            textBox5.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(108, 331);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(35, 23);
            textBox6.TabIndex = 9;
            textBox6.Text = "1";
            textBox6.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(26, 360);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(35, 23);
            textBox7.TabIndex = 10;
            textBox7.Text = "1";
            textBox7.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(67, 360);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(35, 23);
            textBox8.TabIndex = 11;
            textBox8.Text = "1";
            textBox8.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(108, 360);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(35, 23);
            textBox9.TabIndex = 12;
            textBox9.Text = "1";
            textBox9.TextAlign = HorizontalAlignment.Center;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(678, 303);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(105, 19);
            radioButton1.TabIndex = 13;
            radioButton1.Text = "ASEMBLER DLL";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(678, 328);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(40, 19);
            radioButton2.TabIndex = 14;
            radioButton2.TabStop = true;
            radioButton2.Text = "C#";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // Blur
            // 
            Blur.Location = new Point(360, 234);
            Blur.Name = "Blur";
            Blur.Size = new Size(75, 23);
            Blur.TabIndex = 15;
            Blur.Text = "Blur";
            Blur.UseVisualStyleBackColor = true;
            Blur.Click += button1_Click_1;
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 1;
            trackBar1.Location = new Point(304, 278);
            trackBar1.Maximum = 64;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(188, 45);
            trackBar1.TabIndex = 16;
            trackBar1.Value = coreCount;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(350, 260);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 17;
            label1.Text = "Threads";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(643, 411);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 18;
            label2.Text = "Time:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 284);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 19;
            label3.Text = "Blur Mask";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(678, 353);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(72, 19);
            radioButton3.TabIndex = 20;
            radioButton3.Text = "C++ DLL";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 458);
            Controls.Add(radioButton3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(trackBar1);
            Controls.Add(Blur);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(textBox9);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(Save);
            Controls.Add(Upload);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button Upload;
        private Button Save;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button Blur;
        private TrackBar trackBar1;
        private Label label1;
        private Label label2;
        private Label label3;
        private RadioButton radioButton3;
    }
}