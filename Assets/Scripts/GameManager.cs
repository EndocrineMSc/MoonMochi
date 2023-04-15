using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoonMochi
{
    internal class GameManager : MonoBehaviour
    {
        internal static GameManager Instance { get; private set; }
        internal GameState State { get; private set; }
        private GameObject _settingsCanvas;
        private GameObject _menuCanvas;

        private void Awake()
        {
            //singleton
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            StartCoroutine(SwitchState(GameState.MainMenu));
        }

        internal IEnumerator SwitchState(GameState state)
        {
            State = state;

            switch (State)
            {
                case GameState.MainMenu:
                    yield return SetCanvases();
                    StartCoroutine(CloseAllCanvases());
                    _menuCanvas.SetActive(true);
                    if(!SceneManager.GetActiveScene().name.Contains("MainMenu"))
                    {
                        SceneManager.LoadScene("MainMenu");
                    }
                    break;
                case GameState.Settings:
                    yield return SetCanvases();
                    StartCoroutine(CloseAllCanvases());
                    _settingsCanvas.SetActive(true);
                    break;
                case GameState.StartGame:
                    if(!SceneManager.GetActiveScene().name.Contains("Moon"))
                    {
                        SceneManager.LoadScene("Loading");
                    }
                    break;
                case GameState.Playing:
                    if(!SceneManager.GetActiveScene().name.Contains("Moon"))
                    {
                        SceneManager.LoadScene("Moon");
                    }
                    break;
                case GameState.GameOver:
                    break;
                default:
                    break;
            }
        }

        private IEnumerator CloseAllCanvases()
        {
            if (_settingsCanvas != null && _menuCanvas != null)
            {
                Debug.Log("Closed!");
                _settingsCanvas.SetActive(false);
                _menuCanvas.SetActive(false);
            }
            yield return null;
        }

        private IEnumerator SetCanvases()
        {
            if (_settingsCanvas == null && _menuCanvas == null)
            {
                Debug.Log("Set!");
                _settingsCanvas = GameObject.FindGameObjectWithTag("Settings");
                _menuCanvas = GameObject.FindGameObjectWithTag("MainMenu");
            }
            yield return null;
        }
    }

    internal enum GameState
    {
        MainMenu,
        Settings,
        StartGame,
        Playing,
        GameOver
    }
}
