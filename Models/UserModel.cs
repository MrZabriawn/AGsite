using AGsite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGsite.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class UserHelper
    {
        private SurveyDataContext context { get; set; }

        public UserHelper(SurveyDataContext Context)
        {
            context = Context;
        }

        public UserModel GetUser(string Email)
        {
            var user = context.Users.Where(u => u.Email == Email).FirstOrDefault();
            if(user == null)
            {
                user = new UserModel();
                user.Email = Email;
                if(context.Users.Count() == 0)
                {
                    user.IsAdmin = true;
                }
                context.Users.Add(user);
                context.SaveChanges();
            }

            return user;
        }
    }
}
