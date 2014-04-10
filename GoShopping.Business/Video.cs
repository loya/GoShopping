using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoShopping.Business
{
    public class Video
    {
        [Display(Name="影片代码")]
        [Required(ErrorMessage="{0}不可空白")]
        [StringLength(11,ErrorMessage="{0}必须是{1}个字符")]
        [UIHint("Video")]
        public string Id { get; set; }

        [Display(Name="影片标题")]
        [Required (ErrorMessage="{0}不可为空")]
        [MaxLength(20)]
        public string Title { get; set; }

        [UIHint("Date")]
        [Display(Name="开始日期")]
        public DateTime StartDate { get; set; }

        [UIHint("Date")]
        [Display(Name="结束日期")]
        public DateTime EndDate { get; set; } 
    }
}
