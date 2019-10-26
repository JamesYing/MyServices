using System.Text;
using JCSoft.MyServices.Models.Requests;
using JCSoft.MyServices.Models.Responses;
using JCSoft.MyServices.Utils;

namespace JCSoft.MyServices.Business
{
    public class PasswordManager : IPasswordManager
    {
        public Md5Response Md5(PasswordRequest request)
        {
            var md5Encryp = request.PlainText.MD5Encryp(request.IsLower);
            return new Md5Response
            {
                SecretText = md5Encryp,
                SecretTextFor16 = md5Encryp.Substring(8, 16)
            };
        }
    }
}
