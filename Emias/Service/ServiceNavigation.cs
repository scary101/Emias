using Emias.Interfaces;
using Emias.Model;
using Emias.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Emias.Service
{

    public class ServiceNavigation : INavigationService
    {
        private readonly Frame _frame;

        public ServiceNavigation(Frame frame)
        {
            _frame = frame;
        }

        public void NavigateTo(string pageKey)
        {
            var pageType = GetPageType(pageKey);
            if (pageType != null)
            {
                var pageInstance = Activator.CreateInstance(pageType, this) as Page;
                _frame.Navigate(pageInstance);
            }
            else
            {
                throw new ArgumentException($"Page not found: {pageKey}", nameof(pageKey));
            }
        }

        public void GoBack()
        {
            if (_frame.CanGoBack)
            {
                _frame.GoBack();
            }
        }

        public void NavigateToPageWithStringData(INavigationService navigationService, SelectVrachCardType userData)
        {
            var pageType = typeof(DoctorChoiceUserPage);
            if (pageType != null)
            {
                var pageInstance = Activator.CreateInstance(pageType, navigationService, userData) as Page;
                _frame.Navigate(pageInstance);
            }
        }
        public void ReloadCurrentPage()
        {
            if (_frame.Content is Page currentPage)
            {
                var pageType = currentPage.GetType();
                var pageInstance = Activator.CreateInstance(pageType, this) as Page;
                _frame.Navigate(pageInstance);
            }
            else
            {
                throw new InvalidOperationException("No page is currently loaded.");
            }
        }

        private Type GetPageType(string pageKey)
        {
            switch (pageKey)
            {
                case "AdminLogin":
                    return typeof(AdminLoginPage);
                case "UserLogin":
                    return typeof(UserLoginPage);
                case "AnalysisUserPage":
                    return typeof(AnalysisUserPage);
                case "AppointmentUserPage":
                    return typeof(AppointmentUserPage);
                case "DoctorChoiceUserPage":
                    return typeof(DoctorChoiceUserPage);
                case "ProfileUserPage":
                    return typeof(ProfileUserPage);
                case "ResearchesUserPage":
                    return typeof(ResearchesUserPage);
                case "MainMenuUserPage":
                    return typeof(MainMenuUserPage);
                case "ChoiseDoctorPage":
                    return typeof(ChoiseDoctorPage);
                default:
                    return null;
            }
        }

    }

}
