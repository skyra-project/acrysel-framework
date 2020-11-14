using System;

namespace Acrysel.Parsing
{
    public class Parser
    {
        private readonly string[] _prefixes;
        private readonly string _seperator;
        private readonly string _input;
        
        private int _head;
        private ParseMode _parseMode;
        private bool _isCaseSensitive;

        private readonly string[] _flagOrOptionStartHints = new[] {"--", "-", "—"};

        public Parser(string[] prefixes, string seperator, string input)
        {
            _prefixes = prefixes;
            _seperator = seperator;
            _input = input;
            _head = 0;
            _parseMode = ParseMode.Unknown;
        }

        public string Peek(int ahead = 0, int amount = 1)
        {
            var start = _head + ahead;
            var end = start + amount;
            return _input[start..end];
        }

        public char Consume(int ahead = 0)
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