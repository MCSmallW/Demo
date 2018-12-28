using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test3rd
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void btnloading_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtname.Text.Trim();
                string userpassword = txtpassword.Text;
                Test3rdBLL.Loading loading = new Test3rdBLL.Loading();
                loading.userloading(userName, userpassword);
                MessageBox.Show("登陆用户成功");
            }
            catch (Exception ex)   //如果登陆有异常 则登陆失败
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
