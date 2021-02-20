using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritionist.Web.Models
{
    public class BaseControllerResponseModel<TObject>
    {
        public TObject tobject { get; set; }

        public bool isSuccess { get;}
        public ErrorViewModel errorViewModel { get; set; }

        public BaseControllerResponseModel(TObject tobject)
        {
            this.tobject = tobject;
            isSuccess = true;
        }

        public BaseControllerResponseModel(ErrorViewModel errorViewModel)
        {
            this.errorViewModel = errorViewModel;
            isSuccess = false;
        }
        public bool IsValid()
        {
            if (tobject != null && isSuccess == true)
            {
                return true;
            }
            else return false;
        }

    }
}
