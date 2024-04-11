namespace TerminalTables;

public class TableCell
{
    public TableCell(string content)
    {
        Content.Add(content);
    }

    public enum Alignment
    {
        Left,
        Right,
        Center,
    }

    public Alignment Align = Alignment.Left;
    public List<string> Content = [];
    public int Heigh => Content.Count;
    public int Width => Content.Count != 0 ? Content.Max(line => GetTextWidth(line)) : 0;

    private static int GetTextWidth(string value)
    {
        if (value == null)
            return 0;

        var length = value.ToCharArray().Sum(c => c > 127 ? 2 : 1);
        return length;
    }
}