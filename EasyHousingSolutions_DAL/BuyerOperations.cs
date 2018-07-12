using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_DAL
{
    public class BuyerOperations
    {


        #region  this will Search the properties.. and s
        // this will Search the properties.. and s
        public void FilteredData(Property dfs)
        {
            EasyHousingSolutions_Entities entity = new EasyHousingSolutions_Entities();
            var filteredData = from a in entity.Properties
                               where a.Address.ToString() == dfs.Address && a.PropertyType == dfs.PropertyType
                               orderby a.PriceRange ascending
                               select a;
            foreach (var k in filteredData)
            {
                Console.WriteLine(k.PropertyName + "" + k.PropertyOption + " " + k.SellerId + " " + k.PriceRange);
            }
        }
        #endregion



        #region// this will sort the properties..
        public void SortByPrice()
        {
            EasyHousingSolutions_Entities entity = new EasyHousingSolutions_Entities();
            var SortedData = from a in entity.Properties
                             orderby a.PriceRange ascending
                             select a;

        }
        #endregion


        #region  add to cart
        static int Loginid;
        public void GetBuyerId(int buyrId)
        {
            Loginid = buyrId;
        }
        public List<Property> AddToCart(int propID)
        {
            EasyHousingSolutions_Entities entity = new EasyHousingSolutions_Entities();
            List<Property> propertyList = new List<Property>();

            // this is current buyer id... this has to be fetched from db



            // fectching the property data..
            var propdata = from k in entity.Properties
                           where k.PropertyId == propID
                           select k;
            foreach (var k in propdata)
            {
                propertyList.Add(k);
            }

            Cart cart = new Cart();
            cart.PropertyId = propID;
            cart.BuyerId = Loginid;

            entity.Carts.Add(cart);

            entity.SaveChanges();

            return propertyList;
        }


        #endregion


        #region delete from cart

        public List<Property> DeleteFromCart(int id)
        {
            EasyHousingSolutions_Entities entity = new EasyHousingSolutions_Entities();
            List<Property> propertyList = new List<Property>();
            // delete from cart..
            var DeleteCart = (from p in entity.Carts
                              where p.PropertyId == id && p.BuyerId == Loginid
                              select p);

            foreach (var k in DeleteCart)
            {

                entity.Carts.Remove(k);

            }

            // fectching the property data which is deleted...
            var propdata = from k in entity.Properties
                           where k.PropertyId == id
                           select k;
            foreach (var k in propdata)
            {
                propertyList.Add(k);
            }

            entity.SaveChanges();
            return propertyList;

        }
        #endregion


        #region show cart

        public List<Property> ShowCart()
        {
            EasyHousingSolutions_Entities entity = new EasyHousingSolutions_Entities();
            List<Property> propertyList = new List<Property>();

            // fetching cart data...
            var shoWCart = from p in entity.Properties
                           from c in entity.Carts

                           where p.PropertyId == c.PropertyId
                           && c.BuyerId == Loginid
                           select p;

            foreach (var k in shoWCart)
            {
                propertyList.Add(k);
            }

            return propertyList;
        }



        #endregion

        #region   fetching all the property data from DB 

        public List<Property> ShowALLProperties()
        {
            EasyHousingSolutions_Entities entity = new EasyHousingSolutions_Entities();
            List<Property> propertyList = new List<Property>();

            var HouseDetails = from p in entity.Properties
                               select p;
            foreach (var k in HouseDetails)
            {
                propertyList.Add(k);
            }
            return propertyList;


        }

        #endregion

        #region adding buyer details to databse..
        public void InsertBuyer(Buyer newBuyer)
        {
            EasyHousingSolutions_Entities ehsEntity = new EasyHousingSolutions_Entities();

            ehsEntity.Buyers.Add(newBuyer);

            ehsEntity.SaveChanges();
        }
        #endregion

        public int BuyerId(string userName)
        {

            int prp;
            try
            {
                EasyHousingSolutions_Entities ehsEntity = new EasyHousingSolutions_Entities();


                prp = (from p in ehsEntity.Buyers
                       where p.UserName == userName
                       select p.BuyerId).FirstOrDefault();
            }
            catch (BuyerException)
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
