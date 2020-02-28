﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UserUI : MonoBehaviour
{
    [SerializeField]
    private Text goldText = null;
    [SerializeField]
    private Text jemText = null;
    [SerializeField]
    private GameObject optionPanelPrefab = null;
    void Start()
    {
        EventManager.on(EVENT_TYPE.UPDATE_UI, this.UpdatedUI);
        EventManager.emit(EVENT_TYPE.UPDATE_UI, this);
    }

    private void UpdatedUI(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 골드, 금화
        this.goldText.text = $"{GameManager.GetGold()}";
        this.jemText.text = $"{GameManager.GetJem()}";
    }

    public void OnOption()
    {
        OptionPanel optionPanel = Instantiate(this.optionPanelPrefab).GetComponent<OptionPanel>();
        optionPanel.Init();
    }
    void OnDestroy()
    {
        EventManager.off(EVENT_TYPE.UPDATE_UI, this.UpdatedUI);
    }
}
