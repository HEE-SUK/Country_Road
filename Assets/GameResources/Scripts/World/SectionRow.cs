using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SectionRow : MonoBehaviour
{
    public void Init()
    {
        this.transform.DOLocalMoveY(0f, 0.5f).SetEase(Ease.OutBack);
    }
}
