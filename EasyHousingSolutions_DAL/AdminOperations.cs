using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_DAL
{
    public class AdminOperations
    {
        EasyHousingSolutions_Entities e = null;
        public IQueryable<Property> viewPropByRegion(string state, string city)
        {
            IQueryable<Property> prp = null;
            e = new EasyHousingSolutions_Entities();
            try
            {
                prp = (from p in e.Properties
                       select p);
                if (state != string.Empty && city != string.Empty)
                {
                    prp = (from p in e.Properties
                           where p.StateId == (from sId in e.States where sId.StateName == state select sId.StateId).FirstOrDefault()
                           && p.CityId == (from sId in e.Cities where sId.CityName == city select sId.CityId).FirstOrDefault()
                           select p);
                }
                else if (state != string.Empty && city == string.Empty)
                {
                    prp = (from p in e.Properties
                           where p.StateId == (from sId in e.States where sId.StateName == state select sId.StateId).FirstOrDefault()
                           select p);
                }
            }
            catch (AdminException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return prp;
        }

        public IQueryable<Property> viewPropByOwner(int OwnerId, string type)
        {
            e = new EasyHousingSolutions_Entities();
            IQueryable<Property> prp = null;
            try
            {
                e = new EasyHousingSolutions_Entities();
                prp = (from p in e.Properties
                       where p.SellerId == OwnerId
                       && p.PropertyOption == type
                       select p);
            }
            catch (AdminException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;
        }

        public List<Property> VerifyProperty(int propId, bool? state)
        {
            List<Property> prp = null;
            try
            {
                e = new EasyHousingSolutions_Entities();

                prp = (from p in e.Properties
                       where p.PropertyId == propId
                       select p).ToList<Property>();
                prp[0].IsActive = state;

                e.SaveChanges();
            }
            catch (AdminException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;
        }
        public List<Seller> GetOwners()
        {
            List<Seller> prp = null;
            try
            {
                e = new EasyHousingSolutions_Entities();

                prp = (from p in e.Sellers
                       select p).ToList();

            }
            catch (AdminException)
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
