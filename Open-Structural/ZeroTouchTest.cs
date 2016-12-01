using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;
using Autodesk.DesignScript.Interfaces;
using Autodesk.DesignScript.Geometry;
using CoreNodeModels;
using Dynamo.Graph.Nodes;
using Dynamo.Utilities;
using ProtoCore.AST.AssociativeAST;

namespace ZeroTouch.Functions
{
    
public class ZeroTouchEssentials
    {
        // Two private variables for example purposes
        private double _a;
        private double _b;
        private string _stra;

        // We make the constructor for this object internal because the 
        // Dynamo user should construct an object through a static method
        internal ZeroTouchEssentials(double a, double b)
        {
            _a = a;
            _b = b;
        }

        /// <summary>
        /// An example of how to construct an object via a static method.
        /// This is needed as Dynamo lacks a "new" keyword to construct a 
        /// new object
        /// </summary>
        /// <param name="a">1st number. This will be stored in the Class.</param>
        /// <param name="b">2nd number. This will be stored in the Class</param>
        /// <returns>A newly-constructed ZeroTouchEssentials object</returns>
        public static ZeroTouchEssentials ByTwoDoubles(double a, double b)
        {
            return new ZeroTouchEssentials(a, b);
        }

        /// <summary>
        /// Example property returning the value _a inside the object
        /// </summary>
        public double A
        {
            get { return _a; }
        }

        /// <summary>
        /// Example property returning the value _b inside the object
        /// </summary>
        public double B
        {
            get { return _b; }
        }

        /// <summary>
        ///     An example showing how to return multiple values from a Zero-Touch imported node
        ///     The names in the attribute should match the keys in the returned dictionary.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns name="add">Number created by adding two inputs together.</returns>
        /// <returns name="mult">Number created by multiplying two inputs together.</returns>
        /// <search>example,multi</search>
        [MultiReturn(new[] { "add", "mult" })]
     

        /// <summary>
        /// This method demonstrates how to use a native geometry object from Dynamo
        /// in a custom method
        /// </summary>
        /// <param name="curve">Input Curve. This can be of any type deriving from Curve, such as NurbsCurve, Arc, Circle, etc</param>
        /// <returns>The twice the length of the Curve </returns>
        public static double DoubleLength(Autodesk.DesignScript.Geometry.Curve curve)
        {
            return curve.Length * 2.0;
        }

        public string Stra
        {
            get { return _stra; }
        }
        internal ZeroTouchEssentials(string stra)
        {
            _stra = stra;
        }

        public static ZeroTouchEssentials RebarCoverTypeString(string stra)
        {
            return new ZeroTouchEssentials(stra);
        }
    }
}
