using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MoonMochi.Mechanics.UI
{
    internal class StartButton : MonoBehaviour
    {
        // Start is called before the first frame update
        void OnEnable()
        {
            StartCoroutine(Tweening());
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        IEnumerator Tweening()
        {
            yield return new WaitForSeconds(1.5f);
            transform.DOLocalMoveX(-625, 1f).SetEase(Ease.OutBounce);
        }

        private void OnButtonClick()
        {
            StartCoroutine(GameManager.Instance.SwitchState(GameState.StartGame));
        }
    }
}
