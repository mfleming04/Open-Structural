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
using DynamoServices;
using Revit.Application;
using Revit.Elements;
using ProtoCore.AST.AssociativeAST;

namespace ZeroTouch.GetElements
{
    public class GetElements
    {
        public static List<int> GetElementIds(List<Revit.Elements.Element> elems)
        {
            List<int> ids = new List<int>();
            foreach (Element e in elems)
            {
                ids.Add(e.Id);
            }
            return ids;
        }

        public static List<int> GetFilledRegionIds(List<Revit.Elements.FilledRegionType> FilledRegions)
        {
            List<int> ids = new List<int>();
            foreach (FilledRegionType e in FilledRegions)
            {
                ids.Add(e.Id);
            }
            return ids;
        }
        public static List<int> GetStrc(List<Revit.Elements.StructuralFraming> StrFram)
        {
            List<int> ids = new List<int>();
            foreach (StructuralFraming e in StrFram)
            {
                ids.Add(e.Id);
            }
            return ids;
        }
        public static List<string> GetStrcString(List<Revit.Elements.StructuralFraming> StrFramStr)
        {
            List<string> names = new List<string>();
            foreach (StructuralFraming e in StrFramStr)
            {
                names.Add(e.Name);
            }
            return names;
        }
    }
}
