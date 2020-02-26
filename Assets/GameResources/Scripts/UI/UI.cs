using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    private IngameUI ingameUI = null;
    [SerializeField]
    private OutgameUI outgameUI = null;
    void Awake()
    {
        // 아웃게임과 인게임 UI 스위치 및 전체적인 데이터만 관리
    }
    void Start()
    {
        // 아웃게임과 인게임 UI 스위치 및 전체적인 데이터만 관리
        this.outgameUI.Init();

        // DEBUG    
        // this.ingameUI.Init();
    }

    public void StartGame()
    {
        // 인게임으로
        this.ingameUI.Init();
        this.outgameUI.StartGame();
        EventManager.emit(EVENT_TYPE.START_GAME, this);
    }
    public void ExitGame()
    {
        // 아웃게임으로
        // this.ingameUI.Init();
        this.outgameUI.Init();
    }
}
