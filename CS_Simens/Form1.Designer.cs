namespace CS_Simens
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.UrlCB = new System.Windows.Forms.ComboBox();
            this.StatusLabelSTS = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.StatusLabelSTS.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.Enabled = false;
            this.btn_Connect.Location = new System.Drawing.Point(632, 70);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(100, 29);
            this.btn_Connect.TabIndex = 0;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "192.168.250.";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 71);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 25);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "100";
            // 
            // UrlCB
            // 
            this.UrlCB.FormattingEnabled = true;
            this.UrlCB.Location = new System.Drawing.Point(205, 72);
            this.UrlCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UrlCB.Name = "UrlCB";
            this.UrlCB.Size = new System.Drawing.Size(361, 23);
            this.UrlCB.TabIndex = 3;
            this.UrlCB.DropDown += new System.EventHandler(this.UrlCB_DropDown);
            // 
            // StatusLabelSTS
            // 
            this.StatusLabelSTS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusLabelSTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.StatusLabelSTS.Location = new System.Drawing.Point(0, 648);
            this.StatusLabelSTS.Name = "StatusLabelSTS";
            this.StatusLabelSTS.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusLabelSTS.Size = new System.Drawing.Size(783, 24);
            this.StatusLabelSTS.TabIndex = 5;
            this.StatusLabelSTS.Text = "StatusLabelSTS";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(201, 19);
            this.toolStripStatusLabel.Text = "enter URL and click connect";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(669, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 672);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StatusLabelSTS);
            this.Controls.Add(this.UrlCB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Connect);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.StatusLabelSTS.ResumeLayout(false);
            this.StatusLabelSTS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox UrlCB;
        private System.Windows.Forms.StatusStrip StatusLabelSTS;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label label2;
    }
}

