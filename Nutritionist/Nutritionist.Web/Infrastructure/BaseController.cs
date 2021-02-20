using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Nutritionist.Core.Models;
using System.IO;
using System.Net;
using Nutritionist.Core.Models.ResponseModels;
using Nutritionist.Web.Models;

namespace Nutritionist.Web.Infrastructure
{
    public class BaseController : Controller
    {
        public readonly string BaseUrl = "https://localhost:44304/api/";
     
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View("~/Views/Shared/Error.cshtml", errorViewModel);
        }

        // If there is an error method will return errorviewmodel else return null.
        public ErrorViewModel CheckBaseControllerError<T>(BaseControllerResponseModel<T> baseControllerResponseModel)
        {
            if (baseControllerResponseModel != null && baseControllerResponseModel.IsValid())
            {
                return null;

            }
            else
            {
                if (baseControllerResponseModel != null || baseControllerResponseModel.errorViewModel != null)
                {
                    return baseControllerResponseModel.errorViewModel;
                }
            }
            return ErrorViewModel.GetDefaultException;
        }
        public BaseControllerResponseModel<T> Get<T>(MyApiRequestModel apiRequestModel,params string[] parameters)
        {
            String uri = GetRequestUri(apiRequestModel,true, parameters);
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(uri).Result;
                return CheckResponse<T>(response);
            }
        }
        public BaseControllerResponseModel<T> Post<T>(MyApiRequestModel apiRequestModel, object data)
        {
            String uri = GetRequestUri(apiRequestModel);
            var requestData = JsonConvert.SerializeObject(data);
            var content = new StringContent(requestData, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(uri, content).Result;
                return CheckResponse<T>(response);
            }
        }
        public BaseControllerResponseModel<T> Delete<T>(MyApiRequestModel apiRequestModel, params string[] parameters)
        {
            String uri = GetRequestUri(apiRequestModel, true, parameters);
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.DeleteAsync(uri).Result;
                return CheckResponse<T>(response);
            }
        }
        public BaseControllerResponseModel<T> CheckResponse<T>(HttpResponseMessage data)
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();
            try
            {
                if (data.IsSuccessStatusCode)
                {
                    var responseContent = data.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    BaseResponseModel result = JsonConvert.DeserializeObject<BaseResponseModel>(responseString);
                    if (result.responseMessageModel.isSuccess)
                    {
                        var successResponse = JsonConvert.DeserializeObject<SuccessResponseModel<T>>(responseString);
                        return new BaseControllerResponseModel<T>(successResponse.responseObj);
                    }
                    else{
                        errorViewModel = ErrorViewModel.GetServerError;
                    }
               }
               else
               {
                   errorViewModel = new ErrorViewModel((int)data.StatusCode,data.StatusCode.ToString());

               }
            }
            catch (Exception ex)
            {
                errorViewModel = ErrorViewModel.GetClientError(ex.Message.ToString());
            }
            return new BaseControllerResponseModel<T>(errorViewModel);
        }

        private String GetRequestUri(MyApiRequestModel apiRequestModel,bool isHttpGet =false,string[] parameters = null)
        {
            String uriResult=Path.Combine(BaseUrl,apiRequestModel.controller.ToString());
            uriResult=Path.Combine(uriResult,apiRequestModel.method.ToString());
            if (isHttpGet && parameters != null && parameters.Length > 0)
            {
                foreach (var parameter in parameters)
                {
                    uriResult = Path.Combine(uriResult, parameter);
                }
            }
            return uriResult;
        }
    }
}

