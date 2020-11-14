namespace Acrysel.Parsing
{
    public struct Flag
    {
        public string Prefix { get; private set; }
        public string Name { get; private set; }

        public Flag(string prefix, string name)
        {
            Prefix = prefix;
            Name = name;
        }
    }
}