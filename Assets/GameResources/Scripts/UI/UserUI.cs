using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UserUI : MonoBehaviour
{
    [SerializeField]
    private Text goldText = null;
    [SerializeField]
    private Text jemText = null;
    void Awake()
    {
        this.goldText.text = $"{0}";
        this.jemText.text = $"{0}";
    }

    void Start()
    {
        EventManager.on(EVENT_TYPE.UPDATE_UI, this.UpdatedUI);
    }

    private void UpdatedUI(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 골드, 금화
    }

    void OnDestroy()
    {
        EventManager.off(EVENT_TYPE.UPDATE_UI, this.UpdatedUI);
    }
}
