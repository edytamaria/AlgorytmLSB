namespace AlgorytmLSB
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Insert = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.readFileBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.key = new System.Windows.Forms.RichTextBox();
            this.insertMessage = new System.Windows.Forms.Button();
            this.message1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.message2 = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(30, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 350);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Images";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(351, 33);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 300);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(21, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(21, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Choose File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Insert
            // 
            this.Insert.Location = new System.Drawing.Point(111, 25);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(75, 24);
            this.Insert.TabIndex = 2;
            this.Insert.Text = "Insert";
            this.Insert.UseVisualStyleBackColor = true;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(591, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 21);
            this.button3.TabIndex = 10;
            this.button3.Text = "Decode Message";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // readFileBox
            // 
            this.readFileBox.Location = new System.Drawing.Point(21, 55);
            this.readFileBox.Name = "readFileBox";
            this.readFileBox.Size = new System.Drawing.Size(165, 20);
            this.readFileBox.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.key);
            this.groupBox3.Controls.Add(this.insertMessage);
            this.groupBox3.Controls.Add(this.message1);
            this.groupBox3.Location = new System.Drawing.Point(267, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 160);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Coding";
            // 
            // key
            // 
            this.key.Location = new System.Drawing.Point(6, 79);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(260, 22);
            this.key.TabIndex = 9;
            this.key.Text = "";
            this.key.TextChanged += new System.EventHandler(this.key_TextChanged);
            // 
            // insertMessage
            // 
            this.insertMessage.Location = new System.Drawing.Point(6, 131);
            this.insertMessage.Name = "insertMessage";
            this.insertMessage.Size = new System.Drawing.Size(112, 23);
            this.insertMessage.TabIndex = 8;
            this.insertMessage.Text = "Insert Message";
            this.insertMessage.UseVisualStyleBackColor = true;
            this.insertMessage.Click += new System.EventHandler(this.insertMessage_Click);
            // 
            // message1
            // 
            this.message1.Location = new System.Drawing.Point(6, 19);
            this.message1.Name = "message1";
            this.message1.Size = new System.Drawing.Size(260, 46);
            this.message1.TabIndex = 1;
            this.message1.Text = "";
            this.message1.TextChanged += new System.EventHandler(this.message1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.readFileBox);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.Insert);
            this.groupBox2.Location = new System.Drawing.Point(30, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Insert Image";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.message2);
            this.groupBox4.Location = new System.Drawing.Point(584, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(273, 100);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Decoding";
            // 
            // message2
            // 
            this.message2.Location = new System.Drawing.Point(7, 46);
            this.message2.Name = "message2";
            this.message2.Size = new System.Drawing.Size(247, 46);
            this.message2.TabIndex = 9;
            this.message2.Text = "";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(726, 436);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(179, 56);
            this.button4.TabIndex = 11;
            this.button4.Text = "Save New Image";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 557);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox readFileBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox key;
        private System.Windows.Forms.Button insertMessage;
        private System.Windows.Forms.RichTextBox message1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox message2;
        private System.Windows.Forms.Button button4;
    }
}

