using NEWAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEWAPI.Models
{
    public class ResponceMaterial
    {   
        public ResponceMaterial(Materials materials)
        {
            if (materials == null) return;
            ID = materials.ID;
            IDMaterialType = materials.IDMaterialType;
            Photo = materials.Photo;
            Name = materials.Name;
            StockStatus = materials.StockStatus;
            RetailPrice = materials.RetailPrice;
            MaterialTypeName = materials.MaterialsType.Name;
            Quantity = (int)materials.Quantity;
          
        }
        public int ID { get; set; }
        public int IDMaterialType { get; set; }
        public byte[] Photo { get; set; }
        public string Name { get; set; }
        public bool StockStatus { get; set; }
        public Nullable<decimal> RetailPrice { get; set; }
        public string MaterialTypeName { get; set; }
        public int Quantity { get; set; }
    }

}