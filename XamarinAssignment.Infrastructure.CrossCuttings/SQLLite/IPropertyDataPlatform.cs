using System;
using SQLite.Net.Interop;

namespace XamarinAssignment.Infrastructure.CrossCuttings
{
	public interface IPropertyDataPlatform
    {
		string DBFile { get; }
		ISQLitePlatform SQLitePlatform { get; }
	}
}

