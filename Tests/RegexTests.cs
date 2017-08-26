using System.Text.RegularExpressions;
using System;
using static System.Console;

public class RegexTests
{
    public static void Main()
    {
        var r = @"(\w+) ([r0-9]*)[,]?[ ]?([r0-9]*)";
        Test("movi r1, $1", r);
        Test("movi r1", r);
    }

    public static void Test(string input, string regex)
    {
        WriteLine("--------------------------");
        WriteLine($"{input}     {regex}");
        var match = Regex.Match(input, regex);
        WriteLine(match.Groups.Count);
        WriteLine(match.Success);
        WriteLine(match.Groups[0]+"_");
        WriteLine(match.Groups[1]+"_");
        WriteLine(match.Groups[2]+"_");
        WriteLine(match.Groups[3]+"_");
    }
}