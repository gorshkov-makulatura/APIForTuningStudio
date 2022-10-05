using NEWAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEWAPI.Models
{
    public class ResponseOrder
    {
        public ResponseOrder(Orders orders)
        {
            if (orders == null) return;
            ID = orders.ID;
            ClientID = (int)orders.ClientID;
            ManagerID = orders.ManagerID;
            MechanicID = orders.MechanicID;
            CarID = orders.CarID;
            DateRegister = orders.DateRegister.Value.ToString("dd/MM/yyyy HH:mm:ss");
            TotalCost = orders.TotalCost;
            if (TotalCost == null)
                TotalCost = 0;
            OrderStatusID = orders.OrderStatusID;

            if (orders.StartTime != null)
                StartTime = orders.StartTime.Value.ToString("dd/MM/yyyy HH:mm:ss");
            else
                StartTime = "";

            if (orders.EndTime != null)
                EndTime = orders.EndTime.Value.ToString("dd/MM/yyyy HH:mm:ss");
            else
                EndTime = "";


            PaymentID = (int)orders.PaymentID;
            ClientSecondName = orders.Users.SecondName;
            OrderStatusName = orders.OrderStatuses.Name;
            ClientPhone = orders.Users.PhoneNumber;
            if (orders.Users1 != null)
                FIOManager = orders.Users1.SecondName + " " + orders.Users1.FirstName[0] + "." + orders.Users1.LastName[0] + ".";
            else
                FIOManager = "";
            if (orders.Users2 != null)
                FIOMechanic = orders.Users2.SecondName + " " + orders.Users2.FirstName[0] + "." + orders.Users2.LastName[0] + ".";
            else
                FIOMechanic = "";
            orderStatus = orders.OrderStatuses.Name;
        }
        //Изменить формат даты, чтоб пацики на сайте могли чётко видеть, okay?
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int ?ManagerID { get; set; }
        public int ?MechanicID { get; set; }
        public int ?CarID { get; set; }
        public string DateRegister { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public int OrderStatusID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int PaymentID { get; set; }
        public string ClientSecondName { get; set; }
        public string OrderStatusName { get; set; }
        public string ClientPhone { get; set; }
        public string FIOManager  {get;set;}
        public string FIOMechanic { get; set; }
        public string orderStatus { get; set; }

    }
}