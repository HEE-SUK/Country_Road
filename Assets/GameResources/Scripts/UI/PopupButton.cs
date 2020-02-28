using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PopupButton : MonoBehaviour
{
    [SerializeField]
    private Text buttonString = null;

    private CallBack callbackEvent = null;
    private GameObject target = null;
    public void Init(string _textId, CallBack _callback, GameObject _target)
    {
        // 초기화
        this.buttonString.text = _textId;
        this.callbackEvent = _callback;
        this.target = _target;
    }

    public void OnButton()
    {
        // 초기화된 콜백함수 호출
        this.callbackEvent();
        Destroy(target);
    }
}
