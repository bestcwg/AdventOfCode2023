using System.Linq.Expressions;
using System.Xml.XPath;
using Commen.Interface;

namespace Day3;

public class Part2 : ISolve<int>
{
    private readonly List<char> _validCharacters = new()
    {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    };
    
    public int Solve()
    {
        const char gear = '*';
        var file = File.ReadAllLines("../../../input.txt");
        var gearIndexes = new Dictionary<int, List<int>>();

        foreach (var line in file.Select((value, index) => new { value, index }))
        {
            gearIndexes.Add(line.index, new List<int>());
            foreach (var element in line.value.Select((value, index) => new { value, index }))
            {
                if (element.value == gear)
                {
                    gearIndexes[line.index].Add(element.index);
                }
            }
        }

        return (from keyPair in gearIndexes where keyPair.Value.Count != 0 
                from gearIndex in keyPair.Value select CheckSurroundings(keyPair.Key, gearIndex, file)).Sum();
    }
    
    private int CheckSurroundings(int lineIndex, int elementIndex, IReadOnlyList<string> file)
    {
        var lastLine = lineIndex == file.Count - 1;
        var firstLine = lineIndex == 0;
        var firstElement = elementIndex == 0;
        var lastElement = elementIndex == file[lineIndex].Length - 1;
        var count = 0;
        var result = 1;

        if (!firstElement)
        {
            if (_validCharacters.Contains(file[lineIndex][elementIndex - 1]))
            {
                result *= FindWholePartNumber(lineIndex, elementIndex -1, file);
                count++;
            }
        }
        
        if (!lastElement)
        {
            if(_validCharacters.Contains(file[lineIndex][elementIndex + 1]))
            {
                result *= FindWholePartNumber(lineIndex, elementIndex + 1, file);
                count++;
            }
        }
        
        if (!firstLine)
        {
            var(newCount, newResult) = CheckRow(firstElement, lastElement, lineIndex - 1, elementIndex, file);
            count += newCount;
            result *= newResult;
        }
        
        if (!lastLine)
        {
            var(newCount, newResult) = CheckRow(firstElement, lastElement, lineIndex + 1, elementIndex, file);
            count += newCount;
            result *= newResult;
        }

        return count != 2 ? 0 : result;
    }
    
    private int FindWholePartNumber(int lineIndex, int elementIndex, IReadOnlyList<string> file)
    {
        var firstIndex = -1;
        var lastIndex = -1;
        var index = 0;
        
        while(firstIndex == -1 || lastIndex == -1)
        {
            if (firstIndex == -1)
            {
                if (elementIndex - index >= 0)
                {
                    if (!_validCharacters.Contains(file[lineIndex][elementIndex - index]))
                    {
                        firstIndex = elementIndex - index + 1;
                    }
                    else if (elementIndex - index == 0)
                    {
                        firstIndex = 0;
                    }
                }
            }

            if (lastIndex == -1)
            {
                if (elementIndex + index < file[lineIndex].Length)
                {
                    if (!_validCharacters.Contains(file[lineIndex][elementIndex + index]))
                    {
                        lastIndex = elementIndex + index;
                    } 
                    else if (elementIndex + index == file[lineIndex].Length - 1)
                    {
                        lastIndex = elementIndex + index + 1;
                    }
                }
            }
            
            index++;
        }
    
        return Convert.ToInt32(file[lineIndex][firstIndex..lastIndex]);
    }

    private Tuple<int,int> CheckRow(bool firstElement, bool lastElement, int lineIndex, int elementIndex, IReadOnlyList<string> file)
    {
        var count = 0;
        var result = 1;
        if (!firstElement)
        {
            if (_validCharacters.Contains(file[lineIndex][elementIndex - 1]) && !_validCharacters.Contains(file[lineIndex][elementIndex]))
            {
                count++;
                result *= FindWholePartNumber(lineIndex, elementIndex - 1, file);
            }
        }

        if (!lastElement)
        {
            if (_validCharacters.Contains(file[lineIndex][elementIndex + 1]) && !_validCharacters.Contains(file[lineIndex][elementIndex]))
            {
                count++;
                result *= FindWholePartNumber(lineIndex, elementIndex + 1, file);
            }
        }

        if (count != 0) return new Tuple<int, int>(count, result);
        if (!_validCharacters.Contains(file[lineIndex][elementIndex])) return new Tuple<int, int>(count, result);
        count++;
        result *= FindWholePartNumber(lineIndex, elementIndex, file);

        return new Tuple<int, int>(count, result);
    }
}