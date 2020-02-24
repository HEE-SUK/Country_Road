using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    // [SerializeField]
    // private ObjectScroller objectScroller = null;
    private void Start()
    {
        EventManager.on(EVENT_TYPE.TOUCH_RHYTHM, this.TouchRhythm);
        // EventManager.on(EVENT_TYPE.CHANGE_SECTION, this.SectionChange);

    }

    private void TouchRhythm(EVENT_TYPE eventType, Component sender, object param = null)
    {
        float extraSpeed = (float)param;
        // Debug.Log($"추가 속도: {extraSpeed}");
        // this.objectScroller.ChangeScollSpeed(extraSpeed, true);
    }
    // private void SectionChange(EVENT_TYPE eventType, Component sender, object param = null)
    // {
    //     string extraSpeed = (string)param;
    //     Debug.Log($"현재 섹션: {extraSpeed}");
    // }
    void OnDestroy()
    {
        EventManager.off(EVENT_TYPE.TOUCH_RHYTHM, this.TouchRhythm);
    }
}
