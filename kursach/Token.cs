namespace kursach;

public enum TokenType
{
    Идентификатор,
    Присваивание,
    ОткрывающаяСкобка,
    ЗакрывающаяСкобка,
    Запятая,
    Стрелка,
    Оператор,
    ТочкаСЗапятой,
    Неизвестно
}

public class Token
{
    public TokenType Type { get; set; }
    public string Value { get; set; }
    public int Position { get; set; }

    public Token(TokenType type, string value, int position)
    {
        Type = type;
        Value = value;
        Position = position;
    }

    public override string ToString() => $"{Type}('{Value}') at {Position}";
}