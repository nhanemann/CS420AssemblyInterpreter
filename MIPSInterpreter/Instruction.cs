using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace MIPSInterpreter
{
    class Instruction
    {
        public string eMessage = "";
        private RegList registers = new RegList(0);
        private string[] instructionInfo;

        private Dictionary<string, string> ValidAssemblyFunctions;

        public Instruction(string instr, RegList reg)
        {
            BuildAssemblyLookup();
            registers = new RegList(reg);
            registers.jumpLocation = new Tuple<int, string>(-1, "");
            instructionInfo = parseInstrct(instr);
        }

        private string[] parseInstrct(string str)
        {
            str = str.Split(':').Last().Trim();
            return Regex.Split(str, @",*\s+");
        }

        public RegList Execute()
        {
            if (ValidAssemblyFunctions.ContainsKey(instructionInfo[0].ToLower()))
            {
                MethodInfo mi = this.GetType().GetMethod(ValidAssemblyFunctions[instructionInfo[0].ToLower()], BindingFlags.NonPublic | BindingFlags.Instance);
                if (mi.Invoke(this, null) != null)
                {
                    return registers;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                eMessage = "No matching assembly instruction.";
                return null;
            }
        }

        private bool ValidateReg(int argCount, int immediate)
        {
            if (instructionInfo.Length != argCount)
            {
                eMessage = "Improper number of arguments.";
                return false;
            }

            if (!registers.ValidRegisterCheck(instructionInfo.Take(instructionInfo.Count() - immediate).Skip(1).ToArray()))
            {
                eMessage = "Invalid Registers.";
                return false;
            }
            return true;
        }

        private int ValidateImmediate(string imm, bool isString = false)
        {
            if (!Int32.TryParse(imm, out int immediate))
            {
                if (!isString) eMessage = "Bad immediate.";
                return -1;
            }
            return immediate;
        }

        #region Assembly Instructions

        //All new assembly functions added to the lookup here
        private void BuildAssemblyLookup()
        {
            ValidAssemblyFunctions = new Dictionary<string, string>();
            ValidAssemblyFunctions.Add("add", "InstructionADD");
            ValidAssemblyFunctions.Add("addi", "InstructionADDI");
            ValidAssemblyFunctions.Add("and", "InstructionAND");
            ValidAssemblyFunctions.Add("beq", "InstructionBEQ");
            ValidAssemblyFunctions.Add("bne", "InstructionBNE");
            ValidAssemblyFunctions.Add("j", "InstructionJ");
            ValidAssemblyFunctions.Add("or", "InstructionOR");
            ValidAssemblyFunctions.Add("sll", "InstructionSLL");
            ValidAssemblyFunctions.Add("slt", "InstructionSLT");
            ValidAssemblyFunctions.Add("slti", "InstructionSLTI");
            ValidAssemblyFunctions.Add("sub", "InstructionSUB");
            ValidAssemblyFunctions.Add("xor", "InstructionXOR");
        }

        private RegList InstructionADD()
        {
            if (!ValidateReg(4, 0)) return null;
            registers[instructionInfo[1]] = registers[instructionInfo[2]] + registers[instructionInfo[3]];
            return registers;
        }

        private RegList InstructionADDI()
        {
            if (!ValidateReg(4, 1)) return null;
            int immediate = ValidateImmediate(instructionInfo[3]);
            if (immediate == -1 ) return null;
            registers[instructionInfo[1]] = registers[instructionInfo[2]] + immediate;
            return registers;
        }

        private RegList InstructionAND()
        {
            if (!ValidateReg(4, 0)) return null;
            registers[instructionInfo[1]] = registers[instructionInfo[2]] & registers[instructionInfo[3]];
            return registers;
        }

        private RegList InstructionBEQ()
        {
            if (!ValidateReg(4, 1)) return null;
            int immediate = ValidateImmediate(instructionInfo[3], true);
            if (registers[instructionInfo[1]] == registers[instructionInfo[2]])
            {
                Tuple<int, string> jl;
                if (immediate == -1) jl = new Tuple<int, string>(-1, instructionInfo[3]);
                else jl = new Tuple<int, string>(immediate, "");
                registers.jumpLocation = jl;
            }
            return registers;
        }

        private RegList InstructionBNE()
        {
            if (!ValidateReg(4, 1)) return null;
            int immediate = ValidateImmediate(instructionInfo[3], true);
            if (registers[instructionInfo[1]] != registers[instructionInfo[2]])
            {
                Tuple<int, string> jl;
                if (immediate == -1) jl = new Tuple<int, string>(-1, instructionInfo[3]);
                else jl = new Tuple<int, string>(immediate, "");
                registers.jumpLocation = jl;
            }
            return registers;
        }

        private RegList InstructionJ()
        {
            if (!ValidateReg(2, 1)) return null;
            int immediate = ValidateImmediate(instructionInfo[1], true);
            Tuple<int, string> jl;
            if (immediate == -1) jl = new Tuple<int, string>(-1, instructionInfo[1]);
            else jl = new Tuple<int, string>(immediate, "");
            registers.jumpLocation = jl;
            return registers;
        }

        private RegList InstructionOR()
        {
            if (!ValidateReg(4, 0)) return null;
            registers[instructionInfo[1]] = registers[instructionInfo[2]] | registers[instructionInfo[3]];
            return registers;
        }

        private RegList InstructionSLL()
        {
            if (!ValidateReg(4, 1)) return null;
            int immediate = ValidateImmediate(instructionInfo[3]);
            if (immediate == -1) return null;
            registers[instructionInfo[1]] = registers[instructionInfo[2]] << immediate;
            return registers;
        }

        private RegList InstructionSLT()
        {
            if (!ValidateReg(4, 0)) return null;
            bool retV = registers[instructionInfo[2]] < registers[instructionInfo[3]];
            if (retV) registers[instructionInfo[1]] = 1;
            else registers[instructionInfo[1]] = 0;
            return registers;
        }

        private RegList InstructionSLTI()
        {
            if (!ValidateReg(4, 1)) return null;
            int immediate = ValidateImmediate(instructionInfo[3]);
            if (immediate == -1) return null;
            bool retV = registers[instructionInfo[2]] < immediate;
            if (retV) registers[instructionInfo[1]] = 1;
            else registers[instructionInfo[1]] = 0;
            return registers;
        }

        private RegList InstructionSUB()
        {
            if (!ValidateReg(4, 0)) return null;
            int trap = registers[instructionInfo[2]] - registers[instructionInfo[3]];
            if (trap >= 0)
            {
                registers[instructionInfo[1]] = trap;
                return registers;
            }
            else
            {
                eMessage = "It's a Trap! Subtraction overflow.";
                return null;
            }
        }

        private RegList InstructionXOR()
        {
            if (!ValidateReg(4, 0)) return null;
            registers[instructionInfo[1]] = registers[instructionInfo[2]] ^ registers[instructionInfo[3]];
            return registers;
        }

        #endregion
    }
}
