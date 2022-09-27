using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace PetproMax.Models
{
    public class MMLogin
    {
        [DisplayName("帳號")]
        [Required(ErrorMessage = "請填寫帳號")]
        [StringLength(20, ErrorMessage = "帳號不得超過20字")]
        [RegularExpression("[A-Za-z][A-Za-z0-9]{4,19}", ErrorMessage = "帳號格式錯誤")]
        public string Account { get; set; }

        string password;

        [DisplayName("密碼")]
        [Required(ErrorMessage = "請填寫密碼")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "密碼最少8碼")]
        [MaxLength(20, ErrorMessage = "密碼最多20碼")]
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
    }
}