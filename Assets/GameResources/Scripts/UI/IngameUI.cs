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
    [SerializeField]
    private ResultPanel resultPanel = null;

    void Awake()
    {
        this.checkPointText.text = $"{0}";
        this.goldText.text = $"{0}";
        this.jemText.text = $"{0}";
        this.gameObject.SetActive(false);
    }
    public void Init()
    {
        this.gameObject.SetActive(true);
        EventManager.on(EVENT_TYPE.UPDATE_UI, this.UpdatedUI);
        EventManager.on(EVENT_TYPE.CHANGE_SECTION, this.ChangedSection);
        EventManager.on(EVENT_TYPE.FINISH_GAME, this.OnGameOver);
    }
    public void SetPause()
    {
        // timeScale이 0 이하이면 1로
        Time.timeScale = (Time.timeScale <= 0f) ? 1f : 0f;
        // TableManager.SectionInfoTable.GetArray(2, 5);
    }

    private void UpdatedUI(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 골드, 금화, 체크포인트, 미터기 갱신
    }

    private void ChangedSection(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 인게임 섹션 변화
        string SID = (string)param;
        SectionInfo sectionInfo = TableManager.SectionInfoTable.GetInfo(SID);
        this.rhythmPanel.Init(sectionInfo.rhythmID);
    }
    private void OnGameOver(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 게임 오버
        this.resultPanel.gameObject.SetActive(true);
    }
    void OnDestroy()
    {
        EventManager.off(EVENT_TYPE.UPDATE_UI, this.UpdatedUI);
        EventManager.off(EVENT_TYPE.CHANGE_SECTION, this.ChangedSection);
        EventManager.off(EVENT_TYPE.FINISH_GAME, this.OnGameOver);
    }
}
