using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class PopupPanel : MonoBehaviour
{
    [SerializeField]
    private Text titleText = null;
    [SerializeField]
    private Text descriptionText = null;
    [SerializeField]
    private GameObject exitButton = null;

    // 콜백 버튼
    [SerializeField]
    protected Transform buttonsLayout = null;

    [SerializeField]
    private GameObject buttonPrefab = null;

    public void SetTitle(string _titleId)
    {
        this.titleText.text = _titleId;
    }
    public void SetDescription(string _descriptionId)
    {
        this.descriptionText.text = _descriptionId;
    }
    public void SetExitButton(bool _active)
    {
        this.exitButton.SetActive(_active);
    }
    public void SetButtons(List<PopupButtonInfo> _popupButtonInfos)
    {
        // 버튼 초기화
        foreach (var info in _popupButtonInfos)
        {
            // 버튼 동적생성
            GameObject buttonObject = Instantiate(this.buttonPrefab);
            buttonObject.transform.SetParent(this.buttonsLayout, false);
            PopupButton popupButton = buttonObject.GetComponent<PopupButton>();
            popupButton.Init(info.textId, info.callback, this.gameObject);
        }
    }

    public void OnExit()
    {
        Destroy(this.gameObject);
    }
}
