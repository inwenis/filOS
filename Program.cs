using System;

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

            var cpu = new CPU(); 
            var os = new OS(cpu);
            os.AddProgram(sampleProgramInstructions);
            os.Run();
        }
    }
}
