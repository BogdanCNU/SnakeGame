using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeGameUI
{
    public class LineSegment
    {
        public Point first;
        public Point second;

        public LineSegment(Point point1, Point point2)
        {
            this.first = point1;
            this.second = point2;
        }

        internal Point[] getBoundingBox()
        {
            Point[] points = new Point[2];
            points[0] = new Point(Math.Min(first.X, second.X), Math.Min(first.Y, second.Y));
            points[1] = new Point(Math.Max(first.X, second.X), Math.Max(first.Y, second.Y));
            return points;
        }
    }

    public class IntersctionChecker
    {
        public double EPSILON = 0.000001;

        public static double crossProduct(Point a, Point b)
        {
            return a.X * b.Y - b.X * a.Y;
        }

        public bool doBoundingBoxesIntersect(Point[] a, Point[] b)
        {
            return a[0].X <= b[1].X
                && a[1].X >= b[0].X
                && a[0].Y <= b[1].Y
                && a[1].Y >= b[0].Y;
        }

        public bool isPointOnLine(LineSegment a, Point b)
        {
            // Move the image, so that a.first is on (0|0)
            LineSegment aTmp = new LineSegment(new Point(0, 0), new Point(
                    a.second.X - a.first.X, a.second.Y - a.first.Y));
            Point bTmp = new Point(b.X - a.first.X, b.Y - a.first.Y);
            double r = crossProduct(aTmp.second, bTmp);
            return Math.Abs(r) < EPSILON;
        }

        /**
 * Checks if a point is right of a line. If the point is on the
 * line, it is not right of the line.
 * @param a line segment interpreted as a line
 * @param b the point
 * @return <code>true</code> if the point is right of the line,
 *         <code>false</code> otherwise
 */
        public bool isPointRightOfLine(LineSegment a, Point b)
        {
            // Move the image, so that a.first is on (0|0)
            LineSegment aTmp = new LineSegment(new Point(0, 0), new Point(
                    a.second.X - a.first.X, a.second.Y - a.first.Y));
            Point bTmp = new Point(b.X - a.first.X, b.Y - a.first.Y);
            return crossProduct(aTmp.second, bTmp) < 0;
        }

        /**
 * Check if line segment first touches or crosses the line that is 
 * defined by line segment second.
 *
 * @param first line segment interpreted as line
 * @param second line segment
 * @return <code>true</code> if line segment first touches or
 *                           crosses line second,
 *         <code>false</code> otherwise.
 */
        public bool lineSegmentTouchesOrCrossesLine(LineSegment a, LineSegment b)
        {
            return isPointOnLine(a, b.first)
                    || isPointOnLine(a, b.second)
                    || (isPointRightOfLine(a, b.first) ^
                        isPointRightOfLine(a, b.second));
        }

        /**
 * Check if line segments intersect
 * @param a first line segment
 * @param b second line segment
 * @return <code>true</code> if lines do intersect,
 *         <code>false</code> otherwise
 *   */
        public bool doLinesIntersect(Point point1OnLine1, Point point2OnLine1,
                                    Point point1OnLine2, Point point2OnLine2)
        {
            LineSegment a = new LineSegment(point1OnLine1, point2OnLine1);
            LineSegment b = new LineSegment(point1OnLine2, point2OnLine2);
            Point[] box1 = a.getBoundingBox();
            Point[] box2 = b.getBoundingBox();
            return doBoundingBoxesIntersect(box1, box2)
                    && lineSegmentTouchesOrCrossesLine(a, b)
                    && lineSegmentTouchesOrCrossesLine(b, a);
        }
    }
}
