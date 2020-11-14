namespace Acrysel.Parsing
{
    public sealed class Parser
    {
        private readonly string[] _prefixes;
        private readonly string _seperator;
        private readonly string _input;
        
        private int _head;
        private ParseMode _parseMode;
        private bool _isCaseSensitive;
        private string[] _flags;

        public Parser(string[] prefixes, string seperator, string[] flags, string input)
        {
            _prefixes = prefixes;
            _seperator = seperator;
            _input = input;
            _flags = flags;
            _head = 0;
            _parseMode = ParseMode.Unknown;
        }

        internal string Peek(int ahead = 0, int amount = 1)
        {
            var start = _head + ahead;
            var end = start + amount;
            return _input[start..end];
        }

        internal char Consume(int ahead = 0)
        {
            var token = _input[_head + ahead];
            _head += ahead;
            return token;
        }
        
    }


    public enum ParseMode
    {
        Flag,
        Option,
        Unknown
    }
}