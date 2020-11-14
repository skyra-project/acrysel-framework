using Acrysel.Parsing.Tokens;
using System;
using System.Collections.Generic;

namespace Acrysel.Parsing
{
    public sealed class Parser
    {
        
        public bool PrefixFound { get; private set; }
        public string PrefixUsed { get; private set; }
        
        private readonly string[] _prefixes;
        private readonly string _seperator;
        private readonly string _input;
        
        private int _head;
        private ParseMode _parseMode;
        private bool _isCaseSensitive;
        private string[] _flagPrefixes;

        private List<OptionToken> _options = new List<OptionToken>();

        public Parser(string[] prefixes, string seperator, string[] flagPrefixes, string input)
        {
            _prefixes = prefixes;
            _seperator = seperator;
            _input = input;
            _flagPrefixes = flagPrefixes;
            _head = 0;
            _parseMode = ParseMode.Unknown;
        }

        public void Parse()
        {
            var (found, prefix) = ParsePrefix();

            if (!found) return; // bail early

        }

        private (bool, string) ParsePrefix()
        {
            
            foreach (var prefix in _prefixes)
            {
                var comparisonMethod = _isCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

                var length = prefix.Length;

                var peeked = Peek(0, length);

                if (string.Equals(prefix, peeked, comparisonMethod))
                {
                    Seek(length);
                    PrefixFound = true;
                    PrefixUsed = prefix;
                    return (true, prefix);
                }
            }

            return (false, "");
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

        internal void Seek(int amount)
        {
            _head += amount;
        }
        
    }
}