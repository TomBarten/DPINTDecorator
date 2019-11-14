using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model.Decorators
{
    public class StrengtherFighterDecorator : BaseFighterDecorator
    {
        public StrengtherFighterDecorator(IFighter fighter) : base(fighter)
        {
            fighter.AttackValue = (int)Math.Ceiling(AttackValue * 1.10);
            fighter.DefenseValue = (int)Math.Ceiling(DefenseValue * 1.10);
        }
    }
}
