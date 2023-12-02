// See https://aka.ms/new-console-template for more information

using Microsoft.VisualBasic;

/*string[] file = File.ReadAllLines("../../../input.txt");
int result = 0;

foreach (var line in file)
{
    var number = "";
    foreach (var c in line)
    {
        var check = int.TryParse(Convert.ToString(c), out var value);
        if (check)
        {
            number += Convert.ToString(value);
        }
    }

    var firstAndLastDigit = Convert.ToString(number[0]);
    if (number.Length > 1) firstAndLastDigit += number[^1]; 
    if (number.Length == 1) firstAndLastDigit += number[0];
    result += Convert.ToInt32(firstAndLastDigit);
}*/

//Console.WriteLine(result);


// PART 2

var validDigits = new Dictionary<string, string>()
{
    {"one", "1"},
    {"two", "2"},
    {"three", "3"},
    {"four", "4"},
    {"five", "5"},
    {"six", "6"},
    {"seven", "7"},
    {"eight", "8"},
    {"nine", "9"}
};

var file2 = File.ReadAllLines("../../../input.txt");
var result2 = 0;
var index = 1;
foreach (var line in file2)
{
    var hindex = -1;
    var lindex = -1;
    var hvalue = "";
    var lvalue = "";
    foreach (var digit in validDigits)
    {
        if (line.Contains(digit.Key))
        {
            if (hindex < line.LastIndexOf(digit.Key) && hindex != -1)
            {
                hindex = line.LastIndexOf(digit.Key);
                hvalue = digit.Value;
            } 
            if (lindex > line.IndexOf(digit.Key) && lindex != -1)
            {
                lindex = line.IndexOf(digit.Key);
                lvalue = digit.Value;
            }
            if (lindex == -1 && hindex == -1)
            {
                hindex = line.LastIndexOf(digit.Key);
                hvalue = digit.Value;
                lindex = line.IndexOf(digit.Key);
                lvalue = digit.Value;
            }
        }
        
        if (line.Contains(digit.Value))
        {
            if (hindex < line.LastIndexOf(digit.Value) && hindex != -1)
            {
                hindex = line.LastIndexOf(digit.Value);
                hvalue = digit.Value;
            } 
            if (lindex > line.IndexOf(digit.Value) && lindex != -1)
            {
                lindex = line.IndexOf(digit.Value);
                lvalue = digit.Value;
            }
            
            if (lindex == -1 && hindex == -1)
            {
                hindex = line.LastIndexOf(digit.Value);
                hvalue = digit.Value;
                lindex = line.IndexOf(digit.Value);
                lvalue = digit.Value;
            }
        }
    }
    Console.WriteLine("hindex: " + hindex + " hvalue: " + hvalue + " lindex: " + lindex + " lvalue: " + lvalue + " result: " + (lvalue + hvalue) + " index: " + index);
    result2 += Convert.ToInt32(lvalue + hvalue);
    index++;
}
Console.WriteLine(result2);