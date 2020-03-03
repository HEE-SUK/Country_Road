using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IngameUI : MonoBehaviour
{
    [SerializeField]
    private Text checkPointText = null;
    
    
    [SerializeField]
    private BoosterPanel boosterPanel = null;

    void Awake()
    {
        this.checkPointText.text = $"{0}";
        this.gameObject.SetActive(false);
    }
    public void Init()
    {
        this.gameObject.SetActive(true);
        EventManager.on(EVENT_TYPE.UPDATE_UI, this.UpdatedUI);
        EventManager.on(EVENT_TYPE.CHANGE_SECTION, this.ChangedSection);
        this.boosterPanel.Init();
    }
    public void ExitGame()
    {
        this.gameObject.SetActive(false);
    }
    public void SetPause()
    {
        // timeScale이 0 이하이면 1로
        Time.timeScale = (Time.timeScale <= 0f) ? GameManager.TimeScale : 0f;
    }

    private void UpdatedUI(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 체크포인트, 미터기 갱신
    }

    private void ChangedSection(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 인게임 섹션 변화
        string SID = (string)param;
        SectionInfo sectionInfo = TableManager.SectionInfoTable.GetInfo(SID);
    }
    void OnDestroy()
    {
        EventManager.off(EVENT_TYPE.UPDATE_UI, this.UpdatedUI);
        EventManager.off(EVENT_TYPE.CHANGE_SECTION, this.ChangedSection);
    }
}
