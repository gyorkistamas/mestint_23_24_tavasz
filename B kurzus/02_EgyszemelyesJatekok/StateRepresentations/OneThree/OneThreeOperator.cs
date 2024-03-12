using _02_EgyszemelyesJatekok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EgyszemelyesJatekok.StateRepresentations.OneThree
{
    public class OneThreeOperator : Operator
    {
        public int XDirection { get; set; }
        public int YDirection { get; set; }

        public OneThreeOperator(int xDirection, int yDirection)
        {
            XDirection = xDirection;
            YDirection = yDirection;
        }

        public State Apply(State state)
        {
            if (state == null || !(state is OneThreeState)) throw new Exception("Not OneThreeState");

            OneThreeState newState = state.Clone() as OneThreeState;

            int newX = newState.X + (XDirection * OneThreeState.Table[newState.X, newState.Y]);
            int newY = newState.Y + (YDirection * OneThreeState.Table[newState.X, newState.Y]);

            newState.X = newX;
            newState.Y = newY;

            return newState;
        }

        public bool IsApplicable(State state)
        {
            if (state == null || !(state is OneThreeState)) return false;

            OneThreeState gameState = state as OneThreeState;

            int newX = gameState.X + (XDirection * OneThreeState.Table[gameState.X, gameState.Y]);
            int newY = gameState.Y + (YDirection * OneThreeState.Table[gameState.X, gameState.Y]);

            return newX >= 0 && newX <= 6 && newY >= 0 && newY <= 9;
        }
    }
}
