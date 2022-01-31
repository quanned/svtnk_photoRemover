namespace catalog_mover
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.SelectFileBtn = new System.Windows.Forms.Button();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.pathFileL = new System.Windows.Forms.Label();
            this.photoFilesLB = new System.Windows.Forms.ListBox();
            this.rowCountL = new System.Windows.Forms.Label();
            this.columnCountL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.morePhotoFilesLB = new System.Windows.Forms.ListBox();
            this.MorePhotoCountL = new System.Windows.Forms.Label();
            this.TempLB = new System.Windows.Forms.ListBox();
            this.TempCountL = new System.Windows.Forms.Label();
            this.PhotoCountL = new System.Windows.Forms.Label();
            this.ModelsLB = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ModelsCountL = new System.Windows.Forms.Label();
            this.RemoveFileCountL = new System.Windows.Forms.Label();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TLB = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MorePhotoPathListLB = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectFileBtn
            // 
            this.SelectFileBtn.BackColor = System.Drawing.Color.Transparent;
            this.SelectFileBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SelectFileBtn.BackgroundImage")));
            this.SelectFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SelectFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectFileBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SelectFileBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.SelectFileBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.SelectFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectFileBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SelectFileBtn.Location = new System.Drawing.Point(345, 590);
            this.SelectFileBtn.Name = "SelectFileBtn";
            this.SelectFileBtn.Size = new System.Drawing.Size(194, 28);
            this.SelectFileBtn.TabIndex = 1;
            this.SelectFileBtn.Text = "import file";
            this.SelectFileBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SelectFileBtn.UseVisualStyleBackColor = false;
            this.SelectFileBtn.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // OFD
            // 
            this.OFD.FileName = "katalog_ru";
            this.OFD.Filter = "Excel files|*.xlsx";
            // 
            // pathFileL
            // 
            this.pathFileL.AutoSize = true;
            this.pathFileL.Location = new System.Drawing.Point(19, 566);
            this.pathFileL.Name = "pathFileL";
            this.pathFileL.Size = new System.Drawing.Size(68, 13);
            this.pathFileL.TabIndex = 2;
            this.pathFileL.Text = "path to file = ";
            // 
            // photoFilesLB
            // 
            this.photoFilesLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.photoFilesLB.FormattingEnabled = true;
            this.photoFilesLB.Location = new System.Drawing.Point(122, 34);
            this.photoFilesLB.Name = "photoFilesLB";
            this.photoFilesLB.Size = new System.Drawing.Size(143, 197);
            this.photoFilesLB.TabIndex = 3;
            // 
            // rowCountL
            // 
            this.rowCountL.AutoSize = true;
            this.rowCountL.Location = new System.Drawing.Point(19, 590);
            this.rowCountL.Name = "rowCountL";
            this.rowCountL.Size = new System.Drawing.Size(66, 13);
            this.rowCountL.TabIndex = 4;
            this.rowCountL.Text = "row count = ";
            // 
            // columnCountL
            // 
            this.columnCountL.AutoSize = true;
            this.columnCountL.Location = new System.Drawing.Point(19, 602);
            this.columnCountL.Name = "columnCountL";
            this.columnCountL.Size = new System.Drawing.Size(83, 13);
            this.columnCountL.TabIndex = 4;
            this.columnCountL.Text = "column count = ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Files list:";
            // 
            // morePhotoFilesLB
            // 
            this.morePhotoFilesLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.morePhotoFilesLB.FormattingEnabled = true;
            this.morePhotoFilesLB.Location = new System.Drawing.Point(22, 301);
            this.morePhotoFilesLB.Name = "morePhotoFilesLB";
            this.morePhotoFilesLB.Size = new System.Drawing.Size(214, 197);
            this.morePhotoFilesLB.TabIndex = 3;
            // 
            // MorePhotoCountL
            // 
            this.MorePhotoCountL.AutoSize = true;
            this.MorePhotoCountL.Location = new System.Drawing.Point(19, 514);
            this.MorePhotoCountL.Name = "MorePhotoCountL";
            this.MorePhotoCountL.Size = new System.Drawing.Size(71, 13);
            this.MorePhotoCountL.TabIndex = 4;
            this.MorePhotoCountL.Text = "MorePhoto = ";
            // 
            // TempLB
            // 
            this.TempLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TempLB.FormattingEnabled = true;
            this.TempLB.Location = new System.Drawing.Point(285, 34);
            this.TempLB.Name = "TempLB";
            this.TempLB.Size = new System.Drawing.Size(652, 197);
            this.TempLB.TabIndex = 3;
            // 
            // TempCountL
            // 
            this.TempCountL.AutoSize = true;
            this.TempCountL.Location = new System.Drawing.Point(282, 247);
            this.TempCountL.Name = "TempCountL";
            this.TempCountL.Size = new System.Drawing.Size(41, 13);
            this.TempCountL.TabIndex = 4;
            this.TempCountL.Text = "Path = ";
            // 
            // PhotoCountL
            // 
            this.PhotoCountL.AutoSize = true;
            this.PhotoCountL.Location = new System.Drawing.Point(119, 247);
            this.PhotoCountL.Name = "PhotoCountL";
            this.PhotoCountL.Size = new System.Drawing.Size(47, 13);
            this.PhotoCountL.TabIndex = 4;
            this.PhotoCountL.Text = "Photo = ";
            // 
            // ModelsLB
            // 
            this.ModelsLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModelsLB.FormattingEnabled = true;
            this.ModelsLB.Location = new System.Drawing.Point(22, 34);
            this.ModelsLB.Name = "ModelsLB";
            this.ModelsLB.Size = new System.Drawing.Size(80, 197);
            this.ModelsLB.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Models list:";
            // 
            // ModelsCountL
            // 
            this.ModelsCountL.AutoSize = true;
            this.ModelsCountL.Location = new System.Drawing.Point(19, 247);
            this.ModelsCountL.Name = "ModelsCountL";
            this.ModelsCountL.Size = new System.Drawing.Size(48, 13);
            this.ModelsCountL.TabIndex = 4;
            this.ModelsCountL.Text = "Model = ";
            // 
            // RemoveFileCountL
            // 
            this.RemoveFileCountL.AutoSize = true;
            this.RemoveFileCountL.Location = new System.Drawing.Point(813, 590);
            this.RemoveFileCountL.Name = "RemoveFileCountL";
            this.RemoveFileCountL.Size = new System.Drawing.Size(54, 13);
            this.RemoveFileCountL.TabIndex = 8;
            this.RemoveFileCountL.Text = "Progress: ";
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 1000;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(862, 585);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Path list:";
            // 
            // TLB
            // 
            this.TLB.FormattingEnabled = true;
            this.TLB.Location = new System.Drawing.Point(256, 299);
            this.TLB.Name = "TLB";
            this.TLB.Size = new System.Drawing.Size(207, 199);
            this.TLB.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Split path list:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "MorePhoto\'s files list:";
            // 
            // MorePhotoPathListLB
            // 
            this.MorePhotoPathListLB.FormattingEnabled = true;
            this.MorePhotoPathListLB.Location = new System.Drawing.Point(487, 299);
            this.MorePhotoPathListLB.Name = "MorePhotoPathListLB";
            this.MorePhotoPathListLB.Size = new System.Drawing.Size(450, 199);
            this.MorePhotoPathListLB.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(484, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "MorePhoto path list:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(484, 514);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Path = ";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(957, 630);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MorePhotoPathListLB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TLB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RemoveFileCountL);
            this.Controls.Add(this.ModelsLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.columnCountL);
            this.Controls.Add(this.TempCountL);
            this.Controls.Add(this.ModelsCountL);
            this.Controls.Add(this.PhotoCountL);
            this.Controls.Add(this.MorePhotoCountL);
            this.Controls.Add(this.rowCountL);
            this.Controls.Add(this.TempLB);
            this.Controls.Add(this.morePhotoFilesLB);
            this.Controls.Add(this.photoFilesLB);
            this.Controls.Add(this.pathFileL);
            this.Controls.Add(this.SelectFileBtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "remove catalog photos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.Label pathFileL;
        private System.Windows.Forms.ListBox photoFilesLB;
        private System.Windows.Forms.Label rowCountL;
        private System.Windows.Forms.Label columnCountL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox morePhotoFilesLB;
        private System.Windows.Forms.Label MorePhotoCountL;
        private System.Windows.Forms.ListBox TempLB;
        private System.Windows.Forms.Label TempCountL;
        private System.Windows.Forms.Label PhotoCountL;
        private System.Windows.Forms.ListBox ModelsLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ModelsCountL;
        private System.Windows.Forms.Label RemoveFileCountL;
        public System.Windows.Forms.Button SelectFileBtn;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ListBox TLB;
        public System.Windows.Forms.ListBox MorePhotoPathListLB;
        private System.Windows.Forms.Label label7;
    }
}

