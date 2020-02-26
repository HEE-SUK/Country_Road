using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RhythmArrow : MonoBehaviour
{
    private float originRotation = 90f;

    public void Init()
    {
        DOTween.timeScale = 1f;
        this.transform.localRotation = Quaternion.Euler(0f,0f, this.originRotation);
        this.transform.DOLocalRotate(new Vector3(0f, 0f, -this.originRotation), 1f, RotateMode.FastBeyond360)
                        .SetEase(Ease.Linear)
                        .SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
                        
    }
    public float StopPosition()
    {
        this.transform.DOKill();
        float result = this.transform.localEulerAngles.z;
        
        return (result > this.originRotation)? result - 2 * this.originRotation: result;
    }
}
