using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PetproMax.Models.Enum;

namespace PetproMax.Models.Enum
{
    public enum FamiliesEnum
    {
        [Display(Name = "新北市政府動物保護防疫處")]
        新北市政府動物保護防疫處 = 0,
        [Display(Name = "新北市新店區公立動物之家")]
        新北市新店區公立動物之家 = 1,
        [Display(Name = "新北市板橋區公立動物之家")]
        新北市板橋區公立動物之家 = 2,
        [Display(Name = "新北市中和區公立動物之家")]
        新北市中和區公立動物之家 = 3,
        [Display(Name = "新北市淡水區公立動物之家")]
        新北市淡水區公立動物之家 = 4,
        [Display(Name = "新北市瑞芳區公立動物之家")]
        新北市瑞芳區公立動物之家 = 5,
        [Display(Name = "新北市五股區公立動物之家")]
        新北市五股區公立動物之家 = 6,
        [Display(Name = "新北市八里區公立動物之家")]
        新北市八里區公立動物之家 = 7,
        [Display(Name = "新北市三芝區公立動物之家")]
        新北市三芝區公立動物之家 = 8,
        [Display(Name = "宜蘭縣流浪動物中途之家")]
        宜蘭縣流浪動物中途之家 = 9,
        [Display(Name = "桃園市動物保護教育園區")]
        桃園市動物保護教育園區 = 10,
        [Display(Name = "新竹縣公立動物收容所")]
        新竹縣公立動物收容所 = 11,
        [Display(Name = "苗栗縣生態保育教育中心(動物收容所)")]
        苗栗縣生態保育教育中心動物收容所 = 12,
        [Display(Name = "臺中市動物之家南屯園區")]
        臺中市動物之家南屯園區 = 13,
        [Display(Name = "臺中市動物之家后里園區")]
        臺中市動物之家后里園區 = 14,
        [Display(Name = "彰化縣流浪狗中途之家")]
        彰化縣流浪狗中途之家 = 15,
        [Display(Name = "南投縣公立動物收容所")]
        南投縣公立動物收容所 = 16,
        [Display(Name = "雲林縣流浪動物收容所")]
        雲林縣流浪動物收容所 = 17,
        [Display(Name = "嘉義縣流浪犬中途之家")]
        嘉義縣流浪犬中途之家 = 18,
        [Display(Name = "高雄市壽山動物保護教育園區")]
        高雄市壽山動物保護教育園區 = 19,
        [Display(Name = "高雄市燕巢動物保護關愛園區")]
        高雄市燕巢動物保護關愛園區 = 20,
        [Display(Name = "屏東縣公立犬貓中途之家")]
        屏東縣公立犬貓中途之家 = 21,
        [Display(Name = "臺東縣動物收容中心")]
        臺東縣動物收容中心 = 23,
        [Display(Name = "花蓮縣狗貓躍動園區")]
        花蓮縣狗貓躍動園區 = 24,
        [Display(Name = "澎湖縣流浪動物收容中心")]
        澎湖縣流浪動物收容中心 = 25,
        [Display(Name = "基隆市寵物銀行")]
        基隆市寵物銀行 = 26,
        [Display(Name = "新竹市動物保護教育園區")]
        新竹市動物保護教育園區 = 27,
        [Display(Name = "嘉義市動物保護教育園區")]
        嘉義市動物保護教育園區 = 28,
        [Display(Name = "臺南市動物之家灣裡站")]
        臺南市動物之家灣裡站 = 29,
        [Display(Name = "臺南市動物之家善化站")]
        臺南市動物之家善化站 = 30,
        [Display(Name = "臺北市動物之家")]
        臺北市動物之家 = 31,
        [Display(Name = "連江縣流浪犬收容中心")]
        連江縣流浪犬收容中心 = 32,
        [Display(Name = "金門縣動物收容中心")]
        金門縣動物收容中心 = 33,
    }
}

namespace PetproMax.Models
{
    public class Applied
    {
        [Key]
        public int AppliedID { get; set; }

        [DisplayName("認養申請編號~請參閱全國流浪動物認養資訊")]
        [StringLength(20)]
        public string AnimalID { get; set; }

        [DisplayName("流浪動物之家名稱")]
        public FamilyEnum FamiliesName { get; set; }  

        [DisplayName("請簡單自我介紹，需提及[年齡、是否有收入、居住地是否能養寵物]!")]
        [MaxLength]
        [Required]
        public string Description { get; set; }

        [DisplayName("申請人")]
        [Required]
        public int MemberID { get; set; }

        public virtual Members Member { get; set; }
    }
}