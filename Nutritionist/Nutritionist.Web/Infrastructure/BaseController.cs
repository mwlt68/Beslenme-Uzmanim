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
using System.Reflection;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace Nutritionist.Web.Infrastructure
{
    public class BaseController : Controller
    {
        public readonly string BaseUrl = "https://localhost:44304/api/";
        public readonly IMapper mapper;


        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;

        }
        public IActionResult Error(params ErrorViewModel[] errorViewModels)
        {
            foreach (var error in errorViewModels)
            {
                if (error != null )
                {
                    return View("~/Views/Shared/Error.cshtml", error);
                }

            }
            return View("~/Views/Shared/Error.cshtml", ErrorViewModel.GetDefaultException);
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
        public BaseControllerResponseModel<T> Get<T>(MyApiRequestModel apiRequestModel, bool withToken ,params string[] parameters)
        {
            String uri = GetRequestUri(apiRequestModel,true, parameters);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
            return SendRequest<T>(request, withToken);
        }
        public BaseControllerResponseModel<T> PostMultipartForm<T>(MyApiRequestModel apiRequestModel, object data,bool withToken= false)
        {
            String uri = GetRequestUri(apiRequestModel);
            MultipartFormDataContent form = ObjectToMultipartFormDataContent(data);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,uri);
            request.Content = form;
            return SendRequest<T>(request, withToken);
        }

        public BaseControllerResponseModel<T> Post<T>(MyApiRequestModel apiRequestModel, object data, bool withToken = false)
        {
            String uri = GetRequestUri(apiRequestModel);
            var requestData = JsonConvert.SerializeObject(data);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(requestData, Encoding.UTF8, "application/json");
            return SendRequest<T>(request, withToken);
        }
        public BaseControllerResponseModel<T> Delete<T>(MyApiRequestModel apiRequestModel, bool withToken , params string[] parameters)
        {
            String uri = GetRequestUri(apiRequestModel, true, parameters);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, uri);
            return SendRequest<T>(request, withToken);
        }

        public BaseControllerResponseModel<T> SendRequest<T>(HttpRequestMessage request,bool withToken = false)
        {
            String token = HttpContext.Session.GetString(ReadOnlyValues.TokenSession);
            if (withToken && !String.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(ReadOnlyValues.AuthenticationScheme, token);
            }
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.SendAsync(request).Result;
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
                        errorViewModel = new ErrorViewModel(500, description:result.responseMessageModel.message); 
                        //ErrorViewModel.GetServerError;
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
        
        private MultipartFormDataContent ObjectToMultipartFormDataContent<T>(T item)
        where T : class
        {
            Type myObjectType = item.GetType();
            PropertyInfo[] properties = myObjectType.GetProperties();
            MultipartFormDataContent form = new MultipartFormDataContent();
            foreach (var info in properties)
            {
                var value = info.GetValue(item);
                if (value is IFormFile)
                {
                    IFormFile file = value as IFormFile;
                    var fileBytes = GetBytesFromFile(file);
                    form.Add(new ByteArrayContent(fileBytes, 0, fileBytes.Length), info.Name, file.FileName);
                }
                else if (value is String)
                {
                    form.Add(new StringContent(value as String), info.Name);
                }
                else if (value is Int32)
                {
                    form.Add(new StringContent(value.ToString()), info.Name);
                }
            }
            return form;

        }
        private byte[] GetBytesFromFile(IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}

