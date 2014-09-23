﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Space3D
{
    public class Point3D
    {
        private string name;
        private double x;
        private double y;
        private double z;

        private static readonly Point3D startingPoint;


        public Point3D(string name, double x, double y, double z)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Z = z;
        } 
        static Point3D()
        {
            startingPoint = new Point3D("Center", 0, 0, 0);
        }


        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty or null!");
                }
                this.name = value;
            }
        }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public static Point3D StartingPoint
        {
            get { return Point3D.startingPoint; }
        }

        public override string ToString()
        {

            return String.Format("Point3D name: {0}, X: {1}, Y: {2}, Z: {3}", 
                this.Name, this.X.ToString(), this.Y.ToString(), this.Z.ToString());
        }

        public static Point3D Deserialize(string pointStr) //deserialize meaning - https://www.wordnik.com/words/deserialize
        {
            Regex regex = new Regex(@"(.+?){(.+?),(.+?),(.+?)}");
            MatchCollection matches = regex.Matches(pointStr);
            var g = (matches[0] as Match).Groups;//http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.match.groups(v=vs.110).aspx
            Point3D point = new Point3D(g[1].Value, double.Parse(g[2].Value), double.Parse(g[3].Value), double.Parse(g[4].Value));
            return point;
        }
    }
}