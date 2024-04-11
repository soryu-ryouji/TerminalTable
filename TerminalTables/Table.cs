using System.Text;

namespace TerminalTables;

using TableRow = List<TableCell>;

public class Table
{
    public List<TableCell> Columns { get; } = [];

    public List<TableRow> Rows { get; } = [];

    public Table(params string[] columns)
    {
        Columns = columns.Select(
            col => new TableCell(col)
        ).ToList();
    }
}