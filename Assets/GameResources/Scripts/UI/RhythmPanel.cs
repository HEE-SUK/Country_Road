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
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void Init(string _rhythmId)
    {
        this.rhythmInfo = TableManager.RhythmInfoTable.GetInfo(_rhythmId);
        this.gameObject.SetActive(true);
        this.rhythmTarget.Init(this.rhythmInfo.barSize1, this.rhythmInfo.barSize2);
        this.rhythmArrow.Init();

        Time.timeScale = 0.1f;
        EventManager.on(EVENT_TYPE.ON_TOUCH_START, this.OnTouched);
    }
    private void OnTouched(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 
        float stopPosition = this.rhythmArrow.StopPosition();
        Debug.Log(this.rhythmTarget.StopPosition(stopPosition));

        float extraSpeed = 0f;
        switch (this.rhythmTarget.StopPosition(stopPosition))
        {
            case RHYTHMTYPE.GREAT:
                extraSpeed = this.rhythmInfo.spd1;
                break;
            case RHYTHMTYPE.GOOD:
                extraSpeed = this.rhythmInfo.spd2;
                break;
            default:
                extraSpeed = this.rhythmInfo.spd3;
                break;
        }
        Time.timeScale = 1f;
        EventManager.emit(EVENT_TYPE.TOUCH_RHYTHM, this, extraSpeed);
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        EventManager.off(EVENT_TYPE.ON_TOUCH_START, this.OnTouched);
    }
}
