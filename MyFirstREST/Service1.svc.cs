using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyFirstREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public UserWeb GetUserById(string userIdValue)
        {
            User user;

            using (var ctx = new Shop())
            {
                int findId = Int32.Parse(userIdValue);
                user = ctx.Users
                    .DefaultIfEmpty(new User
                    {
                        Id = -1,
                        Login = "empty",
                        Password = "empty"
                    })
                    .SingleOrDefault(e => e.Id == findId);
            }
            return new UserWeb { Id = user.Id, Login = user.Login, Password = user.Password };
        }

        public bool IsUserRegistered(string loginInput, string passwordInput)
        {
            //using (var ctx = new EmployersDB())
            //{
            //    return ctx.Employers
            //        .Any(e => e.Login == loginInput && e.Password == passwordInput) ;
            //}

            return true;
        }

        public string RegisterUser(string loginInput, string passwordInput)
        {
            using (var ctx = new Shop())
            {
                var old = ctx.Users.Count();
                ctx.Users.Add(new User { Login = loginInput, Password = passwordInput });
                var newQty = ctx.Users.Count();
                return $"Old q-ty {old}, new q-ty {newQty}";
            }
        }
    }
}
