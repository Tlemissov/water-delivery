using System.ComponentModel.DataAnnotations;

namespace WaterDelivery.Mvc.Models
{
    public class OrderDto
    {
        [Required(ErrorMessage = "Не указан Ф.И.О")]
        [MaxLength(64)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        [MaxLength(128)]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        [MaxLength(12)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан количество")]
        [Range(1, 100, ErrorMessage = "Количество должно быть от 1 до 100.")]
        public byte Quantity { get; set; }
    }
}
