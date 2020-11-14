namespace Acrysel.Parsing
{
    public struct Option<T>
    {
        public string Prefix { get; private set; }
        public string Name { get; private set; }
        public T Value { get; internal set; }
    }
}