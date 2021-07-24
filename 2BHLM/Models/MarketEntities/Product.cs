using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLST.Models.MarketEntities
{
    public class Product
    {
        [Key]
        [DisplayName("ID sản phẩm:")]
        public int IDproduct { get; set; }

        [DisplayName("Tiêu đề sản phẩm: ")]
        public string Title { get; set; }

        [DisplayName("Giá: ")]
        public double Price { get; set; }

        [DisplayName("Mô tả: ")]
        public string Description { get; set; }


        [ForeignKey("DetailReceipt")]
        public int IDReceipt { get; set; }
        public DetailReceipt DetailReceipt { get; set; }

        public ICollection<UserInfo> UserInfos { get; set; }
    }
}