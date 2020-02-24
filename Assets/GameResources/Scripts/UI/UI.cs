using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    private IngameUI ingameUI = null;
    [SerializeField]
    private OutgameUI outgameUI = null;
    private void Awake()
    {
        // 아웃게임과 인게임 UI 스위치 및 전체적인 데이터만 관리
    }
    private void Start()
    {
        // 아웃게임과 인게임 UI 스위치 및 전체적인 데이터만 관리
        this.outgameUI.Init();
    }

    public void StartGame()
    {
        this.ingameUI.Init();
    }

}
