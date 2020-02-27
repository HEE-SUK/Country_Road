using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CarStatusButton : MonoBehaviour
{
    [SerializeField]
    private Image statusImage = null;
    [SerializeField]
    private Sprite[] statusSprites = {};

    [SerializeField]
    private Text nameText = null;
    [SerializeField]
    private Text valueText = null;
    [SerializeField]
    private Text goldText = null;
    public void Init(CARSTATUSTYPE _type, float _value)
    {
        this.statusImage.sprite = this.statusSprites[(int)_type];
        this.statusImage.SetNativeSize();
        this.nameText.text = $"이름";
        this.valueText.text = $"값";
        this.goldText.text = $"골드";
    }

    public void Upgrade()
    {
        // TODO: 업그레이드 하시겠습니까? 팝업
    }
}
