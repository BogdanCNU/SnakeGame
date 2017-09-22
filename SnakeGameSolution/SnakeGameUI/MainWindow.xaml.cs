using SnakeGameUI.UserControls;
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

namespace SnakeGameUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ShowStartMenu()
        {
            StartMenuUserControl uc = new StartMenuUserControl();
            this.Content = uc;

        }

        public void StartNewGame(string playerName)
        {
            GameUserControl uc = new GameUserControl(playerName);
            this.Content = uc;

        }

        public void ShowHighscore()
        {
            HighscoreUserControl huc = new HighscoreUserControl();
            this.Content = huc;
        }

    }
}
