using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class RhythmPanel : MonoBehaviour
{
    [SerializeField]
    private RhythmTarget rhythmTarget = null;
    [SerializeField]
    private RhythmArrow rhythmArrow = null;

    private RhythmInfo rhythmInfo = null;

    private bool isOpened = false;
    void Awake()
    {
        this.isOpened = false;
        this.gameObject.SetActive(false);
    }
    public void Init(string _rhythmId)
    {
        if(this.isOpened) { return; }
        
        // for DEBUG 좀더 뚜렷한 로직 필요
        this.rhythmInfo = TableManager.RhythmInfoTable.GetInfo(_rhythmId);
        this.isOpened = true;
        this.gameObject.SetActive(true);
        this.rhythmTarget.Init(this.rhythmInfo.barSize1, this.rhythmInfo.barSize2);
        this.rhythmArrow.Init();

        EventManager.on(EVENT_TYPE.ON_TOUCH_START, this.OnTouched);
    }
    private void OnTouched(EVENT_TYPE eventType, Component sender, object param = null)
    {
        float stopPosition = this.rhythmArrow.StopPosition();

        float extraSpeed = 0f;
        switch (this.rhythmTarget.StopPosition(stopPosition))
        {
            case RHYTHMTYPE.GOOD:
                extraSpeed = this.rhythmInfo.spd1;
                break;
            case RHYTHMTYPE.GREAT:
                extraSpeed = this.rhythmInfo.spd2;
                break;
            default:
                extraSpeed = this.rhythmInfo.spd3;
                break;
        }
        EventManager.emit(EVENT_TYPE.TOUCH_RHYTHM, this, extraSpeed);
        this.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        this.isOpened = false;
        EventManager.off(EVENT_TYPE.ON_TOUCH_START, this.OnTouched);
    }
}
