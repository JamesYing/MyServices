using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.MyServices.Models.Requests
{
    public class PasswordRequest
    {
        /// <summary>
        /// 需要加密的字符串
        /// </summary>
        public string PlainText { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 是否小写
        /// </summary>
        public bool IsLower { get; set; } = false;
    }
}
