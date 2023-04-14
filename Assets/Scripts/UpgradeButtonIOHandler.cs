using MoonMochi.Mechanics.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoonMochi.Mechanics.Upgrades;

internal class UpgradeButtonIOHandler : MonoBehaviour
{
    #region Fields and Properties

    private Button _upgradeButton;
    private int _upgradeCost;
    private MochiCounter _mochiCounter;
    private const string COUNTER_TAG = "Counter";
    internal bool UpgradeIsBought { get; set; }

    #endregion

    #region Functions

    void Start()
    {
        _upgradeButton = GetComponent<Button>();
        _upgradeCost = _upgradeButton.GetComponent<Upgrade>().Cost;
        _mochiCounter = GameObject.FindGameObjectWithTag(COUNTER_TAG).GetComponent<MochiCounter>();
    }

    void Update()
    {
        if (UpgradeIsBought || _mochiCounter.AmountMochi < _upgradeCost)
        {
            _upgradeButton.interactable = false;
        }
        else
        {
            _upgradeButton.interactable = true;
        }
    }

    #endregion
}
