using System;
using System.IO;

using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using XamarinAssignment.Infrastructure.CrossCuttings;

namespace XamarinAssignment.Droid
{
	public class SQLiteInfoMonodroid : IPropertyDataPlatform
    {
		public SQLiteInfoMonodroid()
		{
		}

		public string DBFile {
			get {
				return Path.Combine (System.Environment.GetFolderPath (System.Environment.SpecialFolder.MyDocuments), "Property2.db3");
			}
		}

		public ISQLitePlatform SQLitePlatform {
			get {
                return new SQLitePlatformAndroid();
			}
		}
	}
}

