using E信自由版.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E信自由版
{
    public partial class MainForm : Form
    {
        bool eXinSaved = false;
        bool routerSaved = false;
        Router router = new Router();
        List<Router.GateWay> gw = new List<Router.GateWay>();
        DataFile.ImportantData id = new DataFile.ImportantData();
        UpdateCheck uc = new UpdateCheck();

        public MainForm()
        {
            InitializeComponent();
            id = DataFile.GetImportantData();
            if(id != null)
            {
                if (id.EXin.UserName != null)
                    this.idTextBox.Text = id.EXin.UserName;
                if (id.EXin.PassWord != null)
                {
                    this.pwdTextBox.Text = id.EXin.PassWord;

                    eXinSaved = true;
                    this.saveCheckBox.Checked = true;
                }
                    

                if (id.Router.UserName != null)
                    this.id2TextBox.Text = id.Router.UserName;

                if (id.Router.PassWord != null)
                {
                    this.pwd2TextBox.Text = id.Router.PassWord;
                    routerSaved = true;
                    this.save2CheckBox.Checked = true;
                }    
                this.RouterModelComboBox.Items.Add((Object)("WR703N 3.17.1"));
                this.RouterModelComboBox.Items.Add((Object)("WR740N 5.1.3"));
                this.RouterModelComboBox.SelectedIndex = 1; 
                if(PPPoE.IsEXinInActive())
                {
                    this.ConnectButton.Text = "断开";
                    this.statusLabel.Text = "E信已连接";
                    connected = true;
                    if (!uc.HaveBeenChecked)
                        uc.CheckUpdate();
                }
            }
        }

        private bool TestExinPara()
        {
            if (string.IsNullOrWhiteSpace(this.idTextBox.Text))
            {
                MessageShow.Display("请输入E信用户名!", "提示");
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.pwdTextBox.Text))
            {
                MessageShow.Display("请输入E信密码!", "提示");
                return false;
            }

            return true;
        }

        private bool TestRouterPara()
        {
            if (string.IsNullOrWhiteSpace(this.id2TextBox.Text))
            {
                MessageShow.Display("请输入路由器管理员用户名!", "提示");
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.pwd2TextBox.Text))
            {
                MessageShow.Display("请输入路由器管理员密码!", "提示");
                return false;
            }

            return true;
        }

        bool connected = false;
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if(!connected)
            {
                if (!TestExinPara())
                    return;                           
                string username = Algorithm.Encryption(Encoding.ASCII.GetBytes(id.EXin.UserName));
                string password = id.EXin.PassWord;

                bool dialSuccess = PPPoE.Connect("E信自由版", username, password);
                if (dialSuccess)
                {
                    this.statusLabel.Text = "拨号成功!\r\n" + PPPoE.GetIPAddress("E信自由版");
                    this.ConnectButton.Text = "断开";
                    connected = true;

                    if (!uc.HaveBeenChecked)
                        uc.CheckUpdate();
                }
            }
            else
            {
                PPPoE.Disconnect("E信自由版");
                this.statusLabel.Text = "断开连接成功!";
                this.ConnectButton.Text = "连接";
                connected = false;
            }
        }


        private bool routerConnected = false;
        private async void setRouterButton_Click(object sender, EventArgs e)
        {
            if(!routerConnected)
            {
                if (!TestExinPara())
                {
                    this.mainTabControl.SelectTab(0);
                    return;
                }
                if (!TestRouterPara())
                {
                    return;
                }
                if(gw.Count ==0)
                {
                    MessageShow.Display("当前未连接至任何路由器！请检查网络连接或选择路由器IP地址后重试", "提示");
                    return;
                }
                if(!gw[this.IPComboBox.SelectedIndex].canPing)
                {
                    MessageShow.Display("当前选定的路由器无法Ping通，请重启路由器后重试", "提示");
                    return;
                }

                this.setRouterButton.Enabled = false;
                bool x = await router.PPPoE(gw[this.IPComboBox.SelectedIndex].address, id);
                this.setRouterButton.Enabled = true;
                string display_str;
                List<string> status = router.GetRouterStatus(id, false);
                if(x)
                {                   
                    routerConnected = true;
                    this.setRouterButton.Text = "断开";
                    display_str = "路由器拨号成功！\r\n" + status[1];
                    this.status2Label.Text = display_str;
                    if (!uc.HaveBeenChecked)
                        uc.CheckUpdate();

                }
                else
                {
                    display_str = "路由器拨号失败！\r\n" + status[1];
                    this.status2Label.Text = display_str;
                } 
            }
            else
            {
                
                this.setRouterButton.Enabled = false;
                bool x = await router.Disconnect(id);
                this.setRouterButton.Enabled = true;


                string display_str;
                List<string> status = router.GetRouterStatus(id, false);
                if (x)
                {
                    routerConnected = false;
                    this.setRouterButton.Text = "连接";
                    display_str = "路由器断开连接成功！\r\n" + status[1];
                    this.status2Label.Text = display_str;

                }
                else
                {
                    display_str = "路由器断开连接失败！\r\n" + status[1];
                    this.status2Label.Text = display_str;
                } 
            }                    
        }


        private void getRouterInfoButton_Click(object sender, EventArgs e)
        {
            if (gw.Count == 0)
            {
                MessageShow.Display("当前未连接至任何路由器！请检查网络连接或选择路由器IP地址后重试", "提示");
                return;
            }
            if (!gw[this.IPComboBox.SelectedIndex].canPing)
            {
                MessageShow.Display("当前选定的路由器无法Ping通，请重启路由器后重试", "提示");
                return;
            }

            string display_str;
            List<string> wanInfo = router.GetRouterInfo(id);
            if (wanInfo.Count < 6)
            {
                this.status2Label.Text = "获取路由器信息失败！";
                return;
            }
            display_str = "MAC地址：" + wanInfo[0] +
                "\r\nIP地址：" + wanInfo[1] +
                "\r\n子网掩码：" + wanInfo[2] +
                "\r\n网关：" + wanInfo[3] +
                "\r\nDNS服务器：" + wanInfo[4] +
                "\r\n上网时间：" + wanInfo[5];
            display_str = "获取路由器信息成功！\r\n" + display_str;
            this.status2Label.Text = display_str;
            if (wanInfo[1] != "0.0.0.0")
            {
                routerConnected = true;
                this.setRouterButton.Text = "断开";
            }
            else
            {
                routerConnected = false;
                this.setRouterButton.Text = "连接";
            }
        }


        private async void getIPAgainButton_Click(object sender, EventArgs e)
        {
            this.IPComboBox.Text = "";
            this.IPComboBox.Items.Clear();
            gw = await Router.GetGateway();
            foreach (Router.GateWay item in gw)
            {
                if (item.canPing)
                {
                    this.IPComboBox.Items.Add((Object)(item.address + "(可Ping通)"));
                }
                else
                {
                    this.IPComboBox.Items.Add((Object)(item.address + "(无法Ping通)"));
                }
            }
            if (gw.Count != 0)
            {
                this.IPComboBox.SelectedIndex = 0;
                if (gw[0].canPing)
                    router.GetRouterStatus(id,false);
            }
                
        }


        private async void mainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (this.mainTabControl.SelectedIndex == 1)
            {
                gw = await Router.GetGateway();
                foreach (Router.GateWay item in gw)
                {
                    if (item.canPing)
                    {
                        this.IPComboBox.Items.Add((Object)(item.address + "(可Ping通)"));
                    }
                    else
                    {
                        this.IPComboBox.Items.Add((Object)(item.address + "(无法Ping通)"));
                    }

                }
                if (gw.Count != 0)
                {
                    this.IPComboBox.SelectedIndex = 0;
                    if (gw[0].canPing)
                        router.GetRouterStatus(id,false);
                }                                    
                this.mainTabControl.Selected -= mainTabControl_Selected;
            }

        }             
        

        private void IPComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            router.RouterIP = gw[this.IPComboBox.SelectedIndex].address;
        }

        private void RouterModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string model = this.RouterModelComboBox.SelectedItem as string;
            if (model == "WR703N 3.17.1")
            {
                router.model = RouterModel.WR703N;
            }
            else if (model == "WR740N 5.1.3")
            {
                router.model = RouterModel.WR740N;
            }
        }


        private void saveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!eXinSaved)
            {
                if (!TestExinPara())
                    return;
                if (this.saveCheckBox.Checked)
                {
                    DataFile.ImportantData id = new DataFile.ImportantData();
                    id.EXin.UserName = this.idTextBox.Text;
                    id.EXin.PassWord = this.pwdTextBox.Text;
                    DataFile.SaveImportantData(id);
                    eXinSaved = true;
                }
            }
        }

        private void save2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!routerSaved)
            {
                if (!TestRouterPara())
                    return;
                if (this.save2CheckBox.Checked)
                {
                    DataFile.ImportantData id = new DataFile.ImportantData();
                    id.Router.UserName = this.id2TextBox.Text;
                    id.Router.PassWord = this.pwd2TextBox.Text;
                    DataFile.SaveImportantData(id);
                    routerSaved = true;
                }
            }
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            id.EXin.UserName = this.idTextBox.Text;
        }

        private void pwdTextBox_TextChanged(object sender, EventArgs e)
        {
            id.EXin.PassWord = this.pwdTextBox.Text;
        }

        private void id2TextBox_TextChanged(object sender, EventArgs e)
        {
            id.Router.UserName = this.id2TextBox.Text;
        }

        private void pwd2TextBox_TextChanged(object sender, EventArgs e)
        {
            id.Router.PassWord = this.pwd2TextBox.Text;
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)//最小化　　　　　 
            {
                this.ShowInTaskbar = false;
            }
        }

        private void showMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.ShowInTaskbar = true;
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)//最小化　　　　　 
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
                this.mainTabControl.SelectedIndex = 2;
            }
            else if(this.WindowState == FormWindowState.Normal)
            {
                this.mainTabControl.SelectedIndex = 2;
            }

            this.ShowInTaskbar = true;
        }       
    }
}
