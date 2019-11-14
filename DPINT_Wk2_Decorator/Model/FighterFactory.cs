using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPINT_Wk2_Decorator.Model.Decorators;

namespace DPINT_Wk2_Decorator.Model
{
    public class FighterFactory
    {
        public Dictionary<string, string> FighterOptions { get; private set; }

        public const string DOUBLE_HANDED = "Double handed";
        public const string MINION = "Minion";
        public const string POISON = "Poison";
        public const string SHIELD = "Shield";
        public const string SHOTGUN = "Shotgun";
        public const string STRENGTHEN = "Strengthen";

        public FighterFactory()
        {
            FighterOptions = new Dictionary<string, string>
            {
                [DOUBLE_HANDED] = "A double handed sword for double attack and double defense.",
                [MINION] = "A little minion, adding attack and taking damage before the fighter does.",
                [POISON] = "A poison for 5 time attacks.",
                [SHIELD] = "Taking all your damase for 3 defenses.",
                [SHOTGUN] = "Adding attack, needs reloading every 2 times.",
                [STRENGTHEN] = "Increasing attack by 10%, increasing defense by 10%."
            };
        }

        public IFighter CreateFighter(int lives, int attack, int defense, IEnumerable<string> options)
        {
            IFighter fighter = new Fighter(lives, attack, defense);

            foreach (var option in options)
            {
                switch (option)
                {
                    case DOUBLE_HANDED:
                        fighter = new DoubleHandedFighterDecorator(fighter);
                        break;
                    case MINION:
                        fighter = new MinionFighterDecorator(fighter);
                        break;
                    case POISON:
                        fighter = new PoisonFighterDecorator(fighter);
                        break;
                    case SHIELD:
                        fighter = new ShieldFighterDecorator(fighter);
                        break;
                    case SHOTGUN:
                        fighter = new ShotgunFighterDecorator(fighter);
                        break;
                    case STRENGTHEN:
                        fighter = new StrengtherFighterDecorator(fighter);
                        break;
                }
            }

            return fighter;
        }
    }
}
