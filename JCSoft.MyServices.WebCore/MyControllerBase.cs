using Microsoft.AspNetCore.Mvc;
using System;

namespace JCSoft.MyServices.WebCore
{
    public abstract class MyControllerBase : ControllerBase
    {
        protected ApiResponseBase TryAction(Action action)
        {
            var result = new ApiResponseBase();
            try
            {
                action();
            }
            catch(Exception ex)
            {
                CatchException(ex, result);
            }
            return result;
        }

        protected ApiResponseBase TryFunc<T>(Func<T> func)
        {
            var result = new ApiResponseBase<T>();
            try
            {
                result.Data = func();
            }
            catch (Exception ex)
            {
                CatchException(ex, result);
            }
            return result;
        }

        private void CatchException(Exception ex, ApiResponseBase response)
        {
            response.Code = -1;
            response.IsError = true;
            response.ErrorMsg = ex.Message;
            response.ErrorReason = ex.ToString();
        }
    }
}
