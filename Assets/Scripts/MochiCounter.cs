using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MoonMochi.Mechanics.UI
{
    internal class MochiCounter : MonoBehaviour
    {
        #region Fields and Properties

        private TextMeshProUGUI _mochiCounter;

        internal int AmountMochi { get; private set; } = 0;

        #endregion

        #region Functions

        internal void AddMochi(int amount = 1)
        {
            AmountMochi += amount;
        }

        internal void SpendMochi(int cost)
        {
            if (AmountMochi >= cost)
            {
                AmountMochi -= cost;
            }
            else
            {
                Debug.Log("The program is not supposed to come here - SpendMochi; MochiCounter;");
            }
        }

        void Start()
        {
            _mochiCounter = GetComponentInChildren<TextMeshProUGUI>();
        }

        void Update()
        {
            _mochiCounter.text = AmountMochi.ToString();
        }

        #endregion
    }
}
