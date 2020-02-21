using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IngameUI : MonoBehaviour
{
    [SerializeField]
    private Text checkPointText = null;
    [SerializeField]
    private Text goldText = null;
    [SerializeField]
    private Text jemText = null;
    
    
    [SerializeField]
    private RhythmPanel rhythmPanel = null;

    private void Awake()
    {
        this.checkPointText.text = $"{0}";
        this.goldText.text = $"{0}";
        this.jemText.text = $"{0}";
        EventManager.on(EVENT_TYPE.UPDATE_UI, this.UpdatedUI);
        EventManager.on(EVENT_TYPE.TOUCH_RHYTHM, this.TouchRhythm);
        
        this.StartCoroutine(this.DebugRhythm());
    }
    public void SetPause()
    {
        // timeScale이 0 이하이면 1로
        Time.timeScale = (Time.timeScale <= 0f) ? 1f : 0f;
        // TableManager.SectionInfoTable.GetArray(2, 5);
    }

    private IEnumerator DebugRhythm()
    {
        yield return new WaitForSeconds(2f);
        this.SetRhythmPanel();
    }
    public void SetRhythmPanel()
    {
        this.rhythmPanel.Init("R018");
    }

    private void UpdatedUI(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 골드, 금화, 체크포인트, 미터기 갱신
    }
    private void TouchRhythm(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 디버그용: 리듬터치시
        float extraSpeed = (float)param;
        // Debug.Log($"속도변화: {extraSpeed}");
        this.StartCoroutine(this.DebugRhythm());
    }
    
    private void OnDestroy()
    {
        EventManager.off(EVENT_TYPE.UPDATE_UI, this.UpdatedUI);
        EventManager.off(EVENT_TYPE.TOUCH_RHYTHM, this.TouchRhythm);
    }
}
