using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.Interfaces
{
    public abstract class Solver
    {
        public OperatorGenerator OperatorGenerator { get; set; }

        public Solver(OperatorGenerator operatorGenerator)
        {
            OperatorGenerator = operatorGenerator;
        }

        public abstract void Solve();
    }
}
