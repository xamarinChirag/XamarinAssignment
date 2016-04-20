using System;
using System.IO;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using XamarinAssignment.Infrastructure.CrossCuttings;

namespace XamarinAssignment.Droid
{
    /// <summary>
    /// SQLLite platform implementation for Android
    /// </summary>
	public class SQLiteInfoMonodroid : IPropertyDataPlatform
    {
        #region Constructor
        public SQLiteInfoMonodroid()
		{
		}
        #endregion

        #region Properties
        public string DBFile {
			get {
				return Path.Combine (System.Environment.GetFolderPath (System.Environment.SpecialFolder.MyDocuments), "Property3.db3");
			}
		}

		public ISQLitePlatform SQLitePlatform {
			get {
                return new SQLitePlatformAndroid();
			}
		}

        #endregion
    }
}

