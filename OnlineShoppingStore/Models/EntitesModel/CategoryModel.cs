using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingStore.Models.EntitesModel
{
    public class CategoryModel
    {
        [Display(Name = "No")]
        public string CategoryId { get; set; }
        [Required (ErrorMessage = " Name is Required ")]
        [StringLength(100,MinimumLength =3 ,ErrorMessage = "minimum is 3 character and maximum is 100")]
        [Display(Name ="Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Available")]
        public Nullable<bool> IsActive { get; set; }
        [Display(Name = "Exist")]
        public Nullable<bool> IsDelete { get; set; }

    }
}