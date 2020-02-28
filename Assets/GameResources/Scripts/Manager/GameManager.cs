using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    public static float GameSpeed{
        get{
            return Instance.gameSpeed;
        }
        set{
            Instance.gameSpeed = Mathf.Lerp(Instance.gameSpeed,value,0.5f);
        }
    }
    public static int SectionIndex{
        get{
            return Instance.curSecIndex;
        }
        set{
            Instance.curSecIndex = value;
        }
    }
    public static float TimeScale{
        get{
            return Instance.timeScale;
        }
        set{
            Instance.timeScale = value;
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
    // 재화
    private int gold = 0;
    private int jem = 0;

    public static int GetGold()
    {
        return Instance.gold;
    }
    public static int GetJem()
    {
        return Instance.jem;
    }
    public static LOCALIZETYPE GetLocalizeType()
    {
        return Instance.localizeType;
    }
}