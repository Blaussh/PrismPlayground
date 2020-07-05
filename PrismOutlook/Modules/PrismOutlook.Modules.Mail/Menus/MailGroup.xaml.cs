using Infragistics.Controls.Menus;
using Infragistics.Windows.OutlookBar;
using PrismOutlook.Buisness;
using PrismOutlook.Core;
using PrismOutlook.Modules.Mail.ViewModels;
using System.Linq;
using static PrismOutlook.Modules.Mail.ViewModels.MailGroupViewModel;

namespace PrismOutlook.Modules.Mail.Menus
{
    /// <summary>
    /// Interaction logic for MailGroup.xaml
    /// </summary>
    public partial class MailGroup : OutlookBarGroup, IOutlookBarGroup
    {
        NavigationItem _selectedItem;

        public MailGroup()
        {
            InitializeComponent();
        }

        public string DefaultNavigationPath 
        {
            get
            {
                var item = _dataTree.SelectionSettings.SelectedNodes[0] as XamDataTreeNode;
                if (item != null)
                    return ((NavigationItem)item.Data).NavigationPath;

                return $"MailList?{FolderParameters.FolderKey}={FolderParameters.Inbox}";
            }   
        
        }
    }
}
