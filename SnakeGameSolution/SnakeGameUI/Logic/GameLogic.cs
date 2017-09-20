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
            DependencyProperty.Register("AreaWidth", typeof(double), typeof(GameLogic), new PropertyMetadata(500.0));



        public double AreaHeight
        {
            get { return (double)GetValue(AreaHeightProperty); }
            set { SetValue(AreaHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AreaHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AreaHeightProperty =
            DependencyProperty.Register("AreaHeight", typeof(double), typeof(GameLogic), new PropertyMetadata(500.0));




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
            this.points.Add(new Point(100, 100));
            this.points.Add(new Point(110, 100));
            this.points.Add(new Point(120, 100));
            this.points.Add(new Point(130, 100));
            this.points.Add(new Point(140, 100));
            GenerateItem();
        }


        private void GenerateItem()
        {
            Random rnd = new Random();
            this.ItemTop = rnd.Next(20, (int)this.AreaHeight - 20);
            this.ItemLeft = rnd.Next(20, (int)this.AreaWidth - 20);
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

            if(headPoint.Y > 500)
            {
                headPoint.X = headPoint.X;
                headPoint.Y = 0;
            }


            if (headPoint.X >= this.ItemLeft -8 && headPoint.X <= this.ItemLeft + 8
                && headPoint.Y >= this.ItemTop - 8 && headPoint.Y <= this.ItemTop + 8)
            {
                GenerateItem();
                points.Insert(0, newPoint);
                this.Score += 10;
                
            }

        }

        internal void MoveSnakeDown()
        {
            Point headPoint = points.First();
            // add new point
            Point newPoint = new Point(headPoint.X, headPoint.Y + movementUnit);
            points.Insert(0, newPoint);
            // remove tail
            points.RemoveAt(points.Count - 1);

            if (headPoint.Y > 500)
            {
                headPoint.X = headPoint.X;
                headPoint.Y = 0;
            }

            if (headPoint.X >= this.ItemLeft - 8 && headPoint.X <= this.ItemLeft + 8
                && headPoint.Y >= this.ItemTop - 8 && headPoint.Y <= this.ItemTop + 8)
            {
                GenerateItem();
                points.Insert(0, newPoint);
                this.Score += 10;
            }
        }

        internal void MoveSnakeRight()
        {
            Point headPoint = points.First();
            // add new point
            Point newPoint = new Point(headPoint.X + movementUnit, headPoint.Y);
            points.Insert(0, newPoint);
            // remove tail
            points.RemoveAt(points.Count - 1);

            if (headPoint.Y > 500)
            {
                headPoint.X = headPoint.X;
                headPoint.Y = 0;
            }

            if (headPoint.X >= this.ItemLeft - 8 && headPoint.X <= this.ItemLeft + 8
                && headPoint.Y >= this.ItemTop - 8 && headPoint.Y <= this.ItemTop + 8)
            {
                GenerateItem();
                points.Insert(0, newPoint);
                this.Score += 10;
            }
        }

        internal void MoveSnakeLeft()
        {
            Point headPoint = points.First();
            // add new point
            Point newPoint = new Point(headPoint.X - movementUnit, headPoint.Y);
            points.Insert(0, newPoint);
            // remove tail
            points.RemoveAt(points.Count - 1);

            if (headPoint.Y > 500)
            {
                headPoint.X = headPoint.X;
                headPoint.Y = 0;
            }

            if (headPoint.X >= this.ItemLeft - 8 && headPoint.X <= this.ItemLeft + 8
                && headPoint.Y >= this.ItemTop - 8 && headPoint.Y <= this.ItemTop + 8)
            {
                GenerateItem();
                points.Insert(0, newPoint);
                this.Score += 10;
            }
        }

    }
}
