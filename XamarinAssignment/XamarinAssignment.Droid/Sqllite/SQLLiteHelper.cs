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
    public class SQLLiteHelper
    {

        /// <summary>
        /// InsertProperty
        /// </summary>
        /// <param name="listProperty"></param>
        public static void InsertProperty(List<Property> listProperty)
        {
            using (var repo = new PropertyRepository(new SQLiteInfoMonodroid()))
            {
                if (repo.GetPropertyCount() < listProperty.Count)
                {
                    foreach (var property in listProperty)
                    {
                        repo.InsertProperty(property);
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
            using (var repo = new PropertyRepository(new SQLiteInfoMonodroid()))
            {
                var detail = repo.GetPropertyDetailById(propertyDetail.ListingID);
                if(detail.Result == null )
                    repo.InsertPropertyDetail(propertyDetail);
            }
        }

    }
}