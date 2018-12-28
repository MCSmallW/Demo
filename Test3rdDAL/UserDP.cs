using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Test3rdModel;

namespace Test3rdDAL
{
    public class UserDP
    {
                
    }
    class DbUtil        //用于保存 链接服务器的sql语句
    {
        public static string ConnString = @"Data Source=USERCHI-70QC0BS\SQLSERVER;Initial Catalog=Mine;User ID=sa;Password=123456";
    }

    public class UserDAO
    {
        public void Add(string username, string password,int del,DateTime createtime,string createby,DateTime systime,string sysby)
        {
            //新建账号
            using (SqlConnection conn = new SqlConnection(DbUtil.ConnString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[User](Name,Password,Createtime,CreateBy,Systime,SysBy) Values(@UserName,@Password,@createtime,@createby,@systime,@sysby)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@userName", username));
                cmd.Parameters.Add(new SqlParameter("@Password", password));
                cmd.Parameters.Add(new SqlParameter("@systime", systime));
                cmd.Parameters.Add(new SqlParameter("@sysby", sysby));
                cmd.Parameters.Add(new SqlParameter("@createtime", createtime));
                cmd.Parameters.Add(new SqlParameter("@createby", createby));

                conn.Open();        //打开数据链接
                cmd.ExecuteNonQuery();
            }
        }
        //登陆账号
        public UserInfo Loading(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(DbUtil.ConnString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"select * from [dbo].[User] where Name = @username and Password = @password and del != 1";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@userName", username));
                cmd.Parameters.Add(new SqlParameter("@Password", password));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                UserInfo user = null;
                while (reader.Read())       //开始读取数据
                {
                    if (user == null)     //如果没有，则重新生成一个
                    {
                        user = new Test3rdModel.UserInfo();
                    }
                    user.UserName = reader.GetString(1);
                }
                return user;
            }
        }
        //判断是否有账号
        public bool PD(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(DbUtil.ConnString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"select * from [dbo].[User] where Name = @username and Password = @password and del != 1";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@userName", username));
                cmd.Parameters.Add(new SqlParameter("@Password", password));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                UserInfo user = null;
                while (reader.Read())       //开始读取数据
                {
                    user.UserName = reader.GetString(1);
                }
                if (user.UserName != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //修改账号权限
        public void Modify(string username, int del, DateTime systime, string sysby,int permission)
        {
            //新建账号
            using (SqlConnection conn = new SqlConnection(DbUtil.ConnString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE [dbo].[User] SET Permission = @Permission,SysTime = @systime,SysBy = @sysby where Name = @userName and Del = 0";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@userName", username));
                cmd.Parameters.Add(new SqlParameter("@Permission", permission));
                cmd.Parameters.Add(new SqlParameter("@systime", systime));
                cmd.Parameters.Add(new SqlParameter("@sysby", sysby));

                conn.Open();        //打开数据链接
                cmd.ExecuteNonQuery();
            }
        }
        //删除账号
        public void Delete(string username, DateTime systime, string sysby)
        {
            //新建账号
            using (SqlConnection conn = new SqlConnection(DbUtil.ConnString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE [dbo].[User] SET Del = 1,SysTime = @systime,SysBy = @sysby where Name = @userName";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@userName", username));
                cmd.Parameters.Add(new SqlParameter("@systime", systime));
                cmd.Parameters.Add(new SqlParameter("@sysby", sysby));

                conn.Open();        //打开数据链接
                cmd.ExecuteNonQuery();
            }
        }

    }
        //    public Test3rdModel.UserInfo SelectUser(string userName, string Password)   //根据 ui 选择返回一个user
        //    {
        //        using (SqlConnection conn = new SqlConnection(DbUtil.ConnString))
        //        {
        //            //创建一个命令对象，并添加命令
        //            SqlCommand cmd = conn.CreateCommand();
        //            cmd.CommandText = @"SELECT ID,Name FROM [dbo].[User] WHERE Name='@UserName' AND ID=@Password";
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.Add(new SqlParameter("@userName", userName));
        //            cmd.Parameters.Add(new SqlParameter("@Password", Password));

        //            conn.Open();        //打开数据链接
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            Test3rdModel.UserInfo user = null;     //用于保存读取的数据

        //            while (reader.Read())       //开始读取数据
        //            {
        //                if (user == null)     //如果没有，则重新生成一个
        //                {
        //                    user = new Test3rdModel.UserInfo();
        //                }
        //                user.UserId = reader.GetInt32(0);
        //                user.UserName = reader.GetString(1);
        //            }
        //            return user;
        //        }

        //    }
        //}
        //public class ScoreDAO     //首次登陆，增加10积分
        //{
        //    public void UpdateScore(string userName, int value)
        //    {
        //        using (SqlConnection conn = new SqlConnection(DbUtil.ConnString))
        //        {
        //            SqlCommand cmd = conn.CreateCommand();  //创建一个命令对象
        //            cmd.CommandText = @"INSERT INTO SCORES(UserName,Score) Values(@UserName,@Score)";  //修改Score表数据
        //            cmd.Parameters.Add(new SqlParameter("@userName", userName));
        //            cmd.Parameters.Add(new SqlParameter("@Score", value));

        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
    
}