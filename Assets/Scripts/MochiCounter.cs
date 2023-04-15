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

        internal int AmountMochi { get; set; } = 0;

        private const string MOCHI_SPAWN_TAG = "MochiSpawn";
        [SerializeField] private GameObject _mochiPrefab;
        private GameObject _mochiSpawn;

        #endregion

        #region Functions

        private void Start()
        {
            _mochiSpawn = GameObject.FindGameObjectWithTag(MOCHI_SPAWN_TAG);
            _mochiCounter = GetComponentInChildren<TextMeshProUGUI>();
        }

        internal void AddMochi(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(_mochiPrefab, _mochiSpawn.transform.position, Quaternion.identity);
            }
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

        void Update()
        {
            _mochiCounter.text = AmountMochi.ToString();
        }

        #endregion
    }
}
