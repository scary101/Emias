using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emias.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo(string pageKey);
        void GoBack();
    }

}
