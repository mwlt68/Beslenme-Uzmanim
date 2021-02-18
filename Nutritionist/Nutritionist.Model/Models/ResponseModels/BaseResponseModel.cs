using Nutritionist.Core.StaticDatas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nutritionist.Core.Models.ResponseModels
{
    public enum ResponseMessageType
    {
        Success,
        Unexpected,
        Exception,
        Error,
        FatalError,
    }
    public class BaseResponseModel
    {
        public ResponseMessageModel responseMessageModel { get; set; }

        // This constructor  will create a error response.
        public BaseResponseModel()
        {
            responseMessageModel = new ResponseMessageModel(false,ReadOnlyValues.ErrorMessage,ResponseMessageType.Error);
        }
        // This constructor  will create a error response with argument message.
        public BaseResponseModel(String message)
        {
            responseMessageModel = new ResponseMessageModel(false, message, ResponseMessageType.Error);
        }
    }
    public class SuccessResponseModel<TResponseObj> : BaseResponseModel
    {
        public TResponseObj responseObj { get; set; }

        // This constructor  will create a successfully response.
        public SuccessResponseModel()
        {

        }
        public SuccessResponseModel(TResponseObj responseObj)
        {
            this.responseObj = responseObj;
            responseMessageModel = new ResponseMessageModel();
        }

        public SuccessResponseModel(ResponseMessageModel responseMessageModel, TResponseObj responseObj)
        {
            this.responseMessageModel = responseMessageModel;
            this.responseObj = responseObj;
        }
    }

    public class ResponseMessageModel
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public ResponseMessageType responseMessageType { get; set; }

        // This constructor  will create a successfully response message.
        public ResponseMessageModel()
        {
            isSuccess = true;
            message = ReadOnlyValues.SuccessMessage;
            responseMessageType = ResponseMessageType.Success;
        }
        public ResponseMessageModel(bool isSuccess, string message, ResponseMessageType responseMessageType)
        {
            this.isSuccess = isSuccess;
            this.message = message;
            this.responseMessageType = responseMessageType;
        }
    }
}
