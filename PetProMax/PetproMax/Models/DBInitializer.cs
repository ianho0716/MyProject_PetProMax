using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace PetproMax.Models
{
    public class DBInitializer : DropCreateDatabaseAlways<PetproContext>
    {
        protected override void Seed(PetproContext context)
        {
            base.Seed(context);

            // byte[] getFileBytes(string path)
            //{
            //    FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);

            //    byte[] fileBytes;

            //    using (BinaryReader br = new BinaryReader(fileOnDisk))
            //    {
            //        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            //    }


            //    return fileBytes;
            //}

            List<Members> members = new List<Members>
            {
                new Members
                {
                   MemberName="野原美冴",
                   Gender=false,
                   MemberBirthday=Convert.ToDateTime("1991/7/9"),
                   CreatedDate=DateTime.Today,
                   Account="apple",
                   Password= "zzzzzzzz"
                },

                new Members
                {
                   MemberName="野原廣志",
                   Gender=true,
                   MemberBirthday=Convert.ToDateTime("1991/7/16"),
                   CreatedDate=DateTime.Today,
                   Account="apple1",
                   Password= "zzzzzzzz"
                },

                new Members
                {
                   MemberName="野原新之助",
                   Gender=true,
                   MemberBirthday=Convert.ToDateTime("2022/5/5"),
                   CreatedDate=DateTime.Today,
                   Account="apple2",
                   Password= "zzzzzzzz"
                },

                new Members
                {
                   MemberName="野原葵",
                   Gender=false,
                   MemberBirthday=Convert.ToDateTime("2022/5/5"),
                   CreatedDate=DateTime.Today,
                   Account="apple3",
                   Password= "zzzzzzzz"
                }
            };

            members.ForEach(s => context.Members.Add(s));
            context.SaveChanges();


            List<Shippers> shippers = new List<Shippers>
            {
                new Shippers
                {
                   ShipVia="超商取貨"
                },
                new Shippers
                {
                   ShipVia="宅配到府"
                },
                new Shippers
                {
                   ShipVia="郵寄"
                }
            };

            shippers.ForEach(s => context.Shippers.Add(s));
            context.SaveChanges();

            List<PayTypes> payType = new List<PayTypes>
            {
                new PayTypes
                {
                   PayTypeName="信用卡"
                },
                new PayTypes
                {
                   PayTypeName="Line Pay"
                },
                new PayTypes
                {
                   PayTypeName="貨到付款"
                },
                new PayTypes
                {
                   PayTypeName="便利店代收"
                },
                new PayTypes
                {
                   PayTypeName="轉帳"
                }
            };

            payType.ForEach(s => context.PayTypes.Add(s));
            context.SaveChanges();

            List<Employees> employees = new List<Employees>
            {
                new Employees
                {
                   EmployeeName="漩渦鳴人",
                   CreatedDate=DateTime.Today,
                   Account="naruto",
                   Password="xji6vm06j06"
                }
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            /////////////////////////////////////////////////////////////////////////////


        }
    }
}