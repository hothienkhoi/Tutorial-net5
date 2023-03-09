using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{
    [Table("LoaiHangHoa")]
    public class LoaiHoangHoaEntity
    {
        [Key]
        public int MaLoai { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenLoai { get; set; }

        public virtual ICollection<HangHoaEntity> HangHoas { get; set; }
    }
}
