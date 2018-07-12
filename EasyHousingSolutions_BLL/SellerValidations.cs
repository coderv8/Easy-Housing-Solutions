using EasyHousingSolutions_DAL;
using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyHousingSolutions_BLL
{
    public class SellerValidations
    {
        SellerOperations e = null;
        private static bool ValidateSeller(Seller seller)
        {


            StringBuilder sb = new StringBuilder();
            bool validSeller = true;


            if (seller.FirstName == string.Empty)
            {
                validSeller = false;
                sb.Append(Environment.NewLine + "First Name Required");
            }
            else
            if (!(Regex.IsMatch(seller.FirstName, @"^[a-zA-Z ]{0,25}")))
            {
                validSeller = false;
                sb.Append(Environment.NewLine + "First Name should contain only characters.");
            }

            if (!(Regex.IsMatch(seller.LastName, @"^[a-zA-Z ]{0,25}")) && seller.LastName != string.Empty)
            {
                validSeller = false;
                sb.Append(Environment.NewLine + "Last Name should contain only characters.");
            }

            if (!(Regex.IsMatch(seller.PhoneNo, @"^[7-9]{1}[0-9]{9}")))
            {
                validSeller = false;
                sb.Append(Environment.NewLine + "Contact number should contain only numbers.");
            }

            if (!(Regex.IsMatch(seller.UserName, @"^[a-zA-Z0-9]{0,25}")))
            {
                validSeller = false;
                sb.Append(Environment.NewLine + "UserName should contain only characters.");
            }


            if (seller.DateofBirth > DateTime.Now && seller.DateofBirth < DateTime.Parse("1/1/1940") || seller.DateofBirth == null)
            {
                validSeller = false;
                sb.Append(Environment.NewLine + "Enter Valid DateOfBirth");
            }

            if (!Regex.IsMatch(seller.EmailId, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
            {
                validSeller = false;
                sb.Append(Environment.NewLine + "Enter Valid EmailID");
            }

            //if (Regex.IsMatch(seller.Password, @"^(?=.*[a - z])(?=.*[A - Z])(?=.*\d)(?=.*[^\da - zA - Z]).{8,15}$"))
            //{
            //    validSeller = false;
            //    sb.Append(Environment.NewLine + "Your password must contain atleat 1 uppercase 1 lowercase 1 digit 1 special character");
            //}

            if (validSeller == false)
                throw new SellerException(sb.ToString());
            return validSeller;
        }

        public bool AddSeller(Seller newSeller)
        {
            bool sellerAdded = false;
            try
            {
                e = new SellerOperations();
                if (ValidateSeller(newSeller))
                {
                    e.AddSeller(newSeller);
                }
            }
            catch (SellerException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return sellerAdded;
        }


        public void AddProperty(Property newProperty)
        {
            
            try
            {
                e = new SellerOperations();
                {
                    e.AddProperty(newProperty);
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

        public bool UpdateProperty(Property newProperty)
        {
            bool sellerAdded = false;
            try
            {
                e = new SellerOperations();
               
                {
                    e.UpdateProperty(newProperty);
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


        public List<Property> viewProp(int sellerID, bool? status)
        {
            
            try
            {
                e = new SellerOperations();
                
                {
                    return e.viewProperties(sellerID, status);
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

        public List<Property> viewProp(int sellerID)
        {
            
            try
            {
                e = new SellerOperations();
                {
                    return e.viewProperties(sellerID);
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

        public Property GetProp(int propId)
        {

            try
            {
                e = new SellerOperations();
                return e.GetProp(propId);

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

        public List<City> GetCities(int stateId)
        {

            try
            {
                e = new SellerOperations();
                return e.GetCity(stateId);

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

        public List<State> Get_State(int stateId)
        {

            try
            {
                e = new SellerOperations();
                return e.Get_State(stateId);

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

        public List<City> Get_City(int cityId)
        {

            try
            {
                e = new SellerOperations();
                return e.Get_City(cityId);

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

        public int SellerId(string userName)
        {

            try
            {
                e = new SellerOperations();
                return e.SellerId(userName);

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

        public List<State> GetStates()
        {

            try
            {
                e = new SellerOperations();
                return e.GetState();

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
