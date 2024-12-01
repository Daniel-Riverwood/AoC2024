using Utilities;
namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly List<string> _input;
    private List<int> firstpositions = new List<int>();
    private List<int> lastpositions = new List<int>();
    public Day01()
    {
        _input = File.ReadAllText(InputFilePath).SplitByNewline();
    }

    private string ProcessInput1(List<string> input)
    {
        firstpositions = new List<int>();
        lastpositions = new List<int>();
        int sum = 0;
        foreach(var line in input)
        {
            var segment = line.Split(' ');
            firstpositions.Add(Convert.ToInt32(segment[0].Trim()));
            lastpositions.Add(Convert.ToInt32(segment[3].Trim()));
        }

        firstpositions.Sort();
        lastpositions.Sort();

        for(var i = 0; i < firstpositions.Count(); i++)
        {
            sum += Math.Abs(firstpositions[i] - lastpositions[i]);
        }
        
        return $"{sum}";
    }

    private string ProcessInput2(List<string> input)
    {
        firstpositions = new List<int>();
        lastpositions = new List<int>();
        int sum = 0;
        foreach (var line in input)
        {
            var segment = line.Split(' ');
            firstpositions.Add(Convert.ToInt32(segment[0].Trim()));
            lastpositions.Add(Convert.ToInt32(segment[3].Trim()));
        }


        for (var i = 0; i < firstpositions.Count(); i++)
        {
            var appearances = lastpositions.Where(q => q == firstpositions[i]).Count();
            sum += firstpositions[i] * appearances;
        }

        return $"{sum}";
    }


    public override ValueTask<string> Solve_1() => new(ProcessInput1(_input));

    public override ValueTask<string> Solve_2() => new(ProcessInput2(_input));
}
