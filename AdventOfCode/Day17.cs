namespace AdventOfCode;

public class Day17 : BaseDay
{
    private readonly string[] _input;
    private int RegisterA = 0;
    private int RegisterB = 0;
    private int RegisterC = 0;
    private int regA = 0;
    private int regB = 0;
    private int regC = 0;
    private readonly List<(int operand, int value)> Operations = new List<(int operand, int value)>();
    private string testString = "";
    public Day17()
    {
        _input = File.ReadAllLines(InputFilePath);
        foreach (var line in _input)
        {
            if (line.Contains("Register A: "))
            {
                var splits = line.Split("Register A: ");
                RegisterA = int.Parse(splits[1]);
                regA = int.Parse(splits[1]);
            }
            else if (line.Contains("Register B: "))
            {
                var splits = line.Split("Register B: ");
                RegisterB = int.Parse(splits[1]);
                regB = int.Parse(splits[1]);
            }
            else if (line.Contains("Register C: "))
            {
                var splits = line.Split("Register C: ");
                RegisterC = int.Parse(splits[1]);
                regC = int.Parse(splits[1]);
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {
                var splits = line.Split("Program: ");
                testString = splits[1];
                var nums = splits[1].Split(',');
                for (var i = 1; i < nums.Length; i += 2) {
                    Operations.Add((int.Parse(nums[i - 1]), int.Parse(nums[i])));
                }
            }
        }
    }

    private string ProcessInput1()
    {
        var outList = new List<int>();
        for(var i = 0; i < Operations.Count; i++)
        {
            var op = Operations[i];
            switch (op.operand)
            {
                case 0:
                    if(op.value < 4)
                    {
                        RegisterA = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, op.value)));
                    }
                    else if (op.value == 4)
                    {
                        RegisterA = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterA)));
                    }
                    else if (op.value == 5)
                    {
                        RegisterA = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterB)));
                    }
                    else if (op.value == 6)
                    {
                        RegisterA = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterC)));
                    }
                    break;
                case 1:
                    RegisterB = RegisterB ^ op.value;
                    break;
                case 2:
                    if (op.value < 4)
                    {
                        RegisterB = op.value % 8;
                    }
                    else if (op.value == 4)
                    {
                        RegisterB = RegisterA % 8;
                    }
                    else if (op.value == 5)
                    {
                        RegisterB = RegisterB % 8;
                    }
                    else if (op.value == 6)
                    {
                        RegisterB = RegisterC % 8;
                    }
                    break;
                case 3:
                    if(RegisterA != 0)
                    {
                        i = op.value-1;
                    }
                    break;
                case 4:
                    RegisterB = RegisterB ^ RegisterC;
                    break;
                case 5:
                    if (op.value < 4)
                    {
                        outList.Add(op.value % 8);
                    }
                    else if (op.value == 4)
                    {
                        outList.Add(RegisterA % 8);
                    }
                    else if (op.value == 5)
                    {
                        outList.Add(RegisterB % 8);
                    }
                    else if (op.value == 6)
                    {
                        outList.Add(RegisterC % 8);
                    }
                    break;
                case 6:
                    if (op.value < 4)
                    {
                        RegisterB = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, op.value)));
                    }
                    else if (op.value == 4)
                    {
                        RegisterB = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterA)));
                    }
                    else if (op.value == 5)
                    {
                        RegisterB = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterB)));
                    }
                    else if (op.value == 6)
                    {
                        RegisterB = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterC)));
                    }
                    break;
                case 7:
                    if (op.value < 4)
                    {
                        RegisterC = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, op.value)));
                    }
                    else if (op.value == 4)
                    {
                        RegisterC = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterA)));
                    }
                    else if (op.value == 5)
                    {
                        RegisterC = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterB)));
                    }
                    else if (op.value == 6)
                    {
                        RegisterC = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterC)));
                    }
                    break;
            }
        }
        return $"{string.Join(",", outList)}";
    }

    private string ProcessInput2()
    {
        long sum = 0;
        RegisterA = regA;
        RegisterB = regB;
        RegisterC = regC;
        var matchOutput = false;
        while (!matchOutput)
        {
            var outList = new List<int>();
            for (var i = 0; i < Operations.Count; i++)
            {
                var exceed = false;
                var op = Operations[i];
                switch (op.operand)
                {
                    case 0:
                        if (op.value < 4)
                        {
                            RegisterA = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, op.value)));
                        }
                        else if (op.value == 4)
                        {
                            RegisterA = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterA)));
                        }
                        else if (op.value == 5)
                        {
                            RegisterA = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterB)));
                        }
                        else if (op.value == 6)
                        {
                            RegisterA = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterC)));
                        }
                        break;
                    case 1:
                        RegisterB = RegisterB ^ op.value;
                        break;
                    case 2:
                        if (op.value < 4)
                        {
                            RegisterB = op.value % 8;
                        }
                        else if (op.value == 4)
                        {
                            RegisterB = RegisterA % 8;
                        }
                        else if (op.value == 5)
                        {
                            RegisterB = RegisterB % 8;
                        }
                        else if (op.value == 6)
                        {
                            RegisterB = RegisterC % 8;
                        }
                        break;
                    case 3:
                        if (RegisterA != 0)
                        {
                            i = op.value - 1;
                        }
                        break;
                    case 4:
                        RegisterB = RegisterB ^ RegisterC;
                        break;
                    case 5:
                        if (outList.Count <= Operations.Count)
                        {
                            if (op.value < 4)
                            {
                                outList.Add(op.value % 8);
                            }
                            else if (op.value == 4)
                            {
                                outList.Add(RegisterA % 8);
                            }
                            else if (op.value == 5)
                            {
                                outList.Add(RegisterB % 8);
                            }
                            else if (op.value == 6)
                            {
                                outList.Add(RegisterC % 8);
                            }
                        }
                        else 
                        { 
                            exceed = true; 
                        }
                        break;
                    case 6:
                        if (op.value < 4)
                        {
                            RegisterB = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, op.value)));
                        }
                        else if (op.value == 4)
                        {
                            RegisterB = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterA)));
                        }
                        else if (op.value == 5)
                        {
                            RegisterB = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterB)));
                        }
                        else if (op.value == 6)
                        {
                            RegisterB = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterC)));
                        }
                        break;
                    case 7:
                        if (op.value < 4)
                        {
                            RegisterC = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, op.value)));
                        }
                        else if (op.value == 4)
                        {
                            RegisterC = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterA)));
                        }
                        else if (op.value == 5)
                        {
                            RegisterC = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterB)));
                        }
                        else if (op.value == 6)
                        {
                            RegisterC = Convert.ToInt32(Math.Floor(RegisterA / Math.Pow(2, RegisterC)));
                        }
                        break;
                }
                if (exceed) break;
            }

            if (string.Equals(string.Join(",", outList), testString))
                matchOutput = true;
            else
            {
                regA++;
                RegisterA = regA;
                RegisterB = regB;
                RegisterC = regC;
            }
        }
        return $"{regA}";
    }
    public override ValueTask<string> Solve_1() => new(ProcessInput1());

    public override ValueTask<string> Solve_2() => new(ProcessInput2());

    public class Path
    {
        public char path { get; set; }
        public int visited { get; set; }
    }
}
