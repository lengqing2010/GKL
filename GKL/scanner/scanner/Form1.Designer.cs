namespace scanner
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Com = new System.Windows.Forms.ComboBox();
            this.comboBox_comPl = new System.Windows.Forms.ComboBox();
            this.button_Test = new System.Windows.Forms.Button();
            this.textBox_TestTxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "可用串口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "扫描信息：";
            // 
            // comboBox_Com
            // 
            this.comboBox_Com.FormattingEnabled = true;
            this.comboBox_Com.Location = new System.Drawing.Point(84, 20);
            this.comboBox_Com.Name = "comboBox_Com";
            this.comboBox_Com.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Com.TabIndex = 3;
            // 
            // comboBox_comPl
            // 
            this.comboBox_comPl.FormattingEnabled = true;
            this.comboBox_comPl.Items.AddRange(new object[] {
            "19200"});
            this.comboBox_comPl.Location = new System.Drawing.Point(84, 58);
            this.comboBox_comPl.Name = "comboBox_comPl";
            this.comboBox_comPl.Size = new System.Drawing.Size(121, 20);
            this.comboBox_comPl.TabIndex = 6;
            this.comboBox_comPl.Text = "115200";
            // 
            // button_Test
            // 
            this.button_Test.Location = new System.Drawing.Point(147, 429);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(75, 23);
            this.button_Test.TabIndex = 7;
            this.button_Test.Text = "测试";
            this.button_Test.UseVisualStyleBackColor = true;
            this.button_Test.Click += new System.EventHandler(this.button_Test_Click);
            // 
            // textBox_TestTxt
            // 
            this.textBox_TestTxt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textBox_TestTxt.Cursor = System.Windows.Forms.Cursors.Cross;
            this.textBox_TestTxt.Location = new System.Drawing.Point(89, 104);
            this.textBox_TestTxt.Name = "textBox_TestTxt";
            this.textBox_TestTxt.Size = new System.Drawing.Size(423, 301);
            this.textBox_TestTxt.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 573);
            this.Controls.Add(this.textBox_TestTxt);
            this.Controls.Add(this.button_Test);
            this.Controls.Add(this.comboBox_comPl);
            this.Controls.Add(this.comboBox_Com);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Com;
        private System.Windows.Forms.ComboBox comboBox_comPl;
        private System.Windows.Forms.Button button_Test;
        private System.Windows.Forms.Label textBox_TestTxt;
    }
}

