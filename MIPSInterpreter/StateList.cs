using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPSInterpreter
{
    class StateList
    {
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
            sList.Add(new State(program[0], new RegList(0)));
            CurrentState = sList[0];
        }

        public void Next()
        {
            if (CurrentState.registers == null || (eMessage != "" && index == ProgramStrings.Length-1))
            {
                return;
            }
            if (index == sList.Count - 1)
            {
                RegList newState = CurrentState.NextState();
                if (newState == null)
                {
                    eMessage = CurrentState.eMessage;
                    return;
                }
                int nextInstr = CalculateJump(newState.jumpLocation);
                if (nextInstr >= ProgramStrings.Length)
                {
                    eMessage = "Jump out of bounds";
                    return;
                }
                State s = new State(ProgramStrings[nextInstr], newState);
                sList.Add(s);
                CurrentState = sList[++index];
                return;
            }
            if (index < sList.Count)
            {
                CurrentState = sList[++index];
                return;
            }
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
    }
}
