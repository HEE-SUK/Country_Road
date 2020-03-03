using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;


public class BoosterGauge : MonoBehaviour
{
    [SerializeField]
    private Image gaugeBar = null;


    private float greatAmount = 0.9f;
    private float goodAmount = 0.7f;
    public void Init(float _goodAmount, float _greatAmount)
    {
        this.goodAmount = _goodAmount;
        this.greatAmount = _greatAmount;

        // bar 초기화
        this.gaugeBar.DOKill();
        this.gaugeBar.fillAmount = 0f;
        this.gaugeBar.DOFillAmount(1f, 1f).SetLoops(-1, LoopType.Yoyo);
    }

    public BOOSTERTYPE Stop()
    {
        BOOSTERTYPE boosterType = BOOSTERTYPE.FAIL;
        if (this.gaugeBar.fillAmount >= this.greatAmount)
        {
            // great
            boosterType = BOOSTERTYPE.GREAT;
        }
        else if(this.gaugeBar.fillAmount >= this.goodAmount)
        {
            // good
            boosterType = BOOSTERTYPE.GOOD;
        }
        else
        {
            // fail
            boosterType = BOOSTERTYPE.FAIL;
        }
        
        // 초기화
        this.gaugeBar.DOKill();
        this.gaugeBar.fillAmount = 0f;

        return boosterType;
    }
}
