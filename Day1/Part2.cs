using System.Diagnostics.CodeAnalysis;
using Commen.Interface;

namespace Day1;

public class Part2 : Solve
{
    public int Solve()
    {
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
        var result = 0;
        
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
            
            result += Convert.ToInt32(lvalue + hvalue);
        }

        return result;
    }
}