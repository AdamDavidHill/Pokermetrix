﻿



//------------------------------------------------------------------------------
//  Microsoft Avalon
//  Copyright (c) Microsoft Corporation, 2001, 2002
//
//  File: Vector.cs
//-----------------------------------------------------------------------------
using System;
using System.ComponentModel;
//using System.ComponentModel.Design.Serialization;
using System.Reflection;
//using MS.Internal;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Runtime.InteropServices;

namespace PokermetrixWP7.Chart
{
    /// <summary>
    /// Vector - A value type which defined a vector in terms of X and Y
    /// </summary>
    public partial struct Vector
    {
        double _x;
        double _y;

        #region Constructors

        /// <summary>
        /// Constructor which sets the vector's initial values
        /// </summary>
        /// <param name="x"> double - The initial X
        /// <param name="y"> double - THe initial Y 
        public Vector(double x, double y)
        {
            _x = x;
            _y = y;
        }

        #endregion Constructors

        public double X
        {
            get
            {
                return this._x;
            }
            set
            {
                this._x = value;
            }
        }

        public double Y
        {
            get
            {
                return this._y;
            }
            set
            {
                this._y = value;
            }
        }



        #region Public Methods

        /// <summary>
        /// Length Property - the length of this Vector
        /// </summary>
        public double Length
        {
            get
            {
                return Math.Sqrt(_x * _x + _y * _y);
            }
        }

        /// <summary>
        /// LengthSquared Property - the squared length of this Vector
        /// </summary>
        public double LengthSquared
        {
            get
            {
                return _x * _x + _y * _y;
            }
        }

        /// <summary>
        /// Normalize - Updates this Vector to maintain its direction, but to have a length
        /// of 1.  This is equivalent to dividing this Vector by Length
        /// </summary>
        public void Normalize()
        {
            // Avoid overflow
            this /= Math.Max(Math.Abs(_x), Math.Abs(_y));
            this /= Length;
        }

        /// <summary>
        /// CrossProduct - Returns the cross product: vector1.X*vector2.Y - vector1.Y*vector2.X
        /// </summary>
        /// <returns>
        /// Returns the cross product: vector1.X*vector2.Y - vector1.Y*vector2.X
        /// </returns>
        /// <param name="vector1"> The first Vector 
        /// <param name="vector2"> The second Vector
        public static double CrossProduct(Vector vector1, Vector vector2)
        {
            return vector1._x * vector2._y - vector1._y * vector2._x;
        }

        /// <summary>
        /// AngleBetween - the angle between 2 vectors
        /// </summary>
        /// <returns>
        /// Returns the the angle in degrees between vector1 and vector2
        /// </returns>
        /// <param name="vector1"> The first Vector 
        /// <param name="vector2"> The second Vector
        public static double AngleBetween(Vector vector1, Vector vector2)
        {
            double sin = vector1._x * vector2._y - vector2._x * vector1._y;
            double cos = vector1._x * vector2._x + vector1._y * vector2._y;

            return Math.Atan2(sin, cos) * (180 / Math.PI);
        }

        #endregion Public Methods

        #region Public Operators
        /// <summary>
        /// Operator -Vector (unary negation)
        /// </summary>
        public static Vector operator -(Vector vector)
        {
            return new Vector(-vector.X, -vector.Y);
        }

        /// <summary>
        /// Negates the values of X and Y on this Vector
        /// </summary>
        public void Negate()
        {
            _x = -_x;
            _y = -_y;
        }

        /// <summary>
        /// Operator Vector + Vector
        /// </summary>
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(vector1._x + vector2._x,
                              vector1._y + vector2._y);
        }

        /// <summary>
        /// Add: Vector + Vector
        /// </summary>
        public static Vector Add(Vector vector1, Vector vector2)
        {
            return new Vector(vector1._x + vector2._x,
                              vector1._y + vector2._y);
        }

        /// <summary>
        /// Operator Vector - Vector
        /// </summary>
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return new Vector(vector1._x - vector2._x,
                              vector1._y - vector2._y);
        }

        /// <summary>
        /// Subtract: Vector - Vector
        /// </summary>
        public static Vector Subtract(Vector vector1, Vector vector2)
        {
            return new Vector(vector1._x - vector2._x,
                              vector1._y - vector2._y);
        }

        /// <summary>
        /// Operator Vector + Point
        /// </summary>
        public static Point operator +(Vector vector, Point point)
        {
            return new Point(point.X + vector.X, point.Y + vector.Y);
        }

        /// <summary>
        /// Add: Vector + Point
        /// </summary>
        public static Point Add(Vector vector, Point point)
        {
            return new Point(point.X + vector.X, point.Y + vector.Y);
        }

        /// <summary>
        /// Operator Vector * double
        /// </summary>
        public static Vector operator *(Vector vector, double scalar)
        {
            return new Vector(vector.X * scalar,
                              vector.Y * scalar);
        }

        /// <summary>
        /// Multiply: Vector * double
        /// </summary>
        public static Vector Multiply(Vector vector, double scalar)
        {
            return new Vector(vector.X * scalar,
                              vector.Y * scalar);
        }

        /// <summary>
        /// Operator double * Vector
        /// </summary>
        public static Vector operator *(double scalar, Vector vector)
        {
            return new Vector(vector.X * scalar,
                              vector.Y * scalar);
        }

        /// <summary>
        /// Multiply: double * Vector
        /// </summary>
        public static Vector Multiply(double scalar, Vector vector)
        {
            return new Vector(vector.X * scalar,
                              vector.Y * scalar);
        }

        /// <summary>
        /// Operator Vector / double
        /// </summary>
        public static Vector operator /(Vector vector, double scalar)
        {
            return vector * (1.0 / scalar);
        }

        /// <summary>
        /// Multiply: Vector / double
        /// </summary>
        public static Vector Divide(Vector vector, double scalar)
        {
            return vector * (1.0 / scalar);
        }

        /// <summary>
        /// Operator Vector * Matrix
        /// </summary>
        //public static Vector operator * (Vector vector, Matrix matrix)
        //{
        //    return matrix.Transform(vector);
        //}

        /// <summary>
        /// Multiply: Vector * Matrix
        /// </summary>
        //public static Vector Multiply(Vector vector, Matrix matrix)
        //{
        //    return matrix.Transform(vector);
        //}

        /// <summary>
        /// Operator Vector * Vector, interpreted as their dot product
        /// </summary>
        public static double operator *(Vector vector1, Vector vector2)
        {
            return vector1._x * vector2._x + vector1._y * vector2._y;
        }

        /// <summary>
        /// Multiply - Returns the dot product: vector1.X*vector2.X + vector1.Y*vector2.Y
        /// </summary>
        /// <returns>
        /// Returns the dot product: vector1.X*vector2.X + vector1.Y*vector2.Y
        /// </returns>
        /// <param name="vector1"> The first Vector 
        /// <param name="vector2"> The second Vector 
        public static double Multiply(Vector vector1, Vector vector2)
        {
            return vector1._x * vector2._x + vector1._y * vector2._y;
        }

        /// <summary>
        /// Determinant - Returns the determinant det(vector1, vector2)
        /// </summary>
        /// <returns>
        /// Returns the determinant: vector1.X*vector2.Y - vector1.Y*vector2.X
        /// </returns>
        /// <param name="vector1"> The first Vector
        /// <param name="vector2"> The second Vector
        public static double Determinant(Vector vector1, Vector vector2)
        {
            return vector1._x * vector2._y - vector1._y * vector2._x;
        }

        /// <summary>
        /// Explicit conversion to Size.  Note that since Size cannot contain negative values,
        /// the resulting size will contains the absolute values of X and Y
        /// </summary>
        /// <returns>
        /// Size - A Size equal to this Vector
        /// </returns>
        /// <param name="vector"> Vector - the Vector to convert to a Size 
        public static explicit operator Size(Vector vector)
        {
            return new Size(Math.Abs(vector.X), Math.Abs(vector.Y));
        }

        /// <summary>
        /// Explicit conversion to Point
        /// </summary>
        /// <returns>
        /// Point - A Point equal to this Vector
        /// </returns>
        /// <param name="vector"> Vector - the Vector to convert to a Point 
        public static explicit operator Point(Vector vector)
        {
            return new Point(vector.X, vector.Y);
        }
        #endregion Public Operators
    }
}

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
// Copyright (c) Microsoft Corporation. All rights reserved.