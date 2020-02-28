using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;

public class SlidePanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private Transform target = null;
    private float startPointX = 0f;
    private float endPointX = 0f;

    private float offsetX = 200f;
    private int currentIndex = 0;
    private IndexCallBack callback = null;
    public void Init(IndexCallBack _callback, int _currentIndex)
    {
        this.callback = _callback;
        this.currentIndex = _currentIndex;
    }
    public void OnPointerDown(PointerEventData _data)
    {
        this.startPointX = _data.position.x;
    }
    public void OnPointerUp(PointerEventData _data)
    {
        this.endPointX = _data.position.x;
        Debug.Log($"차이: {this.endPointX - this.startPointX}");

        if(this.endPointX - this.startPointX >= this.offsetX)
        {
            // TODO: 해당 item 위치로 이동하게 구현
            // TODO: 바뀔때마다 정보 초기화 하기
            // RIGHT 이동
            this.currentIndex--;
        }
        else if(this.endPointX - this.startPointX < -this.offsetX)
        {
            // LEFT 이동
            this.currentIndex++;
        }
        this.callback(this.currentIndex);
    }
}
