# Terminal Table

Print Data as table to Terminal

## Example usage

```c#
var table = new Table("Name", "Age", "Gender");
table.AddRow("Ryouji", "43", "Male");
table.AddRow("Rei", "16", "Female");
var str = table.Export(cellWidth: 20);
Console.WriteLine(str);

Console.WriteLine();

var table2 = new Table("Command", "Description");
var row = new List<TableCell>()
{
    new("add"),
    new([
        "Add some text to array",
        "",
        "Add some number to array"
    ])
};
table2.AddRow(row);
var str2 = table2.Export(cellWidth: 25);
Console.WriteLine(str2);
Console.WriteLine();
var str3 = table2.Export(cellWidth: 20);
Console.WriteLine(str3);
```

**Console output**
```shell
Name                  Age                   Gender                
Ryouji                43                    Male                  
Rei                   16                    Female                


Command                    Description                
add                        Add some text to array     
                                                      
                           Add some number to array   


Command               Description           
add                   Add some text to arr  
                      ay                    
                                            
                      Add some number to a  
                      rray                  
```