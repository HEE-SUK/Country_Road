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
    private float goodDegree = 0f;
    private float greatDegree = 0f;
    private float currentTarget = 0f;
    public void Init(float _greatAmount, float _goodAmount)
    {
        float randomTarget = this.originDegree * (1 - _goodAmount) / 2;
        this.currentTarget = Random.Range(-randomTarget, randomTarget);
        
        this.goodDegree = this.originDegree * _goodAmount / 2;
        this.greatDegree = this.originDegree * _greatAmount / 2;
        // 방향 설정
        this.transform.localRotation = Quaternion.Euler(0f, 0f , this.currentTarget);

        // good, great 너비값 설정
        foreach (var target in this.goodTarget)
        {
            target.fillAmount = _goodAmount / 2;
        }
        foreach (var target in this.greatTarget)
        {
            target.fillAmount = _greatAmount / 2;
        }
    }
    public RHYTHMTYPE StopPosition(float _arrow)
    {
        RHYTHMTYPE rhythmType = RHYTHMTYPE.FAIL;
        if (_arrow > this.currentTarget - this.greatDegree && _arrow < this.currentTarget + this.greatDegree)
        {
            // great
            rhythmType = RHYTHMTYPE.GREAT;
        }
        else if(_arrow > this.currentTarget - this.goodDegree && _arrow < this.currentTarget + this.goodDegree)
        {
            // good
            rhythmType = RHYTHMTYPE.GOOD;
        }
        else
        {
            // fail
            rhythmType = RHYTHMTYPE.FAIL;
        }
        return rhythmType;
    }
}
