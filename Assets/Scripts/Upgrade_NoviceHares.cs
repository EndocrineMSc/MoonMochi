using MoonMochi.Mechanics.Events;
using MoonMochi.Mechanics.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonMochi.Mechanics.Upgrades
{
    internal class Upgrade_NoviceHares : Upgrade
    {
        private readonly int _cost = 50;

        public override void UpgradeEffect()
        {
            UpgradeEvents.Instance.NoviceHares_Bought?.Invoke();
            GetComponent<UpgradeButtonIOHandler>().UpgradeIsBought = true;
        }

        protected override void SetCost()
        {
            Cost = _cost;
        }
    }
}
