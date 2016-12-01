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

namespace ZeroTouch.UI
{
    [NodeName("OpenStrc-Element Drop Down")]
    [NodeDescription("Matts example drop down node.")]
    [IsDesignScriptCompatible]


    public class ElementDropDownTest : DSDropDownBase
    {
        
        public ElementDropDownTest() : base("item") { }
        protected override SelectionState PopulateItemsCore(string currentSelection)
        {
            // The Items collection contains the elements
            // that appear in the list. For this example, we
            // clear the list before adding new items, but you
            // can also use the PopulateItems method to add items
            // to the list.

            Items.Clear();

            // Create a number of DynamoDropDownItem objects 
            // to store the items that we want to appear in our list.


            //Document doc = DocumentManager.Instance.CurrentDBDocument;
            //UIApplication uiapp = DocumentManager.Instance.CurrentUIApplication;
            //Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
           // UIDocument uidoc = DocumentManager.Instance.CurrentUIApplication.ActiveUIDocument;

            var newItems = new List<DynamoDropDownItem>()
            {
                new DynamoDropDownItem("Jack", 0),
                new DynamoDropDownItem("Kicks", 1),
                new DynamoDropDownItem("Ass",2),
                new DynamoDropDownItem("Too",3)
            };

            Items.AddRange(newItems);

            // Set the selected index to something other
            // than -1, the default, so that your list
            // has a pre-selection.

            SelectedIndex = 0;
            return SelectionState.Done;
        }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            // Build an AST node for the type of object contained in your Items collection.

            var intNode = AstFactory.BuildIntNode((int)Items[SelectedIndex].Item);
            var assign = AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), intNode);

            return new List<AssociativeNode> { assign };
        }
    }
}
