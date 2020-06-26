using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Model.Dao
{
    public class UserDao
    {
        private OnlineSMSystemDB db = null;

        public UserDao()
        {
            db = new OnlineSMSystemDB();
        }



        public bool EditAdmin( Member entity)
        {
            try
            {
                var user = db.Members.Find(entity.MemberID);
                user.LastName = entity.LastName;
                user.FirstName = entity.FirstName;
                user.BirthDate = entity.BirthDate;
                user.CMND = entity.CMND;
                user.District = entity.District;
                user.Province = entity.Province;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  Member GetUser(string UserName)
        {
            return db.Members.SingleOrDefault(x => x.UserName == UserName);
        }
        public Member GetByID(string UserName)
        {
            return db.Members.SingleOrDefault(x => x.UserName == UserName);
        }

       

        public bool LoginMember(string Username, string Password)
        {
            var result = db.Members.Count(x => x.UserName == Username && x.PassWord == Password && x.GroupID == "MEMBER");
            if (result > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool LoginAdmin(string Username, string Password)
        {
            var result = db.Members.Count(x => x.UserName == Username && x.PassWord == Password && x.GroupID == "ADMIN");
            if (result > 0)
            {
                return true;
            }
            else
                return false;
        }



        public bool CheckUserName(string UserName)
        {
            return db.Members.Count(x => x.UserName == UserName) > 0;
        }

        public bool CheckUserEmail(string Email)
        {
            return db.Members.Count(x => x.Email == Email) > 0;
        }

        public Member Checkusser(string email)
        {
            object[] sqlParams =
       {
                new SqlParameter("@Email",email)
            };
            return db.Database.SqlQuery<Member>("sp_FindMemberByEmail @Email", sqlParams).Single();
        }

        public bool CheckMemberEmailProfile(string Email)
        {
            return db.Members.Count(x => x.Email == Email) > 1;
        }

        public bool CheckMemberPhone(string phone)
        {
            return db.Members.Count(x => x.Phone == phone) > 1;
        }

        public IEnumerable<Member> ListAllPaging(string searchString, int page, int pageSize)
        {
            /// bản dùng được
            IQueryable<Member> model = db.Members.Where(x => x.GroupID == "MEMBER");
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString));
            }

            return model.OrderBy(x => x.GroupID).ToPagedList(page, pageSize);

            ////////////////////////////
            ///// bản thử chuyển qua sql

            //SqlParameter sqlParameter = new SqlParameter("@groupID", "MEMBER");
            //IQueryable<Member> model = db.Database.SqlQuery<Member>("select *from dbo.fu_ListMember(@groupID)", sqlParameter).AsQueryable();

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    model = model.Where(x => x.UserName.Contains(searchString) && x.GroupID == "MEMBER");
            //}

            //return model.ToPagedList(page, pageSize);
        }

        public bool ThemUser(string username, string password, string email, bool? status, string verifycode)
        {
            try
            {
                object[] sqlParams =
                {
                new SqlParameter("@UserName",username),
                new SqlParameter("@Password",password),
                new SqlParameter("@Email",email),
                new SqlParameter("@Status",status),
                new SqlParameter("@Verifycode",verifycode)
            };
                long res = db.Database.ExecuteSqlCommand("Sp_Registration @UserName, @Password, @Email, @Status, @Verifycode", sqlParams);
                return true;
            }
            catch { return false; }
        }

        public Member GetByUserName(string UserName)
        {
            object[] sqlParams =
           {
                new SqlParameter("@UserName",UserName)
            };
            return db.Database.SqlQuery<Member>("sp_FindUserName @UserName", sqlParams).Single();
        }


        public bool updateVerifyCode(string username, string verifycode)
        {
            try
            {
                object[] sqlParams =
                {
                new SqlParameter("@Username",username),
                new SqlParameter("@Verifycode",verifycode),

            };
                long res = db.Database.ExecuteSqlCommand("Sp_Registration @Username, @Verifycode", sqlParams);
                return true;
            }
            catch { return false; }
        }

        public bool kiemTraMXN(string username, bool? status)
        {
            try
            {
                object[] sqlParams =
                {
                new SqlParameter("@UserName",username),             
                new SqlParameter("@Status",status)
                };
                var res = db.Database.ExecuteSqlCommand("Sp_UpdateStatus @UserName, @Status", sqlParams);
                return true;
            }
            catch { return false; }
        }

    }
}