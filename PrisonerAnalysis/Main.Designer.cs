﻿namespace PrisonerAnalysis
{
    partial class Main
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
            dataGridView = new DataGridView();
            btnClose = new Button();
            label1 = new Label();
            lblSeventyTwoHours = new Label();
            label3 = new Label();
            lblThirtyDays = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(11, 22);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(985, 317);
            dataGridView.TabIndex = 0;
            dataGridView.DataSourceChanged += dataGridView_DataSourceChanged;
            dataGridView.ColumnHeaderMouseClick += dataGridView_ColumnHeaderMouseClick;
            dataGridView.Sorted += dataGridView_Sorted;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(921, 406);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(496, 385);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 2;
            label1.Text = "> 72 hrs";
            // 
            // lblSeventyTwoHours
            // 
            lblSeventyTwoHours.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblSeventyTwoHours.AutoSize = true;
            lblSeventyTwoHours.Location = new Point(560, 385);
            lblSeventyTwoHours.Name = "lblSeventyTwoHours";
            lblSeventyTwoHours.Size = new Size(38, 15);
            lblSeventyTwoHours.TabIndex = 3;
            lblSeventyTwoHours.Text = "label2";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(737, 385);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 4;
            label3.Text = "> 30 days";
            // 
            // lblThirtyDays
            // 
            lblThirtyDays.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblThirtyDays.AutoSize = true;
            lblThirtyDays.Location = new Point(801, 385);
            lblThirtyDays.Name = "lblThirtyDays";
            lblThirtyDays.Size = new Size(38, 15);
            lblThirtyDays.TabIndex = 5;
            lblThirtyDays.Text = "label4";
            // 
            // Main
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 450);
            Controls.Add(lblThirtyDays);
            Controls.Add(label3);
            Controls.Add(lblSeventyTwoHours);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(dataGridView);
            Name = "Main";
            Text = "Prisoner Analysis";
            DragDrop += Main_DragDrop;
            DragOver += Main_DragOver;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Button btnClose;
        private Label label1;
        private Label lblSeventyTwoHours;
        private Label label3;
        private Label lblThirtyDays;
    }
}