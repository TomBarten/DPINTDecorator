using System;

namespace DPINT_Wk2_Decorator.Model.Decorators
{
    public abstract class BaseFighterDecorator : IFighter
    {
        protected IFighter Fighter;

        public int Lives 
        { 
            get => Fighter.Lives; 
            set => Fighter.Lives = value;
        }
        public int AttackValue 
        { 
            get => Fighter.AttackValue; 
            set => Fighter.AttackValue = value;
        }
        public int DefenseValue 
        { 
            get => Fighter.DefenseValue; 
            set => Fighter.DefenseValue = value;
        }

        public BaseFighterDecorator(IFighter fighter)
        {
            Fighter = fighter;
        }

        public virtual Attack Attack() => Fighter.Attack();

        public virtual void Defend(Attack attack) => Fighter.Defend(attack);
    }
}
