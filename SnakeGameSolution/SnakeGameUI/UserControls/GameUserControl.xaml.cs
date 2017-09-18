using SnakeGameUI.Logic;
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
using System.Windows.Threading;

namespace SnakeGameUI.UserControls
{
    /// <summary>
    /// Interaction logic for GameUserControl.xaml
    /// </summary>
    /// 

    public partial class GameUserControl : UserControl
    {
        private DispatcherTimer timer;
        int x;

        GameLogic game;

        public GameUserControl(string playerName)
        {
            InitializeComponent();

            game = new GameLogic(playerName);
            this.DataContext = game;

           

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(2000);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            textBoxScore.Text += (x++);
        }
    }
}
