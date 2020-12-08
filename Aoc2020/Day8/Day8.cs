namespace Aoc2020.Day8
{
    using System;
    using System.Linq;
    using Aoc2020.OpCodeComp;

    public class Day8 : IDay
    {
        public string ExecutePart1(string input)
        {
            var comp = new OpCodeComp(input.ToLines());
            comp.RunProgram();
            return comp.AccRegister.ToString();
        }

        public string ExecutePart2(string input)
        {
            var comp = new OpCodeComp(input.ToLines());

            var instuctionsToChange = comp.Memory.Where(x => x.Instruction == Instruction.Jmp || x.Instruction == Instruction.Nop);

            foreach (var item in instuctionsToChange)
            {
                item.Instruction = item.Instruction == Instruction.Nop ? Instruction.Jmp : Instruction.Nop;
                comp.RunProgram();
                if (comp.End)
                {
                    break;
                }

                item.Instruction = item.Instruction == Instruction.Nop ? Instruction.Jmp : Instruction.Nop;
            }

            return comp.AccRegister.ToString();
        }
    }
}
