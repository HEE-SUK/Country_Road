using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RhythmArrow : MonoBehaviour
{
    private float originRotation = -90f;

    public void Init()
    {
        this.transform.localRotation = Quaternion.Euler(0f,0f,this.originRotation);

    }

}
