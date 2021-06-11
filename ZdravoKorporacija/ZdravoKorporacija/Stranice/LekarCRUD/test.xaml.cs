using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ZdravoKorporacija.Stranice.LekoviCRUD;
using ZdravoKorporacija.Stranice.Logovanje;
using ZdravoKorporacija.Stranice.Uput;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>

    public partial class test : Window
    {

        public static Frame prozor = new Frame();
        private string CurrentLanguage { get; set; }
        public test()
        {
            CurrentLanguage = "en-US";
            InitializeComponent();
            Main.Content = new lekarStart(lekarLogin.lekar);
            prozor = Main;
            Trace.WriteLine(CurrentLanguage);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new lekarStart(lekarLogin.lekar);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new pregledPacijenata();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new Uputi();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Main.Content = new LekarZahteviZaDodavanjeLekaStart();
        }

        private void promeniTemu(object sender, RoutedEventArgs e)
        {
            App app = (App)Application.Current;
            if (tema.Header.ToString() == "_Tamna Tema" || tema.Header.ToString() == "_Dark Theme")
            {
                app.ChangeTheme(new Uri("Themes/Dark.xaml", UriKind.Relative));
                if (CurrentLanguage.Equals("en-US"))
                {
                    tema.Header = "_Light Theme";
                }
                else
                {
                    tema.Header = "_Svetla Tema";
                }
            }
            else
            {
                app.ChangeTheme(new Uri("Themes/Light.xaml", UriKind.Relative));
                if (CurrentLanguage.Equals("en-US"))
                {
                    tema.Header = "_Dark Theme";
                }
                else
                {
                    tema.Header = "_Tamna Tema";
                }
            }
        }

        private void promeniJezik(object sender, RoutedEventArgs e)
        {
            App app = (App)Application.Current;
            if (CurrentLanguage.Equals("en-US"))
            {
                CurrentLanguage = "sr-LATN";
            }
            else
            {
                CurrentLanguage = "en-US";
            }
            app.ChangeLanguage(CurrentLanguage);
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow.mw.Show();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Main.Content = new LekarFeedback();
        }
    }
}
