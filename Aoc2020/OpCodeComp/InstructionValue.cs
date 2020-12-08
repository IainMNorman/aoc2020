namespace Aoc2020.OpCodeComp
{
    public class InstructionValue
    {
        public InstructionValue(Instruction instruction, int value, int runCount)
        {
            this.Instruction = instruction;
            this.Value = value;
            this.RunCount = 0;
        }

        public Instruction Instruction { get; set; }

        public int Value { get; set; }

        public int RunCount { get; set; }
    }
}
