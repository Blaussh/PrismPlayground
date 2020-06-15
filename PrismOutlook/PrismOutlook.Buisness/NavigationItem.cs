using System.Collections.ObjectModel;

namespace PrismOutlook.Buisness
{
    public class NavigationItem
    {
        public string Caption { get; set; }
        public string NavigationPath { get; set; }
        public ObservableCollection<NavigationItem> Items { get; set; }
    }
}
