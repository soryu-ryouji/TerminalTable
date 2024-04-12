using Xunit.Abstractions;

namespace TerminalTables.Test;

public class TextUtilsTest
{
    private readonly ITestOutputHelper output;

    public TextUtilsTest(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void WarpLineTest()
    {
        var line = "This is a test sentence";
        var warp = TextUtils.WarpLine(8, line);

        var zhLines = "滚滚长江东逝水，浪花淘尽英雄。是非成败转头空，青山依旧在，几度夕阳红。";
        var zhWarp = TextUtils.WarpLine(8, zhLines);

        var warpResult = new List<string>(){
            "This is ",
            "a test s",
            "entence "
        };
        var zhWarpResult = new List<string>(){
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
        Assert.Equal(warp, warpResult);
        Assert.Equal(zhWarp, zhWarpResult);
    }
}