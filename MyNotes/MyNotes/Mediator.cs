using DataAccess.UserData;
using MyNotes.Events;

namespace MyNotes
{
    public sealed class Mediator
    {
        private static readonly Lazy<Mediator> lazy = new Lazy<Mediator>(() => new Mediator());

        public static Mediator Instance { get { return lazy.Value; } }

        private Mediator()
        {
        }

        public event EventHandler NodeIdChanged;

        private string nodeId = string.Empty;
        public string NodeId
        {
            get { return nodeId; }
            set
            {
                if (IsLeftClick)
                {
                    OnLeftClickNode(new NodeIdChanged(NodeId, value));
                }
                nodeId = value;
            }
        }

        public bool IsLeftClick = true;

        public bool TextChanged = false;
        private string richTextContent;

        public string RichTextContent
        {
            get { return richTextContent; }
            set { richTextContent = value; }
        }

        private void OnLeftClickNode(EventArgs e)
        {
            NodeIdChanged?.Invoke(this, e);
        }
    }
}
