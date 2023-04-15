using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MoonMochi.Mechanics.UI
{
    internal class BackButton : MonoBehaviour
    {
        // Start is called before the first frame update
        void OnEnable()
        {
            StartCoroutine(Tweening());
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        IEnumerator Tweening()
        {
            yield return new WaitForSeconds(0.5f);
            transform.DOLocalMoveX(700, 1f).SetEase(Ease.OutBounce);
        }

        private void OnButtonClick()
        {
            StartCoroutine(GameManager.Instance.SwitchState(GameState.MainMenu));
        }
    }
}
