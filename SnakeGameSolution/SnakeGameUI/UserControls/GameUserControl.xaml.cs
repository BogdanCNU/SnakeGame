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

            this.IsVisibleChanged += GameUserControl_IsVisibleChanged;
            

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(150);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void GameUserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible)
            {
                this.Focusable = true;
                Keyboard.Focus(this);
            }
        }

        private Key lastKey;

        private void Timer_Tick(object sender, EventArgs e)
        {
            MoveSnake();
            DrawSnake();
            
        }

        private void DrawSnake()
        {
            canvasSnake.Children.Clear();
            foreach(List<Point> points in game.snakepoints)
            {
                Polyline snakeLine = new Polyline();
                snakeLine.Stroke = Brushes.Red;
                snakeLine.StrokeThickness = 8;
                foreach (Point p in points)
                {
                    snakeLine.Points.Add(p);
                }
                canvasSnake.Children.Add(snakeLine);
            }
        }

        private void UserControl_KeyUp(object sender, KeyEventArgs e)
        {
            lastKey = e.Key;
        }

        private void MoveSnake()
        {
            switch (lastKey)
            {
                case Key.Up:
                    game.MoveSnakeUp();
                    break;
                case Key.Down:
                    game.MoveSnakeDown();
                    break;
                case Key.Right:
                    game.MoveSnakeRight();
                    break;
                case Key.Left:
                    game.MoveSnakeLeft();
                    break;
            }
        }
    }
}
