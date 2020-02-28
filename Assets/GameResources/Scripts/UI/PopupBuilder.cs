using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupButtonInfo
{
    public string textId = null;
    public CallBack callback = null;

    public PopupButtonInfo(string _textId, CallBack _callback)
    {
        this.textId = _textId;
        this.callback = _callback;
    }
}
public class PopupBuilder
{
    private string titleId = null;
    private string descriptionId = null;
    private bool exitButtonActive = false;

    private Transform target = null;
    private List<PopupButtonInfo> buttonInfoList = new List<PopupButtonInfo>();

    public PopupBuilder(Transform _target)
    {
        this.target = _target;
    }
    public void Build()
    {
        GameObject popupObject = GameObject.Instantiate(Resources.Load("Popup/PopupPanel", typeof(GameObject))) as GameObject;
        popupObject.transform.SetParent(this.target, false);
        PopupPanel popupPanel = popupObject.GetComponent<PopupPanel>();

        // 팝업설정
        popupPanel.SetTitle(this.titleId);
        popupPanel.SetDescription(this.descriptionId);
        popupPanel.SetButtons(this.buttonInfoList);
        popupPanel.SetExitButton(this.exitButtonActive);
    }

    public void SetTitle(string _titleId)
    {
        this.titleId = _titleId;
    }
    public void SetDescription(string _descriptionId)
    {
        this.descriptionId = _descriptionId;
    }
    public void SetExitButton()
    {
        this.exitButtonActive = true;
    }
    public void SetButton(string _textId, CallBack _callback)
    {
        this.buttonInfoList.Add(new PopupButtonInfo(_textId, _callback));
    }
}
