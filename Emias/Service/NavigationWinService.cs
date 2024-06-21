using Emias.Interfaces;
using Emias.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Emias.Service
{
    internal class NavigationWinService : INavigationWinService
    {
        public void CloseCurrentWindow()
        {
            var currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Close();
            }
        }

        public void OpenAuthorizationView()
        {
            AuthorizationView view = new AuthorizationView();
            view.Show();
        }
    }
}
