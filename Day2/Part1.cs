using Commen.Interface;

namespace Day2;

public class Part1 : Solve
{
    public int Solve()
    {
        var redLimit = 12;
        var greenLimit = 13;
        var blueLimit = 14;
        var file = File.ReadAllLines("../../../input.txt");
        var result = 0;

        var newFile = file.Select(line => line[5..].Split(';', ':'));
        foreach (var line in newFile)
        {
            var id = Convert.ToInt32(line[0]);
            var biggerthan = false;
    
            foreach (var element in line)
            {
                if (!element.Contains("red") && !element.Contains("green") && !element.Contains("blue")) continue;
                var redCount = 0;
                var greenCount = 0;
                var blueCount = 0;
                foreach (var VARIABLE in element.Split(','))
                {
                    var trimmed = VARIABLE.TrimStart().TrimEnd().Split(" ");
                    if (trimmed[1] == "red") redCount += Convert.ToInt32(trimmed[0]);
                    if (trimmed[1] == "green") greenCount += Convert.ToInt32(trimmed[0]);
                    if (trimmed[1] == "blue") blueCount += Convert.ToInt32(trimmed[0]);
                }
                if (redCount > redLimit || greenCount > greenLimit || blueCount > blueLimit)
                {
                    biggerthan = true;
                    break;
                }
            }
    
            if (biggerthan == false) {
                result += id;
            }
        }

        return result;
    }
}