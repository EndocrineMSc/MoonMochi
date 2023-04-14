using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonMochi.Mechanics.UI;
using MoonMochi.Mechanics.Events;

namespace MoonMochi.Mechanics
{
    internal class ClickerManager : MonoBehaviour
    {
        #region Fields and Properties

        internal static ClickerManager Instance { get; private set; }

        private Animator _hareAnimator;
        private Animator _secondHareAnimator;
        private MochiCounter _mochiCounter;

        private const string COUNTER_TAG = "Counter";
        private const string HARE_TAG = "Hare";
        private const string SECOND_HARE_TAG = "Hare2";
        private const string HARE_HIT_ANIM = "Hit";

        internal int ClicksTillMochi { get; set; } = 4;
        private int _currentClicks = 0;

        internal int SecondsTillNextMochi { get; set; } = -1; //-1 is deactivated state -> auto-generation of mochi by upgrades
        private float _currentTime = 0;

        //Upgrade booleans
        internal bool SecondHareIsBought { get; private set; }
        internal bool NoviceHaresIsBought { get; private set; }

        #endregion

        #region Functions
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            _mochiCounter = GameObject.FindGameObjectWithTag(COUNTER_TAG).GetComponent<MochiCounter>();
            _hareAnimator = GameObject.FindGameObjectWithTag(HARE_TAG).GetComponent<Animator>();
            UpgradeEvents.Instance.SecondHare_Bought?.AddListener(OnSecondHareBought);
            UpgradeEvents.Instance.NoviceHares_Bought?.AddListener(OnNoviceHaresBought);
        }

        private void HandleMouseClick()
        {
            _currentClicks++;
            _hareAnimator.SetTrigger(HARE_HIT_ANIM);
            
            if(SecondHareIsBought )
            {
                _secondHareAnimator.SetTrigger(HARE_HIT_ANIM);
            }

            if (_currentClicks >= ClicksTillMochi)
            {
                _currentClicks = 0;
                _mochiCounter.AddMochi();
            }
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            Debug.Log(_currentTime);

            if (Input.GetMouseButtonDown(0))
            {
                HandleMouseClick();
            }

            if (SecondsTillNextMochi > 0 && _currentTime > SecondsTillNextMochi && !SecondHareIsBought)
            {
                _currentTime = 0;
                _mochiCounter.AddMochi();
            }
            else if (SecondsTillNextMochi > 0 && (_currentTime * 2) > SecondsTillNextMochi && SecondHareIsBought)
            {
                _currentTime = 0;
                _mochiCounter.AddMochi();
            }
        }

        private void OnSecondHareBought()
        {
            ClicksTillMochi = 2;
            _secondHareAnimator = GameObject.FindGameObjectWithTag(SECOND_HARE_TAG).GetComponent<Animator>();
            SecondHareIsBought = true;
        }

        private void OnNoviceHaresBought()
        {
            NoviceHaresIsBought = true;
            SecondsTillNextMochi = 10;
        }

        #endregion
    }
}
