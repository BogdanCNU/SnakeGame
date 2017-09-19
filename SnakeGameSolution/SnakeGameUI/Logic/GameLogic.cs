using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeGameUI.Logic
{
    class GameLogic : DependencyObject
    {
        
        List<Point> points;

        public string PlayerName
        {
           get { return (string)GetValue(PlayerNameProperty); }
            set { SetValue(PlayerNameProperty, value); }
        }

         // Using a DependencyProperty as the backing store for PlayerName.  This enables animation, styling, binding, etc...
         public static readonly DependencyProperty PlayerNameProperty =
           DependencyProperty.Register("PlayerName", typeof(string), typeof(GameLogic));

        public int Score
        {
            get { return (int)GetValue(ScoreProperty); }
            set { SetValue(ScoreProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Score.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScoreProperty =
            DependencyProperty.Register("Score", typeof(int), typeof(GameLogic), new PropertyMetadata(0));



        public double AreaWidth
        {
            get { return (double)GetValue(AreaWidthProperty); }
            set { SetValue(AreaWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AreaWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AreaWidthProperty =
            DependencyProperty.Register("AreaWidth", typeof(double), typeof(GameLogic), new PropertyMetadata(400.0));



        public double AreaHeight
        {
            get { return (double)GetValue(AreaHeightProperty); }
            set { SetValue(AreaHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AreaHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AreaHeightProperty =
            DependencyProperty.Register("AreaHeight", typeof(double), typeof(GameLogic), new PropertyMetadata(400.0));




        public int ItemTop
        {
            get { return (int)GetValue(ItemTopProperty); }
            set { SetValue(ItemTopProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemTop.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemTopProperty =
            DependencyProperty.Register("ItemTop", typeof(int), typeof(GameLogic), new PropertyMetadata(0));



        public int ItemLeft
        {
            get { return (int)GetValue(ItemLeftProperty); }
            set { SetValue(ItemLeftProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemLeft.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemLeftProperty =
            DependencyProperty.Register("ItemLeft", typeof(int), typeof(GameLogic), new PropertyMetadata(0));





        public GameLogic( string playerName)
        {
            this.PlayerName = playerName;
            this.Score = 0;
            this.points = new List<Point>();
            GenerateItem();
        }


        private void GenerateItem()
        {
            Random rnd = new Random();
            this.ItemTop = rnd.Next(10, (int)this.AreaHeight - 10);
            this.ItemLeft = rnd.Next(10, (int)this.AreaWidth - 10);
        }

    }
}
