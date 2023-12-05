using Commen.Interface;

namespace Day4;

public class Part2 : Solve
{
    public int Solve()
    {
        var file = File.ReadAllLines("../../../input.txt");
        var copies = Enumerable.Repeat(1, file.Length).ToArray();
        

        foreach (var line in file.Select((value, index) => new { value, index}))
        {
            var split = line.value[line.value.IndexOf(':')..].Split('|');
            var myNumbers = split[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
            var tempIndex = 1;
            foreach (var element in split[0].Split(" ", StringSplitOptions.RemoveEmptyEntries))
            {
                if (line.index + tempIndex >= file.Length)
                {
                    break;
                }

                if (!myNumbers.Contains(element)) continue;
                
                copies[line.index + tempIndex] += 1 * copies[line.index];
                tempIndex++;
            }
        }

        return copies.Sum();
    }
}