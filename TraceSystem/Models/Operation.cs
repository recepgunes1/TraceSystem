using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TraceSystem.Models
{
    public class Operation
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen müşterinin ismini giriniz.")]
        [Display(Name = "Müşteri İsmi")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Lütfen bir telefon numarası giriniz.")]
        [Display(Name = "Müşteri İletişim No")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz."),
            StringLength(10, ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz.")]
        public string? CustomerContact { get; set; }

        [Required(ErrorMessage = "Lütfen bir cihaz bilgisi giriniz.")]
        [Display(Name = "Cihaz")]
        public string? Device { get; set; }

        [Display(Name = "Cihazın Görünüşü")]
        public string? DeviceAppearance { get; set; }

        [Display(Name = "Cihazın Sorunu")]
        public string? DeviceFault { get; set; }

        [Display(Name = "Cihazın Aksesuarları")]
        public string? DeviceAccessory { get; set; }

        [Required(ErrorMessage = "Lütfen bir IMEI bilgisi giriniz.")]
        [Display(Name = "IMEI")]
        [RegularExpression(@"^(\d{15})$", ErrorMessage = "Lütfen geçerli bir IMEI adresi giriniz."),
            StringLength(15, ErrorMessage = "Lütfen geçerli bir IMEI adresi giriniz.")]
        public string? DeviceIMEI { get; set; }

        [Display(Name = "Cihazın Parolası")]
        public string? DevicePassword { get; set; }

        [Required(ErrorMessage = "Lütfen bir yapılacak işlemi giriniz.")]
        [Display(Name = "Yapılacak İşlem")]
        public string? FaultOperation { get; set; }

        [Required(ErrorMessage = "Lütfen bir ücret bilgisi giriniz.")]
        [Display(Name = "Ücret")]
        public int Price { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        [Display(Name = "Teslim Tarihi")]
        public DateTime? DeliveryDate { get; set; }

        [Display(Name = "Durum")]
        public bool DeliveryStatus { get; set; } = false;

        [Display(Name = "Açıklama")]
        public string? Explanation { get; set; }

        public override string ToString()
        {
            return $"<Operation - {ID}>";
        }
    }
}
