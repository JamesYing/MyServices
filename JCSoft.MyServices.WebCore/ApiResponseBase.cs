using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.MyServices.WebCore
{
    public class ApiResponseBase
    {
        public bool IsError { get; set; }
        public string ErrorMsg { get; set; }
        public string ErrorReason { get; set; }
        public int Code { get; set; }
    }

    public class ApiResponseBase<T> : ApiResponseBase
    {
        public T Data { get; set; }
    }
}
