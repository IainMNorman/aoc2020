namespace Aoc2020.OpCodeComp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OpCodeComp
    {
        private int instructionRegister;

        public OpCodeComp(string[] input)
        {
            this.Init();
            this.LoadProgram(input);
        }

        public bool End { get; set; }

        public bool Looped { get; private set; }

        public List<InstructionValue> Memory { get; set; }

        public int AccRegister { get; set; }

        public void LoadProgram(string[] input)
        {
            foreach (var line in input)
            {
                var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (Enum.TryParse(parts[0], true, out Instruction instruction))
                {
                    if (int.TryParse(parts[1], out int value))
                    {
                        this.Memory.Add(new InstructionValue(instruction, value, 0));
                    }
                    else
                    {
                        throw new InvalidCastException($"Could not convert {value} to int.");
                    }
                }
                else
                {
                    throw new InvalidCastException($"Could not convert {instruction} to Instruction enum.");
                }
            }
        }

        public void RunProgram()
        {
            this.instructionRegister = 0;
            this.AccRegister = 0;
            this.Looped = false;
            this.Memory.ForEach(x => x.RunCount = 0);

            while (true)
            {
                if (this.instructionRegister >= this.Memory.Count())
                {
                    this.End = true;
                    break;
                }

                var iv = this.Memory[this.instructionRegister];
                iv.RunCount++;

                if (iv.RunCount > 1)
                {
                    this.Looped = true;
                    break;
                }

                switch (iv.Instruction)
                {
                    case Instruction.Nop:
                        this.instructionRegister++;
                        break;
                    case Instruction.Jmp:
                        this.instructionRegister += iv.Value;
                        break;
                    case Instruction.Acc:
                        this.AccRegister += iv.Value;
                        this.instructionRegister++;
                        break;
                    default:
                        break;
                }
            }
        }

        private void Init()
        {
            this.Memory = new List<InstructionValue>();
            this.instructionRegister = 0;
        }
    }
}
