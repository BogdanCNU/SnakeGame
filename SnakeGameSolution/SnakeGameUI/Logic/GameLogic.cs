using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeGameUI.Logic
{
    public delegate void GameEnded();

    public class GameLogic : DependencyObject
    {
        public List<List<Point>> snakepoints { get; set; }

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


        public event GameEnded GameEndedEvent;

        public GameLogic(string playerName)
        {
            this.PlayerName = playerName;
            this.Score = 0;
            snakepoints = new List<List<Point>>();
            List<Point> points = new List<Point>();
            points.Add(new Point(100, 100));
            points.Add(new Point(100, 200));

            this.snakepoints.Add(points);
            GenerateItem();
        }


        private void GenerateItem()
        {
            Random rnd = new Random();
            this.ItemTop = rnd.Next(20, (int)this.AreaHeight - 20);
            this.ItemLeft = rnd.Next(20, (int)this.AreaWidth - 20);
        }

        private int movementUnit = 10;

        public int ItemSize
        {
            get { return (int)GetValue(ItemSizeProperty); }
            set { SetValue(ItemSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSizeProperty =
            DependencyProperty.Register("ItemSize", typeof(int), typeof(GameLogic), new PropertyMetadata(12));

        private bool EatFood(List<Point> headpoints, Point headPoint, Point newPoint)
        {
            if (headPoint.X >= this.ItemLeft
                && headPoint.X <= this.ItemLeft + ItemSize
                && headPoint.Y >= this.ItemTop
                && headPoint.Y <= this.ItemTop + ItemSize)
            {
                GenerateItem();
                this.Score += 10;
                return true;
            }
            return false;
        }

        private bool IsGameOver()
        {
            IntersctionChecker check = new IntersctionChecker();

            List<Point> headpoints = snakepoints.First();
            Point headpoint = headpoints[0];
            Point nextAfterHeadpoint = headpoints[1];

            for (int i = 2; i < headpoints.Count - 1; i++)
            {
                if (check.doLinesIntersect(headpoint, nextAfterHeadpoint, headpoints[i], headpoints[i + 1]))
                {
                    return true;
                }
            }

            for (int i = 1; i < snakepoints.Count; i++)
            {
                List<Point> points = snakepoints[i];
                for (int j = 0; j < points.Count - 1; j++)
                {
                    if (check.doLinesIntersect(headpoint, nextAfterHeadpoint, points[j], points[j + 1]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal void MoveSnakeVertical(int movement, double yCoordAtEntry, double yCoordAtExit)
        {
            List<Point> headpoints = snakepoints.First();
            List<Point> tailpoints = snakepoints.Last();
            Point headPoint = headpoints.First();

            // add new point
            Point newPoint = new Point(headPoint.X, headPoint.Y + movement);



            if (newPoint.Y > 0 && newPoint.Y < AreaHeight)
            {
                headpoints.Insert(0, newPoint);
            }
            else
            {
                // modificare ultim punct pana in capat
                Point pointToScreenMargin = new Point(headPoint.X, yCoordAtExit);
                headpoints.Insert(0, pointToScreenMargin);

                // punct nou generat in celalat capat al ecranului
                newPoint.Y = yCoordAtEntry;

                // linie generata in celalat capat al ecranului
                Point additionalpoint = new Point(newPoint.X, newPoint.Y + movement);
                List<Point> newpoints = new List<Point>();
                newpoints.Add(additionalpoint);
                newpoints.Add(newPoint);
                snakepoints.Insert(0, newpoints);
                tailpoints.RemoveAt(tailpoints.Count - 1);
            }

            if (EatFood(headpoints, headPoint, newPoint) == false)
            {
                if (tailpoints.Count == 2)
                {
                    snakepoints.Remove(tailpoints);
                }
                else
                {
                    tailpoints.RemoveAt(tailpoints.Count - 1);
                }
            }

            if (IsGameOver())
            {
                // daca nu e nimeni abonat la eveniment, eventul e null
                if (GameEndedEvent != null)
                {
                    this.GameEndedEvent();
                }
            }

        }

        internal void MoveSnakeUp()
        {
            MoveSnakeVertical(-movementUnit, AreaHeight, 0);
        }

        internal void MoveSnakeDown()
        {
            MoveSnakeVertical(movementUnit, 0, AreaHeight);
        }

        internal void MoveSnakeRight()
        {
            List<Point> headpoints = snakepoints.First();
            List<Point> tailpoints = snakepoints.Last();
            Point headPoint = headpoints.First();

            // add new point
            Point newPoint = new Point(headPoint.X + movementUnit, headPoint.Y);

            if (newPoint.X > 0 && newPoint.X < AreaWidth)
            {
                headpoints.Insert(0, newPoint);
            }
            else
            {
                // modificare ultim punct pana in capat
                Point pointToScreenMargin = new Point(this.AreaWidth, headPoint.Y);
                headpoints.Insert(0, pointToScreenMargin);

                // punct nou generat in celalat capat al ecranului
                newPoint.X = 0;

                // linie generata in celalat capat al ecranului
                Point additionalpoint = new Point(newPoint.X + movementUnit, newPoint.Y);
                List<Point> newpoints = new List<Point>();
                newpoints.Add(additionalpoint);
                newpoints.Add(newPoint);
                snakepoints.Insert(0, newpoints);
                tailpoints.RemoveAt(tailpoints.Count - 1);
            }

            if (EatFood(headpoints, headPoint, newPoint) == false)
            {
                if (tailpoints.Count == 2)
                {
                    snakepoints.Remove(tailpoints);
                }
                else
                {
                    tailpoints.RemoveAt(tailpoints.Count - 1);
                }
            }

            if (IsGameOver())
            {
                // daca nu e nimeni abonat la eveniment, eventul e null
                if (GameEndedEvent != null)
                {
                    this.GameEndedEvent();
                }
            }
        }

        internal void MoveSnakeLeft()
        {
            List<Point> headpoints = snakepoints.First();
            List<Point> tailpoints = snakepoints.Last();
            Point headPoint = headpoints.First();

            // add new point
            Point newPoint = new Point(headPoint.X - movementUnit, headPoint.Y);

            if (newPoint.X > 0 && newPoint.X < AreaWidth)
            {
                headpoints.Insert(0, newPoint);
            }
            else
            {
                // modificare ultim punct pana in capat
                Point pointToScreenMargin = new Point(0, headPoint.Y);
                headpoints.Insert(0, pointToScreenMargin);

                // punct nou generat in celalat capat al ecranului
                newPoint.X = AreaWidth;

                // linie generata in celalat capat al ecranului
                Point additionalpoint = new Point(newPoint.X - movementUnit, newPoint.Y);
                List<Point> newpoints = new List<Point>();
                newpoints.Add(additionalpoint);
                newpoints.Add(newPoint);
                snakepoints.Insert(0, newpoints);
                tailpoints.RemoveAt(tailpoints.Count - 1);
            }

            if (EatFood(headpoints, headPoint, newPoint) == false)
            {
                if (tailpoints.Count == 2)
                {
                    snakepoints.Remove(tailpoints);
                }
                else
                {
                    tailpoints.RemoveAt(tailpoints.Count - 1);
                }
            }

            if (IsGameOver())
            {
                // daca nu e nimeni abonat la eveniment, eventul e null
                if (GameEndedEvent != null)
                {
                    this.GameEndedEvent();
                }
            }
        }

    }
}
