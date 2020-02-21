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
            Instance.gameSpeed = value;
        }
    }
    // 게임 전체 스피드
    private float gameSpeed = 0;
    public static int SectionIndex{
        get{
            return Instance.curSecIndex;
        }
        set{
            Instance.curSecIndex = value;
        }
    }
    // 현재 섹션 인덱스
    private int curSecIndex = 0;
    
}