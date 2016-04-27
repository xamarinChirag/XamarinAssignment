# XamarinAssignment -Xamarin android and ios assignment

### List Requirements:
-	Show a list of all listings, including their:
-	Picture
-	Address
-	Beds & Baths
-	A disclosure icon indicating tapping the row will load the details.
-	The API is available via a GET request to https://sample-listings.herokuapp.com/listings which returns JSON.

### Detail Requirements:
-	Show the listing details, including their:
-	Picture
-	Address
-	Beds & Baths, Estimated Value, and Rate of Change
-	Features
-The Rate of Change should be red if negative, and green if positive.
-The features should be selectable.
-The full listing JSON payload is available via a GET request to https://sample-listings.herokuapp.com/listings/{listingID} - the data returned in the request to get all will not be sufficient for retrieving all the fields you need.
-----------------------------------------------------------------------------------------------------------------------------------------------
## Implementation details 

1. Use the Xamarin Cross platform project for creating the xamarin.android and xamarin.ios  native app support.
2. Utilized the PCL(portable class libarary) project for sharing the domain and business service logic.
3.	Written Unit test project for verifying business service logic.
4.	Display the listing page.
5.	Clicking on the item will navigate to details page.
6. Utilized the modernhttpclient nuget package for handling the native message handler related to android and ios.
7. Utilized the MvvmCross nuget package for IOC container.
8. Utilized the SQLite.Net-PCL(Android only) nuget package for storing the data into sqllight db for offline support of app.
Note: offline support for ios also can be achieve the same way.
9.Utilized Xam.Plugin.Connectivity plugins for checking the network connectivity.
10. Download the image asynchronously and saved in the local storage specific to andorid and ios for reused purpose.
11. Android : use the listview control and custom layout and custom adapter for listview render.
12. iOS: use the custom tableview and tableviewcell.
