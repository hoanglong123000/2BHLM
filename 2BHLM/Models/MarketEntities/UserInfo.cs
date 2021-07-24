using _2BHLM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLST.Models.MarketEntities
{
    public class UserInfo
    { 
        [Key]
        public int IDUserInfo { get; set; }

        [ForeignKey("Product")]
        public int IDproduct { get; set; }
        public Product Product { get; set; }

        [DisplayName("ID người dùng: ")]
        public string CustomerID { get; set; }
        public ApplicationUser Customer { get; set; }

       

    }
}