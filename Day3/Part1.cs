using Commen.Interface;

namespace Day3;

public class Part1 : Solve
{
    private List<char> _validCharacters = new()
    {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'
    };
    
    public int Solve()
    {
        var result = 0;
        var file = File.ReadAllLines("../../../input.txt");
        
        foreach (var line in file.Select((value, index) => new { value, index}))
        {
            var currentPart = "";
            var alreadyCheckedPart = false;
            foreach (var element in line.value.Select((elementValue, elementIndex) => new { elementValue, elementIndex}))
            {
                if (!int.TryParse(element.elementValue.ToString(), out _))
                {
                    if (alreadyCheckedPart)
                    {
                        alreadyCheckedPart = false;
                        if (currentPart.Length > 0)
                        {
                            result += Convert.ToInt32(currentPart);
                        }
                    }
                    
                    currentPart = "";
                    
                    continue;
                }
                
                currentPart += element.elementValue;
                
                if (!alreadyCheckedPart)
                {
                    var check = CheckSurroundings(line.index, element.elementIndex, file);
                    if (check)
                    {
                        alreadyCheckedPart = true;
                    }
                }
                
                if (element.elementIndex == line.value.Length - 1 && alreadyCheckedPart)
                {
                    if (currentPart.Length > 0)
                    {
                        result += Convert.ToInt32(currentPart);
                    }
                }
            }
        }

        return result;
    }

    private bool CheckSurroundings(int lineIndex, int elementIndex, IReadOnlyList<string> file)
    {
        var lastLine = lineIndex == file.Count - 1;
        var firstLine = lineIndex == 0;
        var firstElement = elementIndex == 0;
        var lastElement = elementIndex == file[lineIndex].Length - 1;

        if (!firstElement)
        {
            if(!_validCharacters.Contains(file[lineIndex][elementIndex - 1])) return true;
        }
        
        if (!lastElement)
        {
            if(!_validCharacters.Contains(file[lineIndex][elementIndex + 1])) return true;
        }
        
        if (!lastLine)
        {
            if(!_validCharacters.Contains(file[lineIndex + 1][elementIndex])) return true;
            if (!firstElement)
            {
                if(!_validCharacters.Contains(file[lineIndex + 1][elementIndex - 1])) return true;
            }

            if (!lastElement)
            {
                if(!_validCharacters.Contains(file[lineIndex + 1][elementIndex + 1])) return true;
            }
        }

        // check top and top diagonal
        if (!firstLine)
        {
            if(!_validCharacters.Contains(file[lineIndex - 1][elementIndex])) return true;
            if (!firstElement)
            {
                if(!_validCharacters.Contains(file[lineIndex - 1][elementIndex - 1])) return true;
            }

            if (!lastElement)
            {
                if(!_validCharacters.Contains(file[lineIndex - 1][elementIndex + 1])) return true;
            }
        }

        return false;
    }
}