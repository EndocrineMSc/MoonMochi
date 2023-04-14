using UnityEngine;

namespace MoonMochi.Mechanics.Upgrades
{
    [RequireComponent(typeof(UpgradeButtonIOHandler))]
    internal abstract class Upgrade : MonoBehaviour
    {
        #region Fields and Properties

        internal int Cost { get; set; }

        #endregion

        #region Functions

        protected virtual void Awake()
        {
            SetCost();
        }

        public abstract void UpgradeEffect();

        protected abstract void SetCost();

        #endregion
    }
}