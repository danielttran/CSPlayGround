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

        private UserData data;
        public UserData Data
        {
            get
            {
                if (data == null)
                    data = new UserData();
                return data;
            }
            set { data = value; }
        }

        public event EventHandler NodeIdChanged;

        private string nodeId = string.Empty;
        public string NodeId 
        {
            get { return nodeId; }
            set
            {
                OnNodeIdChanged(new NodeIdChanged(NodeId, value));
                nodeId = value;
            }
        }

        private void OnNodeIdChanged(EventArgs e)
        {
            NodeIdChanged?.Invoke(this, e);
        }
    }
}
