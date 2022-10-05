using NEWAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEWAPI.Models
{
    public class ResponceServices
    {
        public ResponceServices(TypeOfServices service)
        {
            if (service == null) return;
            ID = service.ID;
            Name = service.Name;
            IdMaterialType = service.IdMaterialType;
            Cost = service.Cost;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int? IdMaterialType { get; set; }
        public decimal Cost { get; set; }
    }
}