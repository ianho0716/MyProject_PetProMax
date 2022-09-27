using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace PetproMax.Models
{
    public class Members
    {

        [Key]
        [DisplayName("會員編號")]
        public int MemberID { get; set; }

        [DisplayName("姓名")]
        [StringLength(100)]
        [Required]
        public string MemberName { get; set; }

        [DisplayName("性別")]
        public bool Gender { get; set; }

        [DisplayName("生日")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime MemberBirthday { get; set; }

        [DisplayName("建立日期")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }


        [DisplayName("帳號")]
        [Required]
        [StringLength(20)]
        [CheckAccount]
        public string Account { get; set; }

        //field
        string password;  //定義一個password的field

        [DisplayName("密碼")]
        [Required]
        [DataType(DataType.Password)]

        public string Password
        {
            get
            {
                return password;

            }
            set
            {
                byte[] hashValue;
                string result = "";

                System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();

                byte[] pwBytes = ue.GetBytes(value);

                SHA256 shHash = SHA256.Create();

                hashValue = shHash.ComputeHash(pwBytes);

                foreach (byte b in hashValue)
                {
                    result += b.ToString();
                }

                password = result;
            }

        }


        //自訂驗證規則的寫法
        public class CheckAccount : ValidationAttribute
        {

            public CheckAccount()
            {
                ErrorMessage = "此帳號有人使用";
            }
            public override bool IsValid(object value)
            {
                if (value == null)
                    value = "aa";

                PetproContext db = new PetproContext();

                var account = db.Members.Where(m => m.Account == value.ToString()).FirstOrDefault();

                return (account == null) ? true : false;
            }
        }


    }
}