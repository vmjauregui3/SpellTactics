using System;
using System.Collections.Generic;
using System.Text;

namespace SpellTactics
{
    public class StatModifier
    {
        public readonly float Value;
        public readonly StatModifierType Type;

        public readonly int Order;

        public StatModifier(float value, StatModifierType type, int order)
        {
            Value = value;
            Type = type;
            Order = order;
        }
    }
}
