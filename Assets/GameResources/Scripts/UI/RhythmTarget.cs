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

    private float originDegree = 360f;
    public void Init(float _goodAmount, float _greatAmount)
    {
        float test = (this.originDegree - _goodAmount) / 2;
        // 방향 설정
        this.transform.localRotation = Quaternion.Euler(0f, 0f , Random.Range(-test, test));

        // good, great 너비값 설정
        foreach (var target in this.goodTarget)
        {
            target.fillAmount = _goodAmount/2;
        }
        foreach (var target in this.greatTarget)
        {
            target.fillAmount = _greatAmount/2;
        }
    }
}
