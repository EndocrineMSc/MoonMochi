using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoonMochi
{
    internal class LoadingScreen : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(WaitForLoad());
        }
        
        IEnumerator WaitForLoad()
        {
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(GameManager.Instance.SwitchState(GameState.Playing));
        }
    }
}
