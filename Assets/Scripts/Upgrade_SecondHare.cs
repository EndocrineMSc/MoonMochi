using MoonMochi.Mechanics.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonMochi.Mechanics.Upgrades
{
    internal class Upgrade_SecondHare : Upgrade
    {
        private GameObject _secondHare;
        private readonly int _cost = 20;
        private const string SECOND_HARE_TAG = "Hare2";

        private void Start()
        {
            _secondHare = GameObject.FindGameObjectWithTag(SECOND_HARE_TAG);
            _secondHare.SetActive(false);
        }

        protected override void SetCost()
        {
            Cost = _cost;
        }

        public override void UpgradeEffect()
        {
            base.UpgradeEffect();
            _secondHare.SetActive(true);
            UpgradeEvents.Instance.SecondHare_Bought?.Invoke();
            GetComponent<UpgradeButtonIOHandler>().UpgradeIsBought = true;
        }
    }
}
