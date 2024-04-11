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
    public int Width => Content.Count != 0 ? Content.Max(line => TextUtils.GetLineWidth(line)) : 0;



    public List<string> FormatedContent = [];

    /// <summary>
    /// Use max line width of content
    /// </summary>
    public void Format()
    {
        var maxWidth = Content.Max(line => TextUtils.GetLineWidth(line));
        Format(maxWidth);
    }

    public void Format(int width)
    {
        FormatedContent.Clear();
        foreach (var line in Content)
        {
            if (TextUtils.GetLineWidth(line) > width) FormatedContent.AddRange(TextUtils.WarpLine(width, line));
            else FormatedContent.Add(line);
        }
    }

}