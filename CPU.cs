using System;
using System.Text.RegularExpressions;

public class CPU
{
    public int Register1;
    public int Register2;
    public int InstructionPointer = 0;

    public void Execute(string instruction)
    {
        Match match;
        if(instruction.Contains(","))
        {
            match = Regex.Match(instruction, @"(\w+) (.*), (.*)");
        }
        else
        {
            match = Regex.Match(instruction, @"(\w+) (.*)");
        }
        if(!match.Success)
        {
            throw new Exception("something went wrong!");
        }
        System.Console.WriteLine("here");
        if(match.Groups[1].Value == "movi")
        {
            System.Console.WriteLine("\there");
            System.Console.WriteLine(match.Groups[2].Value);
            if(match.Groups[2].Value == "r1")
            {
                System.Console.WriteLine("aaa");
                var from = 1;
                if(match.Groups[3].Value[0] == '$')
                {
                    var value = int.Parse(match.Groups[2].Value.Substring(1));
                    System.Console.WriteLine(value);
                    Register1 = value;
                }
            }
        }
        if(match.Groups[1].Value == "printr")
        {
            if(match.Groups[2].Value == "r1")
            {
                Console.WriteLine(Register1);
            }
        }
    }

    //TODO: the input should be int value
    public void execute(byte[] cells)
    {
        var instruction = cells[InstructionPointer];
        switch (instruction)
        {
            case 0:
                return;
            case 1:
                Register1 = cells[InstructionPointer + 1];
                InstructionPointer += 2;
                break;
            case 2:
                Register2 = cells[InstructionPointer + 1];
                InstructionPointer += 2;
                break;
            case 3:
                Register1 += Register2;
                InstructionPointer += 1;
                break;
            case 4:
                Console.WriteLine(Register1);
                InstructionPointer += 1;
                break;
            case 5:
                //var address = mmu.GetAdress(Register2);
                //Register1 = cells[address];
                Register1 = cells[120];
                InstructionPointer += 3;
                break;
        }
    }
}