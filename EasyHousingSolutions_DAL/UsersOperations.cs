using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_DAL
{
    public class UsersOperations
    {
        EasyHousingSolutions_Entities entityObj = null;
        public void AddUser(User newUser)
        {
            try
            {
                entityObj = new EasyHousingSolutions_Entities();
                entityObj.Users.Add(newUser);
                entityObj.SaveChanges();
            }
            catch(UserException )
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User LoginUser(User login )
        {
            entityObj = new EasyHousingSolutions_Entities();
            var prp = new User();
            try
            { 
             prp = (from user in entityObj.Users
                      where user.UserName == login.UserName && user.Password == login.Password
                      select user).FirstOrDefault();
             }
            catch(UserException )
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;
        }
    }
}
