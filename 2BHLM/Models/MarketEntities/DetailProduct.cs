using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLST.Models.MarketEntities
{
    public class DetailProduct
    {
        [Key]
        [DisplayName("Số thứ tự: ")]
        public int No { get; set; }
        
        [DisplayName("Nơi xuất xứ: ")]
        public string Madein { get; set; }

        [DisplayName("Tiêu đề sản phẩm: ")]
        public string Title { get; set; }

        [DisplayName("Giới thiệu sản phẩm: ")]
        public string Description { get; set; }

        [DisplayName("Giá trị dinh dưỡng: ")]
        public string NutriousInfo { get; set; }

        [DisplayName("Thời gian sản xuất: ")]
        public DateTime ProducedTime { get; set; }

        [DisplayName("Hạn sử dụng: ")]
        public DateTime ExpiredDate { get; set; }

        


    }
}