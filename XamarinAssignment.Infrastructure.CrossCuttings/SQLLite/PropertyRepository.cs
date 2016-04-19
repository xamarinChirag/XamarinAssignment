using System;
using System.Collections.Generic;
using System.Linq;

using SQLite.Net;
using SQLite.Net.Interop;
using XamarinAssignment.Model;
using System.Threading.Tasks;

namespace XamarinAssignment.Infrastructure.CrossCuttings
{
	public class PropertyRepository : IDisposable
	{
        #region Field
        private SQLiteConnection _db;
		private object lockGuard = new object();
        #endregion

        #region Constructor
        public PropertyRepository(IPropertyDataPlatform dbInfo)
		{
			if (_db == null) {
				_db = new SQLiteConnection (dbInfo.SQLitePlatform, dbInfo.DBFile, true);
                 _db.CreateTable<Property> ();
                 _db.CreateTable<PropertyDetail> ();

            }
        }
        #endregion


        #region Property method
        public void InsertProperty(Property propertyToInsert)
        {
            lock (lockGuard)
            {
                _db.Insert(propertyToInsert);
            }
        }

        public async Task<List<Property>> RetrieveAllProperties()
        {
            return await Task.FromResult(_db.Table<Property>().ToList());
        }

        public int GetPropertyCount()
        {
            return _db.Table<Property>().Count();
        }

        public Property GetPropertyById(int PropertyId)
        {
            return _db.Table<Property>().Where(t => t.ListingID == PropertyId).FirstOrDefault();
        }

        #endregion

        #region PropertyDetail method
        public void InsertPropertyDetail(PropertyDetail propertyDetailToInsert)
		{
			lock (lockGuard) {
				_db.Insert (propertyDetailToInsert);
			}
		}

		public async Task<List<PropertyDetail>> RetrieveAllPropertyDetails ()
		{
            return await Task.FromResult(_db.Table<PropertyDetail>().ToList()); 
		}

        public int GetPropertyDetailCount()
        {
            return _db.Table<PropertyDetail>().Count();
        }

        public async Task<PropertyDetail> GetPropertyDetailById(int PropertyDetailId)
		{
			return await Task.FromResult(_db.Table<PropertyDetail> ().Where (t => t.ListingID == PropertyDetailId).FirstOrDefault ());
		}
        #endregion

        public void Dispose ()
		{
			if (_db != null)
				_db.Close ();
		}

	}
}

