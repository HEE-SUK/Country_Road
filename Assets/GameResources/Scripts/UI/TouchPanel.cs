using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TouchPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private CallBack startCallback = null;
    private CallBack endCallback = null;
    public  void Init(CallBack _start, CallBack _end)
    {
        // TODO: 추후에는 드래그도 추가하자!
        this.startCallback = _start;
        this.endCallback = _end;
    }
    public void OnPointerDown(PointerEventData _data)
    {
        this.startCallback();
    }
    public void OnPointerUp(PointerEventData _data)
    {
        this.endCallback();
    }
}
