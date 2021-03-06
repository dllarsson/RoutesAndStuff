﻿namespace FormsApp
{
    partial class FormRouteCity
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
            this.lblNumberOfVertices = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStartNode = new System.Windows.Forms.TextBox();
            this.tbEndNode = new System.Windows.Forms.TextBox();
            this.EndNode = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.drawArea = new System.Windows.Forms.Panel();
            this.lblVerticesNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumberOfVertices
            // 
            this.lblNumberOfVertices.AutoSize = true;
            this.lblNumberOfVertices.Location = new System.Drawing.Point(13, 12);
            this.lblNumberOfVertices.Name = "lblNumberOfVertices";
            this.lblNumberOfVertices.Size = new System.Drawing.Size(99, 13);
            this.lblNumberOfVertices.TabIndex = 3;
            this.lblNumberOfVertices.Text = "Number of vertices:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 484);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(216, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "StartNode:";
            // 
            // tbStartNode
            // 
            this.tbStartNode.Location = new System.Drawing.Point(12, 225);
            this.tbStartNode.Name = "tbStartNode";
            this.tbStartNode.Size = new System.Drawing.Size(216, 20);
            this.tbStartNode.TabIndex = 6;
            // 
            // tbEndNode
            // 
            this.tbEndNode.Location = new System.Drawing.Point(12, 275);
            this.tbEndNode.Name = "tbEndNode";
            this.tbEndNode.Size = new System.Drawing.Size(216, 20);
            this.tbEndNode.TabIndex = 8;
            // 
            // EndNode
            // 
            this.EndNode.AutoSize = true;
            this.EndNode.Location = new System.Drawing.Point(12, 258);
            this.EndNode.Name = "EndNode";
            this.EndNode.Size = new System.Drawing.Size(55, 13);
            this.EndNode.TabIndex = 7;
            this.EndNode.Text = "EndNode:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 302);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(216, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search path";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbResult
            // 
            this.tbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbResult.Location = new System.Drawing.Point(12, 332);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(216, 146);
            this.tbResult.TabIndex = 10;
            // 
            // trackBar
            // 
            this.trackBar.LargeChange = 1;
            this.trackBar.Location = new System.Drawing.Point(12, 28);
            this.trackBar.Maximum = 5;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(216, 45);
            this.trackBar.TabIndex = 11;
            this.trackBar.Value = 5;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // drawArea
            // 
            this.drawArea.Location = new System.Drawing.Point(234, 12);
            this.drawArea.Name = "drawArea";
            this.drawArea.Size = new System.Drawing.Size(1138, 687);
            this.drawArea.TabIndex = 12;
            // 
            // lblVerticesNumber
            // 
            this.lblVerticesNumber.AutoSize = true;
            this.lblVerticesNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerticesNumber.Location = new System.Drawing.Point(63, 76);
            this.lblVerticesNumber.Name = "lblVerticesNumber";
            this.lblVerticesNumber.Size = new System.Drawing.Size(99, 108);
            this.lblVerticesNumber.TabIndex = 13;
            this.lblVerticesNumber.Text = "0";
            // 
            // FormRouteCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 711);
            this.Controls.Add(this.lblVerticesNumber);
            this.Controls.Add(this.drawArea);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbEndNode);
            this.Controls.Add(this.EndNode);
            this.Controls.Add(this.tbStartNode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblNumberOfVertices);
            this.Name = "FormRouteCity";
            this.Text = "ROUTE CITY";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            

        }

        #endregion
        private System.Windows.Forms.Label lblNumberOfVertices;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStartNode;
        private System.Windows.Forms.TextBox tbEndNode;
        private System.Windows.Forms.Label EndNode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Panel drawArea;
        private System.Windows.Forms.Label lblVerticesNumber;
    }
}

