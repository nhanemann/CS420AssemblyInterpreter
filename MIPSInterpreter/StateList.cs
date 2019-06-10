using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPSInterpreter
{
    class StateList
    {
        /// <summary>
        /// List of states. Contains navigation
        /// functions to run forwards and backwards
        /// through the program.
        /// </summary>
        private List<State> sList;
        private int index;
        public State CurrentState;
        private string[] ProgramStrings;
        private int line;
        public string eMessage = "";

        public StateList(string[] program)
        {
            ProgramStrings = program;
            index = 0;
            line = 0;
            sList = new List<State>();
            sList.Add(new State(program[0], new RegList(0), 0));
            CurrentState = sList[0];
        }

        public bool Next()
        {
            if (CurrentState.registers == null || (eMessage != "" && index == ProgramStrings.Length-1))
            {
                return false;
            }
            if (index < sList.Count - 1)
            {
                CurrentState = sList[++index];
                return true;
            }
            return BuildNext();
        }

        public bool BuildNext()
        {
            RegList newState = CurrentState.NextState();
            if (newState == null)
            {
                eMessage = CurrentState.eMessage;
                return false;
            }
            int nextInstr = CalculateJump(newState.jumpLocation);
            if (nextInstr >= ProgramStrings.Length)
            {
                eMessage = "Jump out of bounds";
                return false;
            }
            State s = new State(ProgramStrings[nextInstr], newState, line);
            sList.Add(s);
            CurrentState = sList[++index];
            return true;
        }

        public void Previous()
        {
            if (index == 0) return;
            CurrentState = sList[--index];
        }

        private int CalculateJump(Tuple<int, string> jl)
        {
            if (jl.Item1 == -1 && jl.Item2.Equals("")) return ++line;
            if (jl.Item1 != -1) return line = jl.Item1;
            for (int i = 0; i < ProgramStrings.Length; i++)
            {
                if (ProgramStrings[i].Contains(jl.Item2 + ':'))
                    return line = i;
            }
            eMessage = "Bad jump label";
            return ProgramStrings.Length;
        }

        public void RunAll()
        {
            while (Next()) ;
        }
    }
}
