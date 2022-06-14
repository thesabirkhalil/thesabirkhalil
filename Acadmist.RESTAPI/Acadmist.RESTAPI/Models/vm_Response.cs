using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acadmist.RESTAPI.Models
{
    public class vm_Response
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; } = null;
        public vm_Response Success(string Message)
        {
            this.isSuccess = true;
            this.Message = Message;
            return this;
        }
        public vm_Response Success(string Message, object Data)
        {
            this.isSuccess = true;
            this.Message = Message;
            this.Data = Data;
            return this;

        }

        public vm_Response Failed(string Message)
        {
            this.isSuccess = false;
            this.Message = Message;
            return this;

        }
        public vm_Response Failed(string Message, object Data)
        {
            this.isSuccess = false;
            this.Message = Message;
            this.Data = Data;
            return this;

        }
    }
}