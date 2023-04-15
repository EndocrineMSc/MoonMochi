using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonMochi.Mechanics.UI
{
    internal class Title : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            transform.DOLocalMoveY(150, 1.5f).SetEase(Ease.OutCubic);
        }
    }
}
