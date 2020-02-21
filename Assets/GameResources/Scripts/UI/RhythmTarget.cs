using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RhythmTarget : MonoBehaviour
{
    [SerializeField]
    private Image[] goodTarget = {};
    [SerializeField]
    private Image[] greatTarget = {}; 
    public void Init(float _rotation, float _goodAmount, float _greatAmount)
    {
        // 방향 설정
        this.transform.localRotation = Quaternion.Euler(0f, 0f ,_rotation);

        // good, great 너비값 설정
        foreach (var target in this.goodTarget)
        {
            target.fillAmount = _goodAmount;
        }
        foreach (var target in this.greatTarget)
        {
            target.fillAmount = _greatAmount;
        }
    }
}
