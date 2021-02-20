using System;

namespace Nutritionist.Web.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(int statusCode=0, string title="Hata!", string description="Açýklama belirtilmemiþ.")
        {
            StatusCode = statusCode;
            Title = title;
            Description = description;
        }

        public int StatusCode { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }


        public static ErrorViewModel GetDefaultException => new ErrorViewModel(0, "Ýstisna", "Beklenmedik bir durum meydana geldi !");
        public static ErrorViewModel GetServerError => new ErrorViewModel(500, "Sunucu Hatasý", "Ýsteðin çalýþtýrýlmasý sýrasýnda hata meydana gelmiþtir.");
        public static ErrorViewModel GetClientError(String exception) => new ErrorViewModel(400, "Ýstemci Hatasý", "Ýsteðin çalýþtýrýlmasý sýrasýnda hata meydana gelmiþtir.Detay : " + exception);

    }
}
