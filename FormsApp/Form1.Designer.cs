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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 711);
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
    }
}

