using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinAssignment.Model;
using System.Threading.Tasks;
using XamarinAssignment.Infrastructure.CrossCuttings;

namespace XamarinAssignment.Droid
{
    /// <summary>
    /// SQL lite helper methods for the crud opertation of Sqllite db
    /// </summary>
    public class SQLLiteHelper
    {
        #region Methods
        /// <summary>
        /// InsertProperty
        /// </summary>
        /// <param name="propertyList"></param>
        public static void InsertProperty(List<Property> propertyList)
        {
            using (var propertyRepository = new PropertyRepository(new SQLiteInfoMonodroid()))
            {
                if (propertyRepository.GetPropertyCount() < propertyList.Count)
                {
                    foreach (var property in propertyList)
                    {
                        propertyRepository.InsertProperty(property);
                    }
                }
            }
        }

        /// <summary>
        /// InsertPropertyDetails
        /// </summary>
        /// <param name="propertyDetail"></param>
        public static void InsertPropertyDetails(PropertyDetail propertyDetail)
        {
            using (var propertyRepository = new PropertyRepository(new SQLiteInfoMonodroid()))
            {
                var detail = propertyRepository.GetPropertyDetailById(propertyDetail.ListingID);
                if(detail.Result == null )
                    propertyRepository.InsertPropertyDetail(propertyDetail);
            }
        }
        #endregion
    }
}