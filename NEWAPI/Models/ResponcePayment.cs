using NEWAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEWAPI.Models
{
    public class ResponcePayment
    {
        public ResponcePayment(Payments payments)
        {
            if (payments == null) return;
            ID = payments.ID;
            PaymentStatus = payments.PaymentStatusID;
        }
        public int ID { get; set; }
        public int PaymentStatus { get; set; }
    }
}