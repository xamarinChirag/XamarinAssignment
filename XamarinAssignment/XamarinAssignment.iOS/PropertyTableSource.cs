using System;
using System.Collections.Generic;
using UIKit;
using XamarinAssignment.Model;

namespace XamarinAssignment.iOS
{
    public class PropertyTableSource : UITableViewSource
    {

        List<Property> propertyCollection;
        string cellIdentifier = "propertycell"; // set in the Storyboard

        public PropertyTableSource(List<Property> listings)
        {
            propertyCollection = listings;
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return propertyCollection.Count;
        }
        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            // in a Storyboard, Dequeue will ALWAYS return a cell,
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            //tableView.tex
            //cell.Text = propertyCollection[indexPath.Row].Address;
            //cell
            return cell;
        }
        public Property GetItem(int id)
        {
            return propertyCollection[id];
        }
    }
}