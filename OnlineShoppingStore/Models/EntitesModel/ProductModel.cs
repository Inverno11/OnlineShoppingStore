using OnlineShoppingStore.DatabasesModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Models.EntitesModel
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(100,ErrorMessage =" minimum character is 5 and maximum is 100", MinimumLength =5)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Range(1,50)]
        [Display(Name ="Category type")]
        public int CategoryId { get; set; }
        [Display(Name = "Available")]
        public Nullable<bool> IsActive { get; set; }
        [Display(Name = "Exist")]
        public Nullable<bool> IsDelete { get; set; }
        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Display(Name = "Modified Date")]
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
          [Display(Name = "Product Image")]

        public string ProductImage { get; set; }
        [Display(Name = "Featured")]
        public Nullable<bool> IsFeatured { get; set; }
        [Required]
        [Range(1,500,ErrorMessage = "Invalid quantity")]
        public Nullable<int> Quantity { get; set; }
        [Required]
        [Range(1,20000,ErrorMessage ="Invalid price")]
        public Nullable<decimal> Price { get; set; }
        [Display(Name ="Category")]
        public string CategoryName { set; get; }


        public HttpPostedFileBase ImageFile { set; get; }

        public SelectList Categories { set; get; }

        public SelectList Chooices { set; get; }
        [ScaffoldColumn(false)]
        public string search { set; get; }

    }
}