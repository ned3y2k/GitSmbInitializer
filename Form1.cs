using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitSmb
{
    public partial class Form1 : Form
    {
        private string physicalAddressList;
        private string ipAddressList;

        public Form1()
        {
            InitializeComponent();
            gitPathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Atlassian\\SourceTree\\git_local\\cmd\\git.exe";
            checkGitExist();
            prepareInetInfo();
        }

        private void prepareInetInfo()
        {
            var physicalAddressList = new List<string>();
            var ipAddressList = new List<string>();

            foreach (var iface in NetworkInterface.GetAllNetworkInterfaces())
            {

                switch (iface.NetworkInterfaceType)
                {
                    case NetworkInterfaceType.Tunnel:
                    case NetworkInterfaceType.Ethernet:
                    case NetworkInterfaceType.FastEthernetT:
                    case NetworkInterfaceType.FastEthernetFx:
                    case NetworkInterfaceType.Wireless80211:
                    case NetworkInterfaceType.GigabitEthernet:
                        if (iface.OperationalStatus == OperationalStatus.Up)
                        {
                            physicalAddressList.Add(iface.GetPhysicalAddress().ToString());
                            foreach (var addr in iface.GetIPProperties().UnicastAddresses)
                            {
                                ipAddressList.Add(addr.Address.ToString());
                            }

                        }
                        break;
                    default:
                        break;
                }
            }            
            this.physicalAddressList = String.Join(",", physicalAddressList);
            this.ipAddressList = String.Join(",", ipAddressList);
        }

        void checkGitExist()
        {
            if(!File.Exists(gitPathTextBox.Text))
            {
                gitRequireLabel.Text = "※ Atlassian Source Tree가 설치되어 있어야 합니다.(또는 수동으로 지정하세요)";
                gitRequireLabel.ForeColor = Color.Red;
                linkLabel1.Visible = true;
            }
            else
            {
                gitRequireLabel.Text = "Git 설치됨";
                gitRequireLabel.ForeColor = Color.Black;
                linkLabel1.Visible = false;
            }
        }

        string baseName(String path)
        {
            var fullPath = Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar);
            return Path.GetFileName(path);
        }

        void createUploadPath()
        {
            if(textBoxProjectDir.Text.Length > 0 && textBoxUploadRoot.Text.Length > 0)
            {
                textBoxUploadPath.Text = textBoxUploadRoot.Text + Path.DirectorySeparatorChar + baseName(textBoxProjectDir.Text);
            }
            
            if(Directory.Exists(textBoxUploadPath.Text))
            {
                labelWarn.Text = "※ 이미 해당 이름의 프로젝트가 있습니다.";
                labelWarn.ForeColor = Color.Red;
            } else
            {
                labelWarn.Text = "준비 완료.";
                labelWarn.ForeColor = Color.Black;
            }
        }

        private void buttonGitBrowse_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "git.exe (git.exe)|모든파일 (*.*)";
            dlg.Multiselect = false;
            var result = dlg.ShowDialog();

            
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dlg.FileName))
            {
                gitPathTextBox.Text = dlg.FileName;
            }

            dlg.Dispose();
        }

        private void gitPathTextBox_TextChanged(object sender, EventArgs e)
        {
            checkGitExist();
        }

        private void buttonProjectBrowse_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            var result = dlg.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dlg.SelectedPath))
            {
                textBoxProjectDir.Text = dlg.SelectedPath;
            }
            dlg.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = linkLabel1.Text.Replace("&", "^&");
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }

        private void buttonUploadRootBrowse_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            var result = dlg.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dlg.SelectedPath))
            {
                textBoxUploadRoot.Text = dlg.SelectedPath;
            }
            dlg.Dispose();
        }

        private void textBoxUploadRoot_TextChanged(object sender, EventArgs e)
        {
            createUploadPath();
        }

        private void textBoxProjectDir_TextChanged(object sender, EventArgs e)
        {
            createUploadPath();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (labelWarn.ForeColor == Color.Red || gitRequireLabel.ForeColor == Color.Red)
            {
                MessageBox.Show("에러를 확인하세요.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sInfo = new ProcessStartInfo();
            sInfo.FileName = gitPathTextBox.Text;
            sInfo.ArgumentList.Add("init");
            sInfo.ArgumentList.Add("--bare");

            string projectName = baseName(textBoxProjectDir.Text);
            sInfo.ArgumentList.Add(projectName);
            sInfo.WorkingDirectory = textBoxUploadRoot.Text;
            var proc = new Process();
            proc.StartInfo = sInfo;
            proc.Start();
            proc.WaitForExit();
            proc.Dispose();

            createUploadPath();

            var alearyGit = false;
            sInfo.WorkingDirectory = textBoxProjectDir.Text;
            if (!Directory.Exists(textBoxProjectDir.Text + Path.DirectorySeparatorChar + ".git"))
            {
                proc = new Process();
                sInfo.ArgumentList.Clear();
                sInfo.ArgumentList.Add("init");
                proc.StartInfo = sInfo;
                proc.Start();
                proc.WaitForExit();
                proc.Dispose();
            }
            else
            {
                alearyGit = true;
                MessageBox.Show("이 프로젝트는 이미 GIT이 적용되었던 프로젝트입니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var readMePath = textBoxProjectDir.Text + Path.DirectorySeparatorChar + "ReadMe";            
            var contents = (!alearyGit ? "Created: " : "\r\nReuploaded: ") + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
            contents += "Project Name: " + projectName + "\r\n";            
            contents += "PC Name: " + Environment.MachineName + "\r\n";
            contents += "User Name: " + Environment.UserName + "\r\n";
            contents += "Interface MAC List: " + physicalAddressList + "\r\n";
            contents += "Interface IPAddress List: " + ipAddressList + "\r\n";
            if(!alearyGit && File.Exists(readMePath))
                File.WriteAllText(readMePath, contents);
            else
                File.AppendAllText(readMePath, contents);

            proc = new Process();

            proc = new Process();
            sInfo.ArgumentList.Clear();
            sInfo.ArgumentList.Add("add");
            sInfo.ArgumentList.Add("ReadMe");
            proc.StartInfo = sInfo;
            proc.Start();
            proc.WaitForExit();
            proc.Dispose();

            proc = new Process();
            sInfo.ArgumentList.Clear();
            sInfo.ArgumentList.Add("remote");
            sInfo.ArgumentList.Add("add");
            sInfo.ArgumentList.Add("origin");
            sInfo.ArgumentList.Add(textBoxUploadPath.Text);
            proc.StartInfo = sInfo;
            proc.Start();
            proc.WaitForExit();
            proc.Dispose();
            
            proc = new Process();
            sInfo.ArgumentList.Clear();
            sInfo.ArgumentList.Add("commit");
            sInfo.ArgumentList.Add("-m");
            sInfo.ArgumentList.Add(!alearyGit ? "Initial Commit" : "Info Commit");
            proc.StartInfo = sInfo;
            proc.Start();
            proc.WaitForExit();
            proc.Dispose();

            proc = new Process();
            sInfo.ArgumentList.Clear();
            sInfo.ArgumentList.Add("push");
            sInfo.ArgumentList.Add("origin");
            sInfo.ArgumentList.Add("master");
            proc.StartInfo = sInfo;
            proc.Start();
            proc.WaitForExit();
            proc.Dispose();

            MessageBox.Show("SourceTree에서 +를 누르고 %1을 Local Repositories에 드랍해주세요.");
        }

        private void textBoxProjectDir_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            textBoxProjectDir.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        }

        private void textBoxProjectDir_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
