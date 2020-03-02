using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    public static float GameSpeed
    {
        get
        {
            return Instance.gameSpeed;
        }
        set
        {
            Instance.gameSpeed = Mathf.Floor(Mathf.Lerp(Instance.gameSpeed,value,0.5f) * 100f) * 0.01f;
        }
    }
    public static int SectionIndex
    {
        get
        {
            return Instance.curSecIndex;
        }
        set
        {
            Instance.curSecIndex = value;
        }
    }
    public static float TimeScale
    {
        get
        {
            return Instance.timeScale;
        }
        set
        {
            Instance.timeScale = value;
        }
    }
    public static bool IsVibration
    {
        get
        {
            return Instance.isVibration;
        }
        set
        {
            Instance.isVibration = value;
        }
    }
    public static int Gold
    {
        get
        {
            return Instance.gold;
        }
        set
        {
            Instance.gold = value;
        }
    }
    public static int Jem
    {
        get
        {
            return Instance.jem;
        }
        set
        {
            Instance.jem = value;
        }
    }

    // 게임 전체 스피드
    private float gameSpeed = 0f;
    // 현재 섹션 인덱스
    private int curSecIndex = 0;
    // 타임 스케일
    private float timeScale = 1f;
    // 언어
    private LOCALIZETYPE localizeType = LOCALIZETYPE.EN;
    // 진동
    private bool isVibration = true;
    // 재화
    private int gold = 0;
    private int jem = 0;

    public static LOCALIZETYPE GetLocalizeType()
    {
        return Instance.localizeType;
    }
    public static void SetLocalizeType(LOCALIZETYPE _type)
    {
        Instance.localizeType = _type;
    }
    public static void PlayVibration()
    {
        if(!Instance.isVibration) { return; }
        Handheld.Vibrate();
    }
}