using Xunit.Abstractions;

namespace TerminalTables.Test;

public class TableTest
{
    private readonly ITestOutputHelper output;

    public TableTest(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void ColumnsMaxWidthTest()
    {
        var table = new Table("one", "two", "three");

        var firstRow = new List<TableCell>()
        {
            new(["This is a test sentence", "114514"]),
            new(["滚滚长江东逝水，浪花淘尽英雄。是非成败转头空，青山依旧在，几度夕阳红。"]),
            new(["滚滚长江东逝水，浪花淘尽英雄。是非成败转头空，青山依旧在，几度夕阳红。"]),

        };
        table.Rows.Add(firstRow);

        int[] result = [23, 70, 70];
        Assert.Equal(result, table.ColumnsMaxWidth);
    }

    [Fact]
    public void FormatRowTest()
    {
        var table = new Table("one", "two", "three");

        var firstRow = new List<TableCell>()
        {
            new(["This is a test sentence", "114514"]),
            new(["滚滚长江东逝水，浪花淘尽英雄。是非成败转头空，青山依旧在，几度夕阳红。"]),
            new(["滚滚长江东逝水，浪花淘尽英雄。是非成败转头空，青山依旧在，几度夕阳红。"]),
        };
        table.Rows.Add(firstRow);

        var tableData = table.FormatRows([30,50,50],table.Rows);
        var tableStr = Table.ExportTableData(tableData);
        output.WriteLine(tableStr);
    }
}