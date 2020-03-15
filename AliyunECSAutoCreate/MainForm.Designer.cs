namespace AliyunECSAutoCreate
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn1 = new System.Windows.Forms.Button();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tm1 = new System.Windows.Forms.Timer(this.components);
            this.btn2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Enabled = false;
            this.btn1.Location = new System.Drawing.Point(60, 82);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(110, 43);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "初始化";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(12, 31);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(411, 25);
            this.tb1.TabIndex = 1;
            // 
            // tm1
            // 
            this.tm1.Interval = 1000;
            this.tm1.Tick += new System.EventHandler(this.tm1_Tick);
            // 
            // btn2
            // 
            this.btn2.Enabled = false;
            this.btn2.Location = new System.Drawing.Point(234, 82);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(110, 43);
            this.btn2.TabIndex = 2;
            this.btn2.Text = "更新解析";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 173);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.btn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "阿里云ECS自动创建";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Timer tm1;
        private System.Windows.Forms.Button btn2;
    }
}