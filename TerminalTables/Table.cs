using System.Text;

namespace TerminalTables;

using TableRow = List<TableCell>;
using RowData = List<List<string>>;
using TableData = List<List<List<string>>>;

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
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(columnOrder, Rows.First().Count);

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
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(rowOrder, Rows.Count);

        int maxHeight = 0;
        for (int i = 0; i < Rows[rowOrder].Count; i++)
        {
            var currentRowHeight = Rows[rowOrder][i].Heigh;
            if (currentRowHeight > maxHeight) maxHeight = currentRowHeight;
        }

        return maxHeight;
    }

    public int[] ColumnsMaxWidth => Enumerable.Range(0, Rows.First().Count)
                                              .Select(c => Rows.Max(row => row[c].Width))
                                              .ToArray();

    public RowData FormatRow(int[] columnWidth, TableRow row)
    {
        // Format row width
        var formatRowData = row.Select(
                (cell, c) => cell.Format(columnWidth[c])
            ).ToList();

        // Format row height
        int maxHeight = formatRowData.Max(cell => cell.Count);
        formatRowData = formatRowData.Select(cell =>
                cell.Concat(Enumerable.Repeat(" ", maxHeight - cell.Count)).ToList()
            ).ToList();

        return formatRowData;
    }

    public TableData FormatRows(int[] columnWidth, List<TableRow> rows)
    {
        return rows.Select(row => FormatRow(columnWidth, row)).ToList();
    }

    public static string ExportTableData(TableData tableData)
    {
        var sb = new StringBuilder();
        foreach (var row in tableData)
        {
            sb.Append(ExportRowData(row));
        }

        return sb.ToString();
    }

    public static string ExportRowData(RowData rowData)
    {
        var sb = new StringBuilder();

        for (int r = 0; r < rowData.First().Count; r++)
        {
            for (int c = 0; c < rowData.Count; c++)
            {
                sb.Append(rowData[c][r]);
                sb.Append("  ");
            }
            sb.Append(Environment.NewLine);
        }

        return sb.ToString();
    }
}