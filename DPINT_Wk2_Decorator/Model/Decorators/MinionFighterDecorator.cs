using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model.Decorators
{
    public class MinionFighterDecorator : BaseFighterDecorator
    {
        public int MinionLives { get; set; }
        public int MinionAttackValue { get; set; }

        public MinionFighterDecorator(IFighter fighter) : base(fighter)
        {
            MinionLives = fighter.Lives / 2;
            MinionAttackValue = fighter.AttackValue / 2;
        }

        public override Attack Attack()
        {
            var attack = base.Attack();

            if (MinionLives > 0)
            {
                attack.Messages.Add("Minion helping the attack: " + MinionAttackValue);
                attack.Value += MinionAttackValue;
            }

            return attack;
        }

        public override void Defend(Attack attack)
        {
            if (MinionLives > 0)
            {
                int tmpLives = MinionLives;
                MinionLives -= Math.Max(0, attack.Value);
                attack.Value -= Math.Max(0, tmpLives - MinionLives);
                attack.Messages.Add("Minion defended from the attack: -" + attack.Value);
            }

            base.Defend(attack);
        }
    }
}
