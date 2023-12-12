using Commen.Interface;

namespace Day4;

public class Part1 : ISolve<int>
{
    public int Solve()
    {
        var file = File.ReadAllLines("../../../input.txt");

        return (from line in file
            select line[line.IndexOf(':')..].Split('|')
            into split
            let myNumbers = split[1].Split(" ", StringSplitOptions.RemoveEmptyEntries)
            select split[0]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(myNumbers.Contains)
                .Aggregate(0, (current, _) => current == 0 ? 1 : current * 2)).Sum();
    }
}