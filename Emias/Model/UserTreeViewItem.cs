using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Emias.Model
{
    public class UserTreeViewItem
    {
        public string Header { get; set; }
        public ObservableCollection<UserTreeViewItem> Items { get; set; } = new ObservableCollection<UserTreeViewItem>();

        public UserTreeViewItem(string header)
        {
            Header = header;
        }
    }
}
