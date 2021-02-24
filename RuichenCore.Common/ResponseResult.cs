using System;
using System.Collections.Generic;
using System.Text;

namespace RuichenCore.Common
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            this.success = true;
            this.msg = "成功";
        }
        public ResponseResult(bool success)
        {
            this.success = success;
        }
        public ResponseResult(bool success, string msg)
        {
            this.success = success;
            this.msg = msg;
        }

        public ResponseResult(bool success, object data)
        {
            this.success = success;
            this.data = data;
        }

        public ResponseResult(bool success, string msg, object data) : this(success, msg)
        {
            this.data = data;
        }

        public bool success { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public int code
        {
            get
            {
                if (success)
                {
                    return 200;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
