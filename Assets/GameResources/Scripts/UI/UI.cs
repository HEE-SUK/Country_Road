using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    private IngameUI ingameUI = null;
    [SerializeField]
    private OutgameUI outgameUI = null;
    [SerializeField]
    private GameObject resultPanelPrefab = null;
    void Awake()
    {
        // 아웃게임과 인게임 UI 스위치 및 전체적인 데이터만 관리
        EventManager.on(EVENT_TYPE.START_GAME, this.StartGame);
        EventManager.on(EVENT_TYPE.FINISH_GAME, this.FinishGame);
    }
    void Start()
    {
        // 아웃게임과 인게임 UI 스위치 및 전체적인 데이터만 관리
        this.ExitGame();
    }

    private void StartGame(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 게임 시작
        this.ingameUI.Init();
        this.outgameUI.StartGame();
    }

    private void FinishGame(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 게임 결과
        ResultPanel resultPanel = Instantiate(this.resultPanelPrefab).GetComponent<ResultPanel>();
        resultPanel.transform.SetParent(this.transform, false);
        resultPanel.Init(this.ExitGame);
    }
    public void ExitGame()
    {
        // 게임 오버
        this.outgameUI.Init();
        this.ingameUI.ExitGame();
    }

    public void OnDestroy()
    {
        EventManager.off(EVENT_TYPE.START_GAME, this.StartGame);
        EventManager.off(EVENT_TYPE.FINISH_GAME, this.FinishGame);
    }
}
