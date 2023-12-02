using Commen.Interface;

namespace Day1;

public class Part1 : Solve
{
    public int Solve()
    {
        var file = File.ReadAllLines("../../../input.txt");
        var result = 0;

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
        }

        return result;
    }
}