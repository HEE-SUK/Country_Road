﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void Init()
    {
        this.gameObject.SetActive(true);
    }

    public void RevivedGame()
    {
        // 부활 버튼
    }
    public void ExitGame()
    {
        // 나가기 버튼 - 콜백으로 처리하자.
    }
}
