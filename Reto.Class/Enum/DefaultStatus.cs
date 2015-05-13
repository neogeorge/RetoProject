using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Class
{
    public enum DefaultStatus
    {
        Added = 1, //已新增
        Enabled, //已啟用
        Locked //已鎖定
    }

    public enum LogStatus
    {
        Info = 1, //一般
        Success, //成功
        Error //錯誤
    }

    public enum AccountType
    {
        UserLoginId, //登入帳號
        Email //Email
    }

    public enum LoginStatus
    {
        Lgoin = 1, //登入
        Logout //登出
    }
}
