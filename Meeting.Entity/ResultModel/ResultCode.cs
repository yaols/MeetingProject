using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Entity.ResultModel
{
    public enum ResultCode
    {
        Ok = 0, //ok
        ServerError = 1, //服务器错误 
        ClientError = 2, //客户端非法数据
        MessageServer = 3, //服务端调用短信接口数据
        RedisServerError = 4 //调用redis服务出错
    }
}
