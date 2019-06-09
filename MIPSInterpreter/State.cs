using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPSInterpreter
{
    class State
    {
        public RegList registers;
        private Instruction instr;
        public string instrString;
        public string eMessage = "";

        public State(string arg, RegList reg)
        {
            instrString = arg;
            registers = reg;
            instr = new Instruction(instrString, reg);
        }

        public RegList NextState()
        {
            RegList ret = instr.Execute();
            if (ret == null) eMessage = instr.eMessage;
            return ret;
        }
    }
}
