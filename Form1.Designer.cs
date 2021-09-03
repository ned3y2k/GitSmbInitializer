
namespace GitSmb
{
    partial class Form1
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
            this.gitPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gitRequireLabel = new System.Windows.Forms.Label();
            this.buttonGitBrowse = new System.Windows.Forms.Button();
            this.buttonProjectBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProjectDir = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.buttonUploadRootBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUploadRoot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUploadPath = new System.Windows.Forms.TextBox();
            this.labelWarn = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gitPathTextBox
            // 
            this.gitPathTextBox.Location = new System.Drawing.Point(110, 12);
            this.gitPathTextBox.Name = "gitPathTextBox";
            this.gitPathTextBox.Size = new System.Drawing.Size(495, 23);
            this.gitPathTextBox.TabIndex = 0;
            this.gitPathTextBox.TextChanged += new System.EventHandler(this.gitPathTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Git.exe 경로";
            // 
            // gitRequireLabel
            // 
            this.gitRequireLabel.AutoSize = true;
            this.gitRequireLabel.ForeColor = System.Drawing.Color.Red;
            this.gitRequireLabel.Location = new System.Drawing.Point(3, 40);
            this.gitRequireLabel.Name = "gitRequireLabel";
            this.gitRequireLabel.Size = new System.Drawing.Size(430, 15);
            this.gitRequireLabel.TabIndex = 2;
            this.gitRequireLabel.Text = "※ Atlassian Source Tree가 설치되어 있어야 합니다.(또는 수동으로 지정하세요)";
            // 
            // buttonGitBrowse
            // 
            this.buttonGitBrowse.Location = new System.Drawing.Point(612, 12);
            this.buttonGitBrowse.Name = "buttonGitBrowse";
            this.buttonGitBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonGitBrowse.TabIndex = 3;
            this.buttonGitBrowse.Text = "찾아보기";
            this.buttonGitBrowse.UseVisualStyleBackColor = true;
            this.buttonGitBrowse.Click += new System.EventHandler(this.buttonGitBrowse_Click);
            // 
            // buttonProjectBrowse
            // 
            this.buttonProjectBrowse.Location = new System.Drawing.Point(613, 66);
            this.buttonProjectBrowse.Name = "buttonProjectBrowse";
            this.buttonProjectBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonProjectBrowse.TabIndex = 6;
            this.buttonProjectBrowse.Text = "찾아보기";
            this.buttonProjectBrowse.UseVisualStyleBackColor = true;
            this.buttonProjectBrowse.Click += new System.EventHandler(this.buttonProjectBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "프로젝트 경로";
            // 
            // textBoxProjectDir
            // 
            this.textBoxProjectDir.AllowDrop = true;
            this.textBoxProjectDir.Location = new System.Drawing.Point(111, 66);
            this.textBoxProjectDir.Name = "textBoxProjectDir";
            this.textBoxProjectDir.Size = new System.Drawing.Size(495, 23);
            this.textBoxProjectDir.TabIndex = 4;
            this.textBoxProjectDir.TextChanged += new System.EventHandler(this.textBoxProjectDir_TextChanged);
            this.textBoxProjectDir.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxProjectDir_DragDrop);
            this.textBoxProjectDir.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxProjectDir_DragEnter);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(439, 40);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(184, 15);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://www.sourcetreeapp.com/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // buttonUploadRootBrowse
            // 
            this.buttonUploadRootBrowse.Location = new System.Drawing.Point(612, 109);
            this.buttonUploadRootBrowse.Name = "buttonUploadRootBrowse";
            this.buttonUploadRootBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonUploadRootBrowse.TabIndex = 10;
            this.buttonUploadRootBrowse.Text = "찾아보기";
            this.buttonUploadRootBrowse.UseVisualStyleBackColor = true;
            this.buttonUploadRootBrowse.Click += new System.EventHandler(this.buttonUploadRootBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "업로드 상위 경로";
            // 
            // textBoxUploadRoot
            // 
            this.textBoxUploadRoot.Location = new System.Drawing.Point(110, 109);
            this.textBoxUploadRoot.Name = "textBoxUploadRoot";
            this.textBoxUploadRoot.Size = new System.Drawing.Size(495, 23);
            this.textBoxUploadRoot.TabIndex = 8;
            this.textBoxUploadRoot.Text = "Z:\\프로그램 공동 작업";
            this.textBoxUploadRoot.TextChanged += new System.EventHandler(this.textBoxUploadRoot_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "업로드 경로";
            // 
            // textBoxUploadPath
            // 
            this.textBoxUploadPath.Location = new System.Drawing.Point(110, 152);
            this.textBoxUploadPath.Name = "textBoxUploadPath";
            this.textBoxUploadPath.ReadOnly = true;
            this.textBoxUploadPath.Size = new System.Drawing.Size(495, 23);
            this.textBoxUploadPath.TabIndex = 11;
            // 
            // labelWarn
            // 
            this.labelWarn.AutoSize = true;
            this.labelWarn.ForeColor = System.Drawing.Color.Red;
            this.labelWarn.Location = new System.Drawing.Point(2, 178);
            this.labelWarn.Name = "labelWarn";
            this.labelWarn.Size = new System.Drawing.Size(134, 15);
            this.labelWarn.TabIndex = 13;
            this.labelWarn.Text = "프로젝트를 선택하세요.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(613, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "게시";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 228);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelWarn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxUploadPath);
            this.Controls.Add(this.buttonUploadRootBrowse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxUploadRoot);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.buttonProjectBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxProjectDir);
            this.Controls.Add(this.buttonGitBrowse);
            this.Controls.Add(this.gitRequireLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gitPathTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxProjectDir_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxProjectDir_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gitPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label gitRequireLabel;
        private System.Windows.Forms.Button buttonGitBrowse;
        private System.Windows.Forms.Button buttonProjectBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxProjectDir;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button buttonUploadRootBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUploadRoot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUploadPath;
        private System.Windows.Forms.Label labelWarn;
        private System.Windows.Forms.Button button1;
    }
}

