namespace FormsApp
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
            this.drawArea = new System.Windows.Forms.PictureBox();
            this.brnGenerateGraph = new System.Windows.Forms.Button();
            this.tbNumberOfVertices = new System.Windows.Forms.TextBox();
            this.lblNumberOfVertices = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStartNode = new System.Windows.Forms.TextBox();
            this.tbEndNode = new System.Windows.Forms.TextBox();
            this.EndNode = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).BeginInit();
            this.SuspendLayout();
            // 
            // drawArea
            // 
            this.drawArea.Location = new System.Drawing.Point(131, 12);
            this.drawArea.Name = "drawArea";
            this.drawArea.Size = new System.Drawing.Size(1241, 687);
            this.drawArea.TabIndex = 0;
            this.drawArea.TabStop = false;
            // 
            // brnGenerateGraph
            // 
            this.brnGenerateGraph.Location = new System.Drawing.Point(12, 57);
            this.brnGenerateGraph.Name = "brnGenerateGraph";
            this.brnGenerateGraph.Size = new System.Drawing.Size(113, 23);
            this.brnGenerateGraph.TabIndex = 1;
            this.brnGenerateGraph.Text = "Generate Graph";
            this.brnGenerateGraph.UseVisualStyleBackColor = true;
            this.brnGenerateGraph.Click += new System.EventHandler(this.btn_GenerateGraph);
            // 
            // tbNumberOfVertices
            // 
            this.tbNumberOfVertices.Location = new System.Drawing.Point(12, 31);
            this.tbNumberOfVertices.Name = "tbNumberOfVertices";
            this.tbNumberOfVertices.Size = new System.Drawing.Size(113, 20);
            this.tbNumberOfVertices.TabIndex = 2;
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
            this.btnClear.Location = new System.Drawing.Point(12, 86);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "StartNode:";
            // 
            // tbStartNode
            // 
            this.tbStartNode.Location = new System.Drawing.Point(12, 163);
            this.tbStartNode.Name = "tbStartNode";
            this.tbStartNode.Size = new System.Drawing.Size(113, 20);
            this.tbStartNode.TabIndex = 6;
            // 
            // tbEndNode
            // 
            this.tbEndNode.Location = new System.Drawing.Point(12, 212);
            this.tbEndNode.Name = "tbEndNode";
            this.tbEndNode.Size = new System.Drawing.Size(113, 20);
            this.tbEndNode.TabIndex = 8;
            // 
            // EndNode
            // 
            this.EndNode.AutoSize = true;
            this.EndNode.Location = new System.Drawing.Point(12, 195);
            this.EndNode.Name = "EndNode";
            this.EndNode.Size = new System.Drawing.Size(55, 13);
            this.EndNode.TabIndex = 7;
            this.EndNode.Text = "EndNode:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 239);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(113, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search path";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(12, 269);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(113, 146);
            this.tbResult.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 711);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbEndNode);
            this.Controls.Add(this.EndNode);
            this.Controls.Add(this.tbStartNode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblNumberOfVertices);
            this.Controls.Add(this.tbNumberOfVertices);
            this.Controls.Add(this.brnGenerateGraph);
            this.Controls.Add(this.drawArea);
            this.Name = "Form1";
            this.Text = "ROUTE CITY";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox drawArea;
        private System.Windows.Forms.Button brnGenerateGraph;
        private System.Windows.Forms.TextBox tbNumberOfVertices;
        private System.Windows.Forms.Label lblNumberOfVertices;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStartNode;
        private System.Windows.Forms.TextBox tbEndNode;
        private System.Windows.Forms.Label EndNode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbResult;
    }
}

