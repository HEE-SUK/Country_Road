using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(CanvasGroup))]
public class BlinkAction : MonoBehaviour
{
    private CanvasGroup canvasGroup = null;

    void Awake()
    {
        this.canvasGroup = this.GetComponent<CanvasGroup>();
    }
    void OnEnable()
    {
        this.canvasGroup.alpha = 1f;
        this.canvasGroup.DOKill();
        this.canvasGroup.DOFade(0f, 1f).SetLoops(-1,LoopType.Yoyo);
    }
    void OnDisable()
    {
        this.canvasGroup.DOKill();
        this.canvasGroup.alpha = 1f;
    }
}
