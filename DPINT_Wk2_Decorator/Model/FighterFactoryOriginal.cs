using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    public class FighterFactoryOriginal
    {
        public Dictionary<string, string> FighterOptions { get; private set; }

        public const string DOUBLE_HANDED = "Double handed";
        public const string MINION = "Minion";
        public const string POISON = "Poison";
        public const string SHIELD = "Shield";
        public const string SHOTGUN = "Shotgun";
        public const string STRENGTHEN = "Strengthen";

        public FighterFactoryOriginal()
        {
            FighterOptions = new Dictionary<string, string>
            {
                [DOUBLE_HANDED] = "A double handed sword for double attack and double defense.",
                [MINION] = "A little minion, adding attack and taking damage before the fighter does.",
                [POISON] = "A poison for 5 time attacks.",
                [SHIELD] = "Taking all your damase for 3 defenses.",
                [SHOTGUN] = "Adding attack, needs reloading every 2 times."
            };

            // TODO: Implement strengthen on fighter
            //FighterOptions[STRENGTHEN] = "Increasing attack by 10%, increasing defense by 10%.";
        }

        public IFighter CreateFighter(int lives, int attack, int defense, IEnumerable<string> options)
        {
            Fighter fighter = new Fighter(lives, attack, defense);

            foreach (var option in options)
            {
                //switch (option)
                //{
                //    case DOUBLE_HANDED:
                //        fighter.DoubleHanded = true;
                //        break;
                //    case MINION:
                //        fighter.MinionLives = fighter.Lives / 2;
                //        fighter.MinionAttackValue = fighter.AttackValue / 2;
                //        break;
                //    case POISON:
                //        fighter.PoisonStrength = 10;
                //        break;
                //    case SHIELD:
                //        fighter.ShieldDefends = 3;
                //        break;
                //    case SHOTGUN:
                //        fighter.UseShotgun = true;
                //        break;
                //}
            }

            return fighter;
        }
    }
}
