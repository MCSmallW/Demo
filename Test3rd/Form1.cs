using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Test3rdModel;
using Test3rdBLL;
using Test3rdDAL;

namespace Test3rd
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“mineDataSet.User”中。您可以根据需要移动或删除它。
            this.userTableAdapter.Fill(this.mineDataSet.User);

        }

        private Test3rdBLL.Test3rdBLL test3 = new Test3rdBLL.Test3rdBLL();

        private void Add_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string userName = txtUserName.Text.Trim();   //取出用户界面的数据
            //    string password = txtPassword.Text;
            //    Test3rdBLL.LoginManager mgr = new Test3rdBLL.LoginManager();
            //    Test3rdModel.UserInfo user = mgr.UserLogin(userName, password);   //使用用户界面数据 进行查找

            //    //如果没有问题，则登陆成功
            //    MessageBox.Show("登陆用户：" + user.UserName);
            //}
            //catch (Exception ex)   //如果登陆有异常 则登陆失败
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void Create_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text.Trim();
                string userid = txtPassword.Text;
                Test3rdBLL.Add add = new Add();
                add.userInfo(userName, userid);
                MessageBox.Show("登陆用户：");
            }
            catch (Exception ex)   //如果登陆有异常 则登陆失败
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
