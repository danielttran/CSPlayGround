using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Events
{
    public class NodeIdChanged : EventArgs
    {
        public NodeIdChanged(string oldId, string newId)
        {
            PreviousNodeId = oldId;
            NewNodeId = newId;
        }

        public string PreviousNodeId { get; }
        public string NewNodeId { get; }
    }
}
