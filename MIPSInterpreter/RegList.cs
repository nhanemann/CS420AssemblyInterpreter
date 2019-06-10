using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPSInterpreter
{
    class RegList : Dictionary<string , int>
    {
        /// <summary>
        /// RegList is an inherited dictionary with
        /// 2 extra constructors and an extra data
        /// field, plus a function to validate that
        /// registers are being used properly.
        /// </summary>
        public Tuple<int, string> jumpLocation = new Tuple<int, string>(-1, "");

        public RegList(int k)
        {
            Add("$0", 0);
            for (int i = 1; i < 32; i++)
            {
                Add("$" + i.ToString(), k);
            }
        }

        public bool ValidRegisterCheck(string[] values)
        {
            int count = 0;
            foreach (string r in values)
            {
                if (r.Equals("$0") && count == 0) return false;
                if (!ContainsKey(r)) return false;
                count++;
            }
            return true;
        }

        public RegList(RegList r) : base(r)
        {
            jumpLocation = new Tuple<int, string>(r.jumpLocation.Item1,r.jumpLocation.Item2);
        }
    }
}
