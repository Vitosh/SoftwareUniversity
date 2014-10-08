﻿namespace TheSlum.Characters
{
    using System.Collections.Generic;
    using System.Linq;
    using TheSlum;
    using TheSlum.Interfaces;
    using TheSlum.Items;
    public class Warrior : Character, IAttack
    {
        public Warrior(string id, int x, int y, int healthPoints, int defensePoints, int attackPoitns, Team team, int range)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {

        }
        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var target = targetsList.FirstOrDefault(ch => (ch.Team != this.Team && ch.IsAlive));
            return target;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            RemoveItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            RemoveItemEffects(item);
        }

        protected override void ApplyItemEffects(Item item)
        {
            this.AttackPoints += item.AttackEffect;
            base.ApplyItemEffects(item);
        }

        protected override void RemoveItemEffects(Item item)
        {
            this.AttackPoints -= item.AttackEffect;
            base.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            string baseString = base.ToString();
            return baseString + string.Format(", Attack: {0}", this.AttackPoints);
        }
    }
}
