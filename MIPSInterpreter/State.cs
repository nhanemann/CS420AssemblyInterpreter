using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPSInterpreter
{
    class State
    {
        /// <summary>
        /// State class. Used similarly to a struct,
        /// but with a more powerful constructor and
        /// a next function.
        /// </summary>
        public RegList registers;
        private Instruction instr;
        public string instrString;
        public string eMessage = "";
        public int line = 0;

        public State(string arg, RegList reg, int l)
        {
            instrString = arg;
            registers = reg;
            line = l;
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
