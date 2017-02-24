namespace ImageProcWin
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
            this.picSource = new System.Windows.Forms.PictureBox();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnWatch = new System.Windows.Forms.Button();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.SuspendLayout();
            // 
            // picSource
            // 
            this.picSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picSource.Location = new System.Drawing.Point(12, 12);
            this.picSource.Name = "picSource";
            this.picSource.Size = new System.Drawing.Size(640, 480);
            this.picSource.TabIndex = 0;
            this.picSource.TabStop = false;
            // 
            // picResult
            // 
            this.picResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picResult.Location = new System.Drawing.Point(660, 12);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(640, 480);
            this.picResult.TabIndex = 0;
            this.picResult.TabStop = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(770, 498);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 39);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(872, 498);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 39);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(841, 558);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "0";
            // 
            // btnWatch
            // 
            this.btnWatch.Location = new System.Drawing.Point(12, 498);
            this.btnWatch.Name = "btnWatch";
            this.btnWatch.Size = new System.Drawing.Size(121, 39);
            this.btnWatch.TabIndex = 4;
            this.btnWatch.Text = "Watch";
            this.btnWatch.UseVisualStyleBackColor = true;
            this.btnWatch.Click += new System.EventHandler(this.btnWatch_Click);
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(149, 498);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(603, 84);
            this.txtOut.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(767, 558);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Glyph Count:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 590);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.btnWatch);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.picResult);
            this.Controls.Add(this.picSource);
            this.Name = "Form1";
            this.Text = "Image Processor";
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSource;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnWatch;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.Label label1;
    }
}

