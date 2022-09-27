using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetproMax.Models
{
    public class FindPet
    {
        [Key]
        public int FindPetID { get; set; }

        [DisplayName("寵物姓名")]
        [StringLength(100)]
        [Required]
        public string PetName { get; set; }

        [DisplayName("寵物性別")]
        [Required]
        public bool PetSex { get; set; }

        [DisplayName("寵物種類")]
        [Required]
        public bool PetType { get; set; }

        [DisplayName("寵物品種")]
        [StringLength(50)]
        [Required]
        public string PetBreed { get; set; }

        [DisplayName("是否有晶片")]
        [Required]
        public bool PetTsmc { get; set; }

        [DisplayName("寵物相片")]
        [MaxLength]
        public string PetPhotoFile { get; set; }

        [DisplayName("走失日期")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime LostDate { get; set; }

        [DisplayName("遺失地點、時間、寵物習性、飼主聯絡方式")]
        [MaxLength]
        [Required]
        public string PetDescription { get; set; }

        [Required]
        public int MemberID { get; set; }

        public virtual Members Member { get; set; }

    }
}