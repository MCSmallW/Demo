
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Test3rdModel
{
    public class UserInfo
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Del { get; set; }//是否删除
        public int Permission { get; set; }//判断权限
        public DateTime CreateTime { get; set; }//创建时间
        public string CreateBy { get; set; }//创建人
        public DateTime SysTime { get; set; }//最后操作时间
        public string SysBy { get; set; }//最后操作人
    }
}