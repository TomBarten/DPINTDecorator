using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model.Decorators
{
    public class ShotgunFighterDecorator : BaseFighterDecorator
    {
        public int ShotgunRoundsFired { get; set; }

        public ShotgunFighterDecorator(IFighter fighter) : base(fighter)
        {

        }

        public override Attack Attack()
        {
            var attack = base.Attack();

            if (ShotgunRoundsFired < 2)
            {
                attack.Messages.Add("Shotgun: 20");
                attack.Value += 20;
                ShotgunRoundsFired++;
            }
            else
            {
                attack.Messages.Add("Shotgun reloading, no extra damage.");
                ShotgunRoundsFired = 0;
            }

            return attack;
        }
    }
}
