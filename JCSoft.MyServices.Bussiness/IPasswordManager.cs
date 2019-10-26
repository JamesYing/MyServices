using JCSoft.MyServices.Models.Requests;
using JCSoft.MyServices.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.MyServices.Business
{
    public interface IPasswordManager : ISingle
    {
        Md5Response Md5(PasswordRequest request);
    }
}
