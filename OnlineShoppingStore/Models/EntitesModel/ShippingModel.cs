using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingStore.Models.EntitesModel
{
    public class ShippingModel
    {

        public int ShippingDetailId { get; set; }//
        public string MemberId { get; set; }//
        public string Adress { get; set; }//
        public string FirstName { get; set; }//
        public string LastName { get; set; }//
        public string PhoneNumber { get; set; }
        public string City { get; set; }//
        public string State { get; set; }//
        public string Country { get; set; }//
        public string ZipCode { get; set; }//
        public Nullable<decimal> AmountPaid { get; set; }
        public string PaymentType { get; set; }
        public Nullable<int> BasketId { get; set; }
        public Nullable<System.DateTime> DeliverdOn { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }



    }
}