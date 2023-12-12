using Commen.Interface;

namespace Day5;

public class Part1 : ISolve<long>
{
    public long Solve()
    {
        var file = File.ReadAllLines("../../../input.txt");

        var seeds = file[0]
            .Split(':')[1]
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(x => Convert.ToInt64(x))
            .ToList();

        var map = new List<Nodes>();

        foreach (var line in file.Skip(1))
        {
            if (line.Length == 0) continue;
            
            if (line[^1] == ':')
            {
                map.Add(new Nodes());
                continue;
            }
            
            var split = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var node = new Node(split);
            map.Last().NodesList.Add(node);
        }

        return seeds
            .Select(seed => map
                .Aggregate(seed, (current1, node) => node
                    .GetMapping(current1)
                ))
            .Aggregate(long.MaxValue, long.Min);
    }

    private class Node(IReadOnlyList<string> input)
    {
        public long SourceRangeStart { get; } = Convert.ToInt64(input[1]);
        public long DestinationRangeStart { get; } = Convert.ToInt64(input[0]);
        public long RangeLength { get; } = Convert.ToInt64(input[2]);
    }

    private class Nodes
    {
        public List<Node> NodesList { get; } = [];
        
        public long GetMapping(long seed)
        {
            foreach (var nodes in NodesList.Where(nodes => seed >= nodes.SourceRangeStart && seed <= nodes.SourceRangeStart + nodes.RangeLength))
            {
                return nodes.DestinationRangeStart + (seed - nodes.SourceRangeStart);
            }

            return seed;
        }
    }
}