using Xunit.Abstractions;

namespace TerminalTables;

public class TableCellTest
{
    private readonly ITestOutputHelper output;

    public TableCellTest(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void FormatTest()
    {
        string[] content = [
            "This is a test sentence",
            "",
            "滚滚长江东逝水，浪花淘尽英雄。是非成败转头空，青山依旧在，几度夕阳红。"
        ];
        var cell = new TableCell(content);
        var formattedContent = cell.Format(8);

        var result = new List<string>()
        {
            "This is ",
            "a test s",
            "entence ",
            "        ",
            "滚滚长江",
            "东逝水，",
            "浪花淘尽",
            "英雄。是",
            "非成败转",
            "头空，青",
            "山依旧在",
            "，几度夕",
            "阳红。  "
        };

        Assert.Equal(formattedContent, result);
    }
}