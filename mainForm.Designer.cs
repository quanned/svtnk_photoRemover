﻿namespace catalog_mover
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.exitBtn = new System.Windows.Forms.Button();
            this.SelectFileBtn = new System.Windows.Forms.Button();
            this.opf = new System.Windows.Forms.OpenFileDialog();
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
            this.MoveBtn = new System.Windows.Forms.Button();
            this.RemoveFileCountL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.White;
            this.exitBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitBtn.BackgroundImage")));
            this.exitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.exitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Location = new System.Drawing.Point(772, 2);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(28, 27);
            this.exitBtn.TabIndex = 0;
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // SelectFileBtn
            // 
            this.SelectFileBtn.Location = new System.Drawing.Point(20, 281);
            this.SelectFileBtn.Name = "SelectFileBtn";
            this.SelectFileBtn.Size = new System.Drawing.Size(82, 23);
            this.SelectFileBtn.TabIndex = 1;
            this.SelectFileBtn.Text = "select file";
            this.SelectFileBtn.UseVisualStyleBackColor = true;
            this.SelectFileBtn.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // opf
            // 
            this.opf.FileName = "openFileDialog1";
            this.opf.Filter = "Excel files|*.xlsx";
            // 
            // pathFileL
            // 
            this.pathFileL.AutoSize = true;
            this.pathFileL.Location = new System.Drawing.Point(19, 320);
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
            this.photoFilesLB.Size = new System.Drawing.Size(143, 210);
            this.photoFilesLB.TabIndex = 3;
            // 
            // rowCountL
            // 
            this.rowCountL.AutoSize = true;
            this.rowCountL.Location = new System.Drawing.Point(19, 351);
            this.rowCountL.Name = "rowCountL";
            this.rowCountL.Size = new System.Drawing.Size(66, 13);
            this.rowCountL.TabIndex = 4;
            this.rowCountL.Text = "row count = ";
            // 
            // columnCountL
            // 
            this.columnCountL.AutoSize = true;
            this.columnCountL.Location = new System.Drawing.Point(19, 367);
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
            this.morePhotoFilesLB.Location = new System.Drawing.Point(283, 34);
            this.morePhotoFilesLB.Name = "morePhotoFilesLB";
            this.morePhotoFilesLB.Size = new System.Drawing.Size(157, 210);
            this.morePhotoFilesLB.TabIndex = 3;
            // 
            // MorePhotoCountL
            // 
            this.MorePhotoCountL.AutoSize = true;
            this.MorePhotoCountL.Location = new System.Drawing.Point(280, 247);
            this.MorePhotoCountL.Name = "MorePhotoCountL";
            this.MorePhotoCountL.Size = new System.Drawing.Size(46, 13);
            this.MorePhotoCountL.TabIndex = 4;
            this.MorePhotoCountL.Text = "count = ";
            // 
            // TempLB
            // 
            this.TempLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TempLB.FormattingEnabled = true;
            this.TempLB.Location = new System.Drawing.Point(457, 34);
            this.TempLB.Name = "TempLB";
            this.TempLB.Size = new System.Drawing.Size(331, 210);
            this.TempLB.TabIndex = 3;
            // 
            // TempCountL
            // 
            this.TempCountL.AutoSize = true;
            this.TempCountL.Location = new System.Drawing.Point(454, 247);
            this.TempCountL.Name = "TempCountL";
            this.TempCountL.Size = new System.Drawing.Size(46, 13);
            this.TempCountL.TabIndex = 4;
            this.TempCountL.Text = "count = ";
            // 
            // PhotoCountL
            // 
            this.PhotoCountL.AutoSize = true;
            this.PhotoCountL.Location = new System.Drawing.Point(119, 247);
            this.PhotoCountL.Name = "PhotoCountL";
            this.PhotoCountL.Size = new System.Drawing.Size(46, 13);
            this.PhotoCountL.TabIndex = 4;
            this.PhotoCountL.Text = "count = ";
            // 
            // ModelsLB
            // 
            this.ModelsLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModelsLB.FormattingEnabled = true;
            this.ModelsLB.Location = new System.Drawing.Point(22, 34);
            this.ModelsLB.Name = "ModelsLB";
            this.ModelsLB.Size = new System.Drawing.Size(80, 210);
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
            this.ModelsCountL.Size = new System.Drawing.Size(40, 13);
            this.ModelsCountL.TabIndex = 4;
            this.ModelsCountL.Text = "ount = ";
            // 
            // MoveBtn
            // 
            this.MoveBtn.Location = new System.Drawing.Point(343, 341);
            this.MoveBtn.Name = "MoveBtn";
            this.MoveBtn.Size = new System.Drawing.Size(75, 23);
            this.MoveBtn.TabIndex = 7;
            this.MoveBtn.Text = "MOVE IT";
            this.MoveBtn.UseVisualStyleBackColor = true;
            this.MoveBtn.Click += new System.EventHandler(this.MoveBtn_Click);
            // 
            // RemoveFileCountL
            // 
            this.RemoveFileCountL.AutoSize = true;
            this.RemoveFileCountL.Location = new System.Drawing.Point(598, 341);
            this.RemoveFileCountL.Name = "RemoveFileCountL";
            this.RemoveFileCountL.Size = new System.Drawing.Size(0, 13);
            this.RemoveFileCountL.TabIndex = 8;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.exitBtn;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.RemoveFileCountL);
            this.Controls.Add(this.MoveBtn);
            this.Controls.Add(this.ModelsLB);
            this.Controls.Add(this.label2);
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
            this.Controls.Add(this.exitBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "remove catalog photos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button SelectFileBtn;
        private System.Windows.Forms.OpenFileDialog opf;
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
        private System.Windows.Forms.Button MoveBtn;
        private System.Windows.Forms.Label RemoveFileCountL;
    }
}

