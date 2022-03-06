namespace MyNotes
{
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance { get { return lazy.Value; } }

        public int nodeId { get; set; } = 0;

        private Singleton()
        {
        }
    }
}
