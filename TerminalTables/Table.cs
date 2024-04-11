using System.Text;

namespace TerminalTables;

using TableRow = List<TableCell>;

public class Table
{
    public List<TableRow> Rows { get; } = [];

    public Table(params string[] columns)
    {
        var firstRow = columns.Select(
            col => new TableCell(col)
        ).ToList();

        Rows.Add(firstRow);
    }

    public int GetColumnMaxWidth(int columnOrder)
    {
        if (columnOrder >= Rows.First().Count)
            throw new ArgumentOutOfRangeException("Colume order out of table columns range");

        int maxWidth = 0;
        for (int i = 0; i < Rows.Count; i++)
        {
            var currentColumnWidth = Rows[i][columnOrder].Width;
            if (currentColumnWidth > maxWidth) maxWidth = currentColumnWidth;
        }

        return maxWidth;
    }

    public int GetRowMaxHeight(int rowOrder)
    {
        if (rowOrder >= Rows.Count) throw new ArgumentOutOfRangeException("Row order out of table rows range");

        int maxHeight = 0;
        for (int i = 0; i < Rows[rowOrder].Count; i++)
        {
            var currentRowHeight = Rows[rowOrder][i].Heigh;
            if (currentRowHeight > maxHeight) maxHeight = currentRowHeight;
        }

        return maxHeight;
    }

    public string Export()
    {
        throw new NotImplementedException();
    }
}