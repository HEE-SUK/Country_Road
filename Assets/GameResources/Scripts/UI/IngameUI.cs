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
        
    }
    public void SetPause()
    {
        // timeScale이 0 이하이면 1로
        Time.timeScale = (Time.timeScale <= 0f) ? 1f : 0f;
        // TableManager.SectionInfoTable.GetArray(2, 5);
        this.StartCoroutine(this.DebugRhythm());
    }

    private IEnumerator DebugRhythm()
    {
        yield return new WaitForSeconds(3f);
        this.SetRhythmPanel();
    }
    public void SetRhythmPanel()
    {
        this.rhythmPanel.Init("R018");
    }

    private void UpdatedUI(EVENT_TYPE eventType, Component sender, object param = null)
    {

    }
    
    private void OnDestroy()
    {
        EventManager.off(EVENT_TYPE.UPDATE_UI, this.UpdatedUI);
    }
}
