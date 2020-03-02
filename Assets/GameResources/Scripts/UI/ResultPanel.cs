using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    private CallBack callback = null;
    void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void Init(CallBack _callback)
    {
        this.callback = _callback;
        this.gameObject.SetActive(true);
    }

    public void RevivedGame()
    {
        // 부활 버튼
    }
    public void ExitGame()
    {
        // 나가기 버튼 - 콜백으로 처리하자.
        this.callback();
        Destroy(this.gameObject);  
    }
}
