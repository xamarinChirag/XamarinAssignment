using System;
using System.Collections.Generic;
using System.Linq;

using SQLite.Net;
using SQLite.Net.Interop;
using XamarinAssignment.Model;
using System.Threading.Tasks;

namespace XamarinAssignment.Infrastructure.CrossCuttings
{
    /// <summary>
    /// Sql lite property repository for CRUD operation
    /// </summary>
	public class PropertyRepository : IDisposable
	{
        #region Fields
        private SQLiteConnection _db;
		private object lockGuard = new object();
        #endregion

        #region Constructor
        /// <summary>
        /// PropertyRepository constructor to initialize and create the db and table for sqllite db.
        /// </summary>
        /// <param name="dbInfo"></param>
        public PropertyRepository(IPropertyDataPlatform dbInfo)
		{
			if (_db == null) {
				_db = new SQLiteConnection (dbInfo.SQLitePlatform, dbInfo.DBFile, true);
                 _db.CreateTable<Property> ();
                 _db.CreateTable<PropertyDetail> ();
            }
        }
        #endregion

        #region Property Methods

        /// <summary>
        /// InsertProperty
        /// </summary>
        /// <param name="propertyToInsert"></param>
        public void InsertProperty(Property propertyToInsert)
        {
            lock (lockGuard)
            {
                _db.Insert(propertyToInsert);
            }
        }

        /// <summary>
        /// RetrieveAllProperties
        /// </summary>
        /// <returns></returns>
        public async Task<List<Property>> RetrieveAllProperties()
        {
            return await Task.FromResult(_db.Table<Property>().ToList());
        }

        /// <summary>
        /// GetPropertyCount
        /// </summary>
        /// <returns></returns>
        public int GetPropertyCount()
        {
            return _db.Table<Property>().Count();
        }

        /// <summary>
        /// GetPropertyByIds
        /// </summary>
        /// <param name="PropertyId"></param>
        /// <returns></returns>
        public Property GetPropertyById(int PropertyId)
        {
            return _db.Table<Property>().Where(t => t.ListingID == PropertyId).FirstOrDefault();
        }

        #endregion

        #region PropertyDetail methods
        /// <summary>
        /// InsertPropertyDetail
        /// </summary>
        /// <param name="propertyDetailToInsert"></param>
        public void InsertPropertyDetail(PropertyDetail propertyDetailToInsert)
		{
			lock (lockGuard) {
				_db.Insert (propertyDetailToInsert);
			}
		}
        /// <summary>
        /// RetrieveAllPropertyDetails
        /// </summary>
        /// <returns></returns>
		public async Task<List<PropertyDetail>> RetrieveAllPropertyDetails ()
		{
            return await Task.FromResult(_db.Table<PropertyDetail>().ToList()); 
		}

        /// <summary>
        /// GetPropertyDetailCount
        /// </summary>
        /// <returns></returns>
        public int GetPropertyDetailCount()
        {
            return _db.Table<PropertyDetail>().Count();
        }

        /// <summary>
        /// GetPropertyDetailById
        /// </summary>
        /// <param name="PropertyDetailId"></param>
        /// <returns></returns>
        public async Task<PropertyDetail> GetPropertyDetailById(int PropertyDetailId)
		{
			return await Task.FromResult(_db.Table<PropertyDetail> ().Where (t => t.ListingID == PropertyDetailId).FirstOrDefault ());
		}
        #endregion

        #region Dispose
        public void Dispose ()
		{
			if (_db != null)
				_db.Close ();
		}
        #endregion


    }
}

