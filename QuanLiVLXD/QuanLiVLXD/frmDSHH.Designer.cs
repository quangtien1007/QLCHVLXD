﻿namespace QuanLiVLXD
{
    partial class frmDSHH
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgDSHH = new System.Windows.Forms.DataGridView();
            this.btnIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDSHH)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 39);
            this.label1.TabIndex = 13;
            this.label1.Text = "THỐNG KÊ HÀNG HÓA";
            // 
            // dgDSHH
            // 
            this.dgDSHH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDSHH.Location = new System.Drawing.Point(131, 103);
            this.dgDSHH.Name = "dgDSHH";
            this.dgDSHH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDSHH.Size = new System.Drawing.Size(882, 461);
            this.dgDSHH.TabIndex = 12;
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(131, 69);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(84, 28);
            this.btnIn.TabIndex = 11;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frmDSHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1892, 896);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgDSHH);
            this.Controls.Add(this.btnIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDSHH";
            this.Text = "frmDSHH";
            this.Load += new System.EventHandler(this.frmDSHH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDSHH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgDSHH;
        private System.Windows.Forms.Button btnIn;
    }
}