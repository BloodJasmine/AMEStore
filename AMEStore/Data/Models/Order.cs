using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMEStore.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        
        
        [Display(Name = "Введите имя")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина имени не может превышать 20 символов")]
        public string Name { get; set; }
        
        
        [Display(Name = "Введите фамилию")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина фамилии не может превышать 20 символов")]
        public string Surname { get; set; }
        
        
        [Display(Name = "Введите адресс")]
        [StringLength(40)]
        [Required(ErrorMessage = "Длина адреса не может превышать 40 символов")]
        public string Adress { get; set; }
        

        [Display(Name = "Введите телефон")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина телефона не может превышать 15 символов")]
        public string Phone { get; set; }
        
        
        [Display(Name = "Введите E-mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина email не может превышать 20 символов")]
        public string Email { get; set; }

        
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        [BindNever]
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
