using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_DAL
{
    public class SellerOperations
    {
        EasyHousingSolutions_Entities ehsEntity = null;
        public void AddSeller(Seller newSeller)
        {
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                ehsEntity.Sellers.Add(newSeller);

                ehsEntity.SaveChanges();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddProperty(Property newProperty)
        {
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                ehsEntity.Properties.Add(newProperty);

                ehsEntity.SaveChanges();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void UpdateProperty(Property updateProperty)
        {
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                List<Property> prp = (from p in ehsEntity.Properties
                                      where p.PropertyId == updateProperty.PropertyId
                                      select p).ToList();

                prp[0].PropertyName = updateProperty.PropertyName;
                prp[0].Address = updateProperty.Address;
                prp[0].Description = updateProperty.Description;
                prp[0].Status_Description = updateProperty.Status_Description;
                prp[0].Images = updateProperty.Images;
                prp[0].InitialDeposit = updateProperty.InitialDeposit;
                prp[0].Landmark = updateProperty.Landmark;
                prp[0].PriceRange = updateProperty.PriceRange;
                prp[0].PropertyOption = updateProperty.PropertyOption;
                prp[0].PropertyType = updateProperty.PropertyType;
                ehsEntity.SaveChanges();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Property> viewProperties(int sellerID, bool? status)
        {
            List<Property> prp = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                prp = (from p in ehsEntity.Properties
                       where p.SellerId == sellerID && p.IsActive == status
                       select p).ToList();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;
        }

        public List<Property> viewProperties(int sellerID)
        {
            List<Property> prp = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                prp = (from p in ehsEntity.Properties
                       where p.SellerId == sellerID
                       select p).ToList();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;

        }

        public Property GetProp(int propId)
        {
            Property prp = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                prp = (from p in ehsEntity.Properties
                       where p.PropertyId == propId
                       select p).FirstOrDefault();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;

        }

        public List<City> GetCity(int stateId)
        {
            List<City> prp = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                prp = (from p in ehsEntity.Cities
                       where p.StateId == stateId
                       select p).ToList();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;

        }
        public List<City> Get_City(int cityId)
        {
            List<City> prp = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                prp = (from p in ehsEntity.Cities
                       where p.CityId == cityId
                       select p).ToList();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;

        }

        public List<State> Get_State(int stateId)
        {
            List<State> prp = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                prp = (from p in ehsEntity.States
                       where p.StateId == stateId
                       select p).ToList();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;

        }

        public List<State> GetState()
        {
            List<State> prp = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                prp = (from p in ehsEntity.States

                       select p).ToList();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;

        }

        public int SellerId(string userName)
        {

            int prp;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                prp = (from p in ehsEntity.Sellers
                       where p.UserName == userName
                       select p.SellerId).FirstOrDefault();
            }
            catch (SellerException)
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
