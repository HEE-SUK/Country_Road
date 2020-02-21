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

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void Init(string _rhythmId)
    {
        RhythmInfo rhythmInfo = TableManager.RhythmInfoTable.GetInfo(_rhythmId);
        this.gameObject.SetActive(true);
        this.rhythmTarget.Init( 0.9f, 0.8f);
        this.rhythmArrow.Init();

        Time.timeScale = 0.1f;
        EventManager.on(EVENT_TYPE.ON_TOUCH_START, this.OnTouched);
    }
    private void OnTouched(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 
    }

    private void OnDisable()
    {
        EventManager.off(EVENT_TYPE.ON_TOUCH_START, this.OnTouched);
    }
}
