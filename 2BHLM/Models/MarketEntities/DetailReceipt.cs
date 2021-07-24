using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLST.Models.MarketEntities
{
    public class DetailReceipt
    {
        [Key]
        [DisplayName("ID hóa đơn: ")]
        public int IDReceipt { get; set; }



        [DisplayName("Thời gian lập hóa đơn: ")]
        public DateTime ReceiptDate { get; set; }



        [DisplayName("Số lượng sản phẩm: x")]
        public int ProductAmmount { get; set; }

        [DisplayName("Tổng tiền tất cả: ")]
        public double TotalPrice { get; set; }

        public ICollection<Product> Products { get; set; }


    }
}