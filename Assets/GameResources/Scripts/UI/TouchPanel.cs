using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TouchPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData _data)
    {
        EventManager.emit(EVENT_TYPE.ON_TOUCH_START, this);
    }
    public void OnPointerUp(PointerEventData _data)
    {
        EventManager.emit(EVENT_TYPE.ON_TOUCH_END, this);
    }
}
