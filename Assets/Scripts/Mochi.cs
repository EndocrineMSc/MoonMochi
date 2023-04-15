using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoonMochi.Mechanics.UI;

internal class Mochi : MonoBehaviour
{
    private MochiCounter _mochiCounter;
    private float _tweenDuration = 1f;


    private void Start()
    {
        _mochiCounter = GameObject.FindObjectOfType<MochiCounter>();
        StartCoroutine(Tweening());
    }

    private IEnumerator Tweening()
    {
        Vector2 firstPosition = new(transform.position.x, transform.position.y + 1.5f);
        Vector2 counterPosition = Camera.main.ScreenToWorldPoint(_mochiCounter.transform.position);
        Vector2 punchScale = new(5.5f, 5.5f);
        transform.DOMove(firstPosition, _tweenDuration/2).SetEase(Ease.InOutExpo);
        yield return new WaitForSeconds(_tweenDuration / 2);
        transform.DOJump(counterPosition, 1, 1, _tweenDuration/2).SetEase(Ease.OutCubic);
        yield return new WaitForSeconds((_tweenDuration / 2) * 1.01f);
        _mochiCounter.AmountMochi++;
        _mochiCounter.transform.DOPunchScale(punchScale, 0.2f, 1, 100);
        yield return new WaitForSeconds(0.21f);
        _mochiCounter.transform.localScale = new(5,5);
        Destroy(gameObject);
    }
}
