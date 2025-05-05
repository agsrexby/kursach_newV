using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace kursach
{
    public class Lexer
    {
        private readonly string _input;
        private int _position;

        private static readonly Regex IdentifierRegex = new Regex("^[a-zA-Z_][a-zA-Z0-9_]*", RegexOptions.Compiled);

        public Lexer(string input)
        {
            _input = input;
        }

        public List<Token> Tokenize()
        {
            List<Token> tokens = new List<Token>();

            while (_position < _input.Length)
            {
                char current = _input[_position];
                int start = _position;

                if (char.IsWhiteSpace(current))
                {
                    _position++;
                    continue;
                }
                else if (current == '=')
                {
                    tokens.Add(new Token(TokenType.Присваивание, "=", _position++));
                }
                else if (current == '(')
                {
                    tokens.Add(new Token(TokenType.ОткрывающаяСкобка, "(", _position++));
                }
                else if (current == ')')
                {
                    tokens.Add(new Token(TokenType.ЗакрывающаяСкобка, ")", _position++));
                }
                else if (current == ',')
                {
                    tokens.Add(new Token(TokenType.Запятая, ",", _position++));
                }
                else if (current == '-' && Peek() == '>')
                {
                    tokens.Add(new Token(TokenType.Стрелка, "->", _position));
                    _position += 2;
                }
                else if (current == '+' || current == '-' || current == '*' || current == '/')
                {
                    tokens.Add(new Token(TokenType.Оператор, current.ToString(), _position++));
                }
                else if (current == ';')
                {
                    tokens.Add(new Token(TokenType.ТочкаСЗапятой, ";", _position++));
                }
                else if (char.IsLetter(current) || current == '_')
                {
                    var match = IdentifierRegex.Match(_input.Substring(_position));
                    if (match.Success)
                    {
                        string value = match.Value;
                        tokens.Add(new Token(TokenType.Идентификатор, value, _position));
                        _position += value.Length;
                    }
                    else
                    {
                        tokens.Add(new Token(TokenType.Неизвестно, current.ToString(), _position++));
                    }
                }
                else
                {
                    tokens.Add(new Token(TokenType.Неизвестно, current.ToString(), _position++));
                }
            }

            return tokens;
        }

        private char Peek() => _position + 1 < _input.Length ? _input[_position + 1] : '\0';
    }
}
