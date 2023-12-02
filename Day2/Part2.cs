using Commen.Interface;

namespace Day2;

public class Part2 : Solve
{
    public int Solve()
    {
        var file = File.ReadAllLines("../../../input.txt");
        var result = 0;
        
        var newFile = file.Select(line => line[(line.IndexOf(':') +2)..].Split(',',';'));

        foreach (var line in newFile)
        {
            var redFewest = 0;
            var greenFewest = 0;
            var blueFewest = 0;
            foreach (var element in line)
            {
                var split = element.TrimStart().TrimEnd().Split(" ");
                Console.WriteLine(split[0] + " " + split[1]);
                if (split[1] == "red" && Convert.ToInt32(split[0]) > redFewest) redFewest = Convert.ToInt32(split[0]);
                if (split[1] == "green" && Convert.ToInt32(split[0]) > greenFewest) greenFewest = Convert.ToInt32(split[0]);
                if (split[1] == "blue" && Convert.ToInt32(split[0]) > blueFewest) blueFewest = Convert.ToInt32(split[0]);
            }
            result += redFewest * greenFewest * blueFewest;
        }
        
        return result;
    }
}