using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test3rdDAL;
using Test3rdModel;

namespace Test3rdBLL
{
    public class Test3rdBLL
    {
        private Test3rdDAL.UserDP userDP = new Test3rdDAL.UserDP();
        //public bool Add(UserInfo userInfo,out string messageStr)
        //{
        //    messageStr = "";//返回界面层添加用户返回信息
        //    bool isSuccess = false;
        //    if (userInfo.UserName.Trim().Length != 0)//判断从传递来的username是否为空
        //    {
        //        if (userDP.IsEquals(userInfo))//传给DALl操作判断数据库中是否有重复值
        //        {
        //            userDP.AddUser(userInfo);//传给DAL操作增加一个新用户
        //            isSuccess = true;
        //        }
        //        else
        //            messageStr = "有相同的值";
        //    }
        //    else
        //    {
        //        messageStr = "不能为空";

        //    }
        //    return isSuccess;
        //}

        
    }
    //public class LoginManager
    //{
    //    public Test3rdModel.UserInfo UserLogin(string userName, string Password)
    //    {
    //        ///throw new NotImplementedException();
    //        Test3rdDAL.UserDAO uDAO = new Test3rdDAL.UserDAO();  //创建一个user
    //        Test3rdModel.UserInfo user = uDAO.SelectUser(userName, Password);  //通过ui中填写的内容 返回来相应的数据

    //        if (user != null)        //如果数据库中没有数据，即为首次登陆了。增加10积分
    //        {
    //            Test3rdDAL.ScoreDAO sDAO = new Test3rdDAL.ScoreDAO();
    //            sDAO.UpdateScore(userName, 10);
    //            return user;
    //        }
    //        else       //如果数据库中没有该用户名，则登陆失败
    //        {
    //            throw new Exception("登陆失败");
    //        }
    //    }
    //}
    public class Add
    {
        public bool userInfo(string Name,string ID)
        {
            UserDAO userDP = new UserDAO();
            //userDP.Add(Name,ID);
            return true;
        }

    }
    //登陆逻辑判断
    public class Loading
    {
        public UserInfo userloading(string name,string password)
        {
            UserDAO userDAO = new UserDAO();
            if (userDAO.PD(name, password))
            {
                return userDAO.Loading(name, password);
            }
            else
            {
                throw new Exception("登陆失败");
            }
        }
    }
}
