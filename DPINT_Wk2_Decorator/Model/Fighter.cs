using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    public class Fighter : IFighter
    {
        public int Lives { get; set; }
        public int AttackValue { get; set; }
        public int DefenseValue { get; set; }

        //public bool DoubleHanded { get; set; }
        //public int MinionLives { get; set; }
        //public int MinionAttackValue { get; set; }
        //public int PoisonStrength { get; set; }
        //public int ShieldDefends { get; set; }
        //public bool UseShotgun { get; set; }
        //public int ShotgunRoundsFired { get; set; }

        public Fighter(int lives, int attack, int defense)
        {
            this.Lives = lives;
            this.AttackValue = attack;
            this.DefenseValue = defense;
        }

        public void Defend(Attack attack)
        {
            //if (ShieldDefends > 0)
            //{
            //    attack.Messages.Add("Shield protected, attack value = 0");
            //    attack.Value = 0;
            //    ShieldDefends--;
            //}
            //else
            //{
            //    if (DoubleHanded)
            //    {
            //        attack.Messages.Add("One hand defended the attack: -" + DefenseValue);
            //        attack.Value -= DefenseValue;
            //    }

            //    if (MinionLives > 0)
            //    {
            //        int tmpLives = MinionLives;
            //        MinionLives -= Math.Max(0, attack.Value);
            //        attack.Value -= Math.Max(0, tmpLives - MinionLives);
            //        attack.Messages.Add("Minion defended from the attack: -" + attack.Value);
            //    }

                int hit = Math.Max(0, attack.Value - DefenseValue);
                this.Lives -= hit;
                attack.Messages.Add(String.Format("Attacked: {0}, Defended: {1}, got hit: {2}", attack.Value, DefenseValue, hit));
            //}
        }

        public Attack Attack()
        {
            var attack = new Attack("Normal attack: " + this.AttackValue, this.AttackValue);

            //if (DoubleHanded)
            //{
            //    attack.Value += AttackValue;
            //    attack.Messages.Add("Doubled the original attack value: " + AttackValue);
            //}

            //if (MinionLives > 0)
            //{
            //    attack.Messages.Add("Minion helping the attack: " + MinionAttackValue);
            //    attack.Value += MinionAttackValue;
            //}

            //if (PoisonStrength > 0)
            //{
            //    attack.Messages.Add("Poison weakening, current value: " + PoisonStrength);
            //    attack.Value += PoisonStrength;
            //    PoisonStrength -= 2;
            //}
            //else
            //{
            //    attack.Messages.Add("Poison ran out.");
            //}

            //if (UseShotgun)
            //{
            //    if (ShotgunRoundsFired < 2)
            //    {
            //        attack.Messages.Add("Shotgun: 20");
            //        attack.Value += 20;
            //        ShotgunRoundsFired++;
            //    }
            //    else
            //    {
            //        attack.Messages.Add("Shotgun reloading, no extra damage.");
            //        ShotgunRoundsFired = 0;
            //    }
            //}

            return attack;
        }
    }
}
