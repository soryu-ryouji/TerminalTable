namespace TerminalTables;

public class TableCell
{
    public TableCell(string content)
    {
        Content.Add(content);
    }

    public TableCell(string[] content)
    {
        Content.AddRange(content);
    }

    public TableCell()
    {

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
    public int Width => Content.Count != 0 ? Content.Max(line => TextUtils.GetLineWidth(line)) : 0;

    public List<string> Format(int width)
    {
        var formattedContent = new List<string>();

        foreach (var line in Content)
        {
            if (TextUtils.GetLineWidth(line) < width)
            {
                formattedContent.Add(line + " ".Repeat(width - TextUtils.GetLineWidth(line)));
            }
            else if (TextUtils.GetLineWidth(line) > width) formattedContent.AddRange(TextUtils.WarpLine(width, line));
            else formattedContent.Add(line + " ".Repeat(width - TextUtils.GetLineWidth(line)));
        }

        return formattedContent;
    }
}