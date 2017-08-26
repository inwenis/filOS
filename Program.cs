using System;
using System.Collections.Generic;

namespace filOs
{
    class Program
    {
        static void Main(string[] args)
        {
            var sampleProgramInstructions = new []
            {
                "movi r1, $1",
                "printr r1"
            };

            var idleProcessInstructions = new []
            {
                "movei r1, $20",
                "printr",
                "movei r1, $-11", // not correct any more
                "jmp"
            };

            //var bytes = Compiler.Compile(instructions);

            var memory = new Memory();
            var cpu = new CPU(); //i think CPU should have access to memory, maybe not now but in the future
            var os = new OS(cpu, memory);
            os.AddProgram(sampleProgramInstructions);
            os.Run();
        }
    }
}

public class OS
{
    private CPU _cpu;
    private Memory _memory;
    private int _processCounter = 0;
    private List<Process> _processes;

    public OS(CPU cpu, Memory memory)
    {
        _cpu = cpu;
        _memory = memory;
        _processes = new List<Process>();
    }

    public void AddProgram(string[] instructions)
    {
        var processId = GetProcessId();
        var process = new Process(processId, instructions, _cpu);
        _processes.Add(process);
        //copy instruction to memory
        //instruction pointer (relative, since process is running in "user mode", cpu will be aware of the currently running process)
        //memory mapping
        //save process in process list/etc
    }

    public void Run()
    {
        while(true)
        {
            try
            {
                _processes[0].DoInstruction();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }
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
    }
}