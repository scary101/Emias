using API6.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Emias
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string theme;
        public static string Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                var dict = new ResourceDictionary { Source = new Uri($"/Resources/{value}.xaml", UriKind.Relative) };
                Current.Resources.MergedDictionaries.RemoveAt(0);
                Current.Resources.MergedDictionaries.Insert(0, dict);
            }
        }

        private static string imageTheme;
        public static string ImageTheme
        {
            get { return imageTheme; }
            set
            {
                imageTheme = value;
                var dict = new ResourceDictionary { Source = new Uri($"/Resources/{value}Images.xaml", UriKind.Relative) };
                Current.Resources.MergedDictionaries.RemoveAt(1);
                Current.Resources.MergedDictionaries.Insert(1, dict);
            }
        }

        public static Patient Patient;

        public App()
        {
            InitializeComponent();
        }
    }

}
