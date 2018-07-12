using EasyHousingSolutions_DAL;
using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_BLL
{
    public class UsersValidations
    {
        UsersOperations uv = null;
        public bool AddUser(User newUser)
        {
            bool sellerAdded = false;
            try
            {
                uv = new UsersOperations();
                {

                    uv.AddUser(newUser);
                }
            }
            catch (UserException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return sellerAdded;
        }

        public User LoginUser(User login)
        {

            try
            {
                uv = new UsersOperations();
                {
                    return uv.LoginUser(login);
                }
            }
            catch (UserException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
    }
}
