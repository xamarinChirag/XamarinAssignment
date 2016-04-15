using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;
using XamarinAssignment.iOS.Helper;
using XamarinAssignment.Model;
using XamarinAssignment.ServiceClient;

namespace XamarinAssignment.iOS
{
    public class PropertyTableSource : UITableViewSource
    {

        List<Property> propertyCollection;
        string cellIdentifier = "Propertycell"; // set in the Storyboard
        PropertyMangager propertyManager;
        public PropertyTableSource(List<Property> listings)
        {
            propertyCollection = listings;
            propertyManager = new PropertyMangager();
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return propertyCollection.Count;
        }
        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            // in a Storyboard, Dequeue will ALWAYS return a cell,
            var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath) as PropertyViewCell;
            var propertyitem = propertyCollection[indexPath.Row];
            cell.Address = propertyitem.Address;
            cell.Beds = string.Format("Beds: {0}, Baths: {1}", propertyitem.Beds, propertyitem.Baths);

            byte[] imageBytes = null;
            imageBytes = propertyManager.GetImageAsync(propertyitem.Image).Result;

            ImageHelper.SetImage(imageBytes, propertyitem.ListingID, cell.Image, 150);
            return cell;
        }
        public Property GetItem(int id)
        {
            return propertyCollection[id];
        }
    }
}