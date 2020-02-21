using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class RhythmPanel : MonoBehaviour
{

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void Init()
    {
        this.gameObject.SetActive(true);
        this.StartCoroutine(this.TimeSlow());
    }
    private IEnumerator TimeSlow()
    {
        // 속도 slow
        while (Time.timeScale > 0.3f)
        {
            Time.timeScale -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
        EventManager.on(EVENT_TYPE.ON_TOUCH_START, this.OnTouched);
    }
    private void OnTouched(EVENT_TYPE eventType, Component sender, object param = null)
    {

        
    }

    private void OnDisable()
    {
        EventManager.off(EVENT_TYPE.ON_TOUCH_START, this.OnTouched);
    }
}
