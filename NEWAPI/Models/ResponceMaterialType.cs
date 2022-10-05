using NEWAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEWAPI.Models
{
    public class ResponceMaterialType
    {
        public ResponceMaterialType(MaterialsType materialsType)
        {
            if (materialsType == null) return;
            ID = materialsType.ID;
            Name = materialsType.Name;
            ProcentRetailPrice = materialsType.ProcentRetailPrice;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public byte ProcentRetailPrice { get; set; }
    }
}