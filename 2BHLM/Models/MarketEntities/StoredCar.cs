using QLST.Models.MarketEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2BHLM.Models.MarketEntities
{
    public class StoredCar
    {
        [Key]
        [DisplayName("Mã kho: ")]
        public int Idstore { get; set; }

        [DisplayName("Tên hàng hóa: ")]
        public string Titleofproduct { get; set; }

        [DisplayName("Số lượng: x")]
        public int AmmountofProduct { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}