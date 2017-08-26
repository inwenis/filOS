using System;
using System.Collections.Generic;

public class OS
{
    private CPU _cpu;
    private int _processCounter = 0;
    private List<Process> _processes;

    public OS(CPU cpu)
    {
        _cpu = cpu;
        _processes = new List<Process>();
    }

    public void AddProgram(string[] instructions)
    {
        var processId = GetProcessId();
        var process = new Process(processId, instructions, _cpu);
        _processes.Add(process);
    }

    public void Run()
    {
        var theOnlyProcessThatCanCurrentlyRun = _processes[0];
        while(theOnlyProcessThatCanCurrentlyRun.AnyInstructionsLeft())
        {
            _processes[0].DoInstruction();
        }
        Console.WriteLine("OS is out of main loop, the program will exit now");
    }

    public int GetProcessId()
    {
        return ++_processCounter;
    }

    class Process
    {
        private int _id;
        private string[] _instructions;
        private int _instructionPointer = 0;
        private CPU _cpu;

        public Process(int id, string[] instructions, CPU cpu)
        {
            _id = id;
            _instructions = instructions;
            _instructionPointer = 0;
            _cpu = cpu;
        }

        public void DoInstruction()
        {
            _cpu.Execute(_instructions[_instructionPointer]);
            ++_instructionPointer;
        }

        public bool AnyInstructionsLeft()
        {
            return _instructions.Length - 1 >= _instructionPointer;
        }
    }
}
