using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RhythmArrow : MonoBehaviour
{
    private float originRotation = 180f;

    public void Init()
    {
        DOTween.timeScale = 1f;
        this.transform.localRotation = Quaternion.Euler(0f,0f, this.originRotation);
        this.transform.DOLocalRotate(new Vector3(0f, 0f, -this.originRotation), 2f, RotateMode.FastBeyond360)
                        .SetEase(Ease.InOutCirc)
                        .SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
                        
    }
    public float StopPosition()
    {
        this.DOKill();
        return this.transform.localRotation.z;
    }
}
