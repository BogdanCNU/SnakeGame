using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeGameUI.UserControls
{
    /// <summary>
    /// Interaction logic for StartMenuUserControl.xaml
    /// </summary>
    public partial class StartMenuUserControl : UserControl
    {
        public StartMenuUserControl()
        {
            InitializeComponent();
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            InsertPlayerNameWindow window = new InsertPlayerNameWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Owner = App.Current.MainWindow;
            window.ShowDialog();

            string pname = window.PlayerName;
            (App.Current.MainWindow as MainWindow).StartNewGame(pname);
        }

        private void HighscoreButton_Click(object sender, RoutedEventArgs e)
        {
            ViewHighscoreWindow window = new ViewHighscoreWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Owner = App.Current.MainWindow;
            window.ShowDialog();
        }
    }
}
