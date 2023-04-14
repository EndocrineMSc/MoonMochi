using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MoonMochi.Mechanics.Events
{
    internal class UpgradeEvents : MonoBehaviour
    {
        internal static UpgradeEvents Instance { get; private set; }

        public UnityEvent SecondHare_Bought;
        public UnityEvent NoviceHares_Bought;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
