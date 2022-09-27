using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PetproMax.Models.Enum;

namespace PetproMax.Models.Enum
{
    public enum FamilyEnum
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
    public class HomeLessAnimal
    {
        [Key]
        public int HomeLessAnimalID { get; set; }

        [DisplayName("流浪動物簡述(例如:高雄鼓山粉紅豹)")]
        [StringLength(50)]
        [Required]
        public string HomeLessAnimalName { get; set; }        

        [DisplayName("流浪動物性別")]
        [Required]
        public bool AnimalSex { get; set; }

        [DisplayName("流浪動物種類")]
        [Required]
        public bool Type { get; set; }

        [DisplayName("流浪動物品種")]
        [StringLength(50)]
        [Required]
        public string Breed { get; set; }

        [DisplayName("是否有晶片")]
        [Required]
        public bool Tsmc { get; set; }

        [DisplayName("相片")]
        [MaxLength]
        public string AnimalPhotoFile { get; set; }

        [DisplayName("拾獲日期")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime GetDate { get; set; }

        [DisplayName("拾獲地點、時間、拾獲人聯絡方式")]
        [MaxLength]
        [Required]
        public string HLADescription { get; set; }

        [DisplayName("中途期限")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpireDate { get; set; }

        [DisplayName("期限內無飼主認領，將送往")]
        public FamilyEnum FamilyName { get; set; }

        [Required]
        public int MemberID { get; set; }

        public virtual Members Member { get; set; }

    }
}