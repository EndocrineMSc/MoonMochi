using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonMochi.Mechanics
{
    internal class ClickerManager : MonoBehaviour
    {
        #region Fields and Properties

        internal static ClickerManager Instance { get; private set; }

        private Animator _hareAnimator;
        private MochiCounter _mochiCounter;

        private const string COUNTER_TAG = "Counter";
        private const string HARE_TAG = "Hare";
        private const string HARE_HIT_ANIM = "Hit";

        internal int ClicksTillMochi { get; set; } = 4;
        private int _currentClicks = 0;

        internal int SecondsTillNextMochi { get; set; } = -1; //-1 is deactivated state -> auto-generation of mochi by upgrades
        private float _currentTime = 0;

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

        // Start is called before the first frame update
        private void Start()
        {
            _mochiCounter = GameObject.FindGameObjectWithTag(COUNTER_TAG).GetComponent<MochiCounter>();
            _hareAnimator = GameObject.FindGameObjectWithTag(HARE_TAG).GetComponent<Animator>();
        }

        private void OnMouseDown()
        {
            _currentClicks++;
            _hareAnimator.SetTrigger(HARE_HIT_ANIM);
            if (_currentClicks >= ClicksTillMochi)
            {
                _mochiCounter.AddMochi();
                _currentClicks = 0;
            }
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (SecondsTillNextMochi > 0 && _currentTime > SecondsTillNextMochi)
            {
                _currentTime = 0;
                _mochiCounter.AddMochi();
            }
        }

        #endregion
    }
}
