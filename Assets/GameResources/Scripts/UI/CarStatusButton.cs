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
    public void Init(CARSTATUSTYPE _type, float _value, float _gold)
    {
        this.statusImage.sprite = this.statusSprites[(int)_type];
        this.statusImage.SetNativeSize();
        string name = "DEFAULT";
        switch (_type)
        {
            case CARSTATUSTYPE.DEF:
                name = "DEFENCE";
                break;
            case CARSTATUSTYPE.MSPD:
                name = "MAXSPEED";
                break;
            case CARSTATUSTYPE.RHM:
                name = "RHYTHM";
                break;
            case CARSTATUSTYPE.ATK:
                name = "ATTACK";
                break;
        }
        this.nameText.text = name;
        this.valueText.text = $"{_value}";
        this.goldText.text = $"{_gold}";
    }

    public void Upgrade()
    {
        // TODO: 업그레이드 하시겠습니까? 팝업
    }
}
