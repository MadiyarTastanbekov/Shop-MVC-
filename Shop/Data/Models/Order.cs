using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name ="Введите имя")]
        [MinLength(5)]
        [MaxLength(30)]
        [Required(ErrorMessage ="Длина имени должно быть немее 5 символов")]
        public string name { get; set; }
        [Display(Name = "Фамилия")]
        [MinLength(5)]
        [MaxLength(30)]
        [Required(ErrorMessage = "Длина фамилии должно быть немее 5 символов")]
        public string surname { get; set; }
        [Display(Name = "Адрес")]
        [MinLength(10)]
        [MaxLength(50)]
        [Required(ErrorMessage = "Длина адреса должно быть немее 10 символов")]
        public string adress { get; set; }
        [Display(Name = "Телефон")]
        [Phone]
        [StringLength(20, MinimumLength = 11)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Введите только число")]
        [Required(ErrorMessage = "Длина телефона должно быть немее 11 символов")]
        public string phone { get; set; }
        [Display(Name = "Еmail ")]
        [MinLength(10)]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина Еmail должно быть немее 10 символов")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
