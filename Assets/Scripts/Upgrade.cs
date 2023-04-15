using MoonMochi.Mechanics.UI;
using UnityEngine;

namespace MoonMochi.Mechanics.Upgrades
{
    [RequireComponent(typeof(UpgradeButtonIOHandler))]
    internal abstract class Upgrade : MonoBehaviour
    {
        #region Fields and Properties
        internal int Cost { get; set; }
        protected const string COUNTER_TAG = "Counter";

        #endregion

        #region Functions

        protected virtual void Awake()
        {
            SetCost();
        }

        public virtual void UpgradeEffect()
        {
            MochiCounter mochiCounter = GameObject.FindGameObjectWithTag(COUNTER_TAG).GetComponent<MochiCounter>();
            mochiCounter.SpendMochi(Cost);
        }

        protected abstract void SetCost();

        #endregion
    }
}