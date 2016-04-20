using System;
using SQLite.Net.Interop;

namespace XamarinAssignment.Infrastructure.CrossCuttings
{
    /// <summary>
    /// IPropertyDataPlatform
    /// </summary>
	public interface IPropertyDataPlatform
    {
		string DBFile { get; }
		ISQLitePlatform SQLitePlatform { get; }
	}
}

