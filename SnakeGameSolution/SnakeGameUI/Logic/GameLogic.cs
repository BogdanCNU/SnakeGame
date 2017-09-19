using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeGameUI.Logic
{
    public class GameLogic : DependencyObject
    {

        public List<Point> points { get; set; }

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





        public GameLogic(string playerName)
        {
            this.PlayerName = playerName;
            this.Score = 0;
            this.points = new List<Point>();
            this.points.Add(new Point(50, 200));
            this.points.Add(new Point(58, 200));
            this.points.Add(new Point(58, 100));
            this.points.Add(new Point(150, 100));
            this.points.Add(new Point(150, 200));
            GenerateItem();
        }


        private void GenerateItem()
        {
            Random rnd = new Random();
            this.ItemTop = rnd.Next(10, (int)this.AreaHeight - 10);
            this.ItemLeft = rnd.Next(10, (int)this.AreaWidth - 10);
        }

        private int movementUnit = 10;

        internal void MoveSnakeUp()
        {
            Point headPoint = points.First();
            // add new point
            Point newPoint = new Point(headPoint.X, headPoint.Y - movementUnit);
            points.Insert(0, newPoint);

            //remove tail
            points.RemoveAt(points.Count - 1);
        }

        internal void MoveSnakeDown()
        {
            Point headPoint = points.Last();
            // add new point
            Point newPoint = new Point(headPoint.X, headPoint.Y + movementUnit);
            points.Insert(points.Count, newPoint);
            // remove tail
            points.RemoveAt(0);
        }

        internal void MoveSnakeRight()
        {
            Point headPoint = points.First();
            // add new point
            Point newPoint = new Point(headPoint.X + movementUnit, headPoint.Y);
            points.Insert(0, newPoint);
            // remove tail
            points.RemoveAt(points.Count - 1);
        }

        internal void MoveSnakeLeft()
        {
            Point headPoint = points.First();
            // add new point
            Point newPoint = new Point(headPoint.X - movementUnit, headPoint.Y);
            points.Insert(0, newPoint);
            // remove tail
            points.RemoveAt(points.Count - 1);
        }

    }
}
