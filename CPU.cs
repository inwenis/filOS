using System;
using System.Text.RegularExpressions;

public class CPU
{
    public int Register1;
    public int Register2;
    public int InstructionPointer = 0;

    //the code below is ugly and works currently only for instructions:
    // movi r1, $1
    // printr r1
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
        else if(match.Groups[1].Value == "movi")
        {
            if(match.Groups[2].Value == "r1")
            {
                if(match.Groups[3].Value[0] == '$')
                {
                    var value = int.Parse(match.Groups[2].Value.Substring(1));
                    Register1 = value;
                }
            }
        }
        else if(match.Groups[1].Value == "printr")
        {
            if(match.Groups[2].Value == "r1")
            {
                Console.WriteLine(Register1);
            }
        }
    }
}
