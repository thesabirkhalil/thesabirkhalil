using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.AcademistPortal.Models
{
    public class Success
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }

        public object Record { get; set; }
    }
}