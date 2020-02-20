using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public abstract class UIComponent : MonoBehaviour
{
    public virtual Enum GetEnumText()
    {
        return null;
    }

	public virtual Enum GetEnumButton()
	{
		return null;
	}
    public virtual Enum GetEnumToggle(){
        return null;
    }
    public virtual Enum GetEnumImage(){
        return null;
    }
	public virtual Enum GetEnumRectTransform(){
		return null;
	}

	public virtual void OtherSetContent()
    {
    }

    public virtual void UIMessage(UIComponent pkUIComponent)
    {
    }

    protected GameObject m_pkParent;


    private Enum m_pkEnumText;
	private Enum m_pkEnumButton;
	private Enum m_pkEnumToggle;
    private Enum m_pkEnumImage;
	private Enum m_pkEnumRectTransform;

	public Text[] m_pkTexts;
	public Button[] m_pkButtons;
    public Toggle[] m_pkToggles;
    public Image[] m_pkImages;
	public RectTransform[] m_pkRectTransforms;

	public enum E_DEPTH
    {
        BACKGROUND_DEPTH,
        BASE_DEPTH,
        WINDOW_DEPTH,
        WINDOW_ITEM_DEPTH,
        WINDOW_POPUP_DEPTH,
        MAX_DEPTH,
    }


    [ContextMenu("SetContent")]
    public void SetContent()
    {       

        m_pkEnumText = GetEnumText();
        if (m_pkEnumText != null)
            SetText();

		m_pkEnumButton = GetEnumButton();
		if (m_pkEnumButton != null)
			SetButton();
        m_pkEnumToggle = GetEnumToggle();
        if (m_pkEnumToggle != null)
            SetToggle();
        m_pkEnumImage = GetEnumImage();
        if (m_pkEnumImage != null)
            SetImage();
		m_pkEnumRectTransform = GetEnumRectTransform();
        if (m_pkEnumRectTransform != null)
            SetRectTransform();
		OtherSetContent();
    }
	/// <summary>
	/// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Set @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	/// </summary>

    private void SetText()
    {
        Enum pkEnum = m_pkEnumText;

        m_pkTexts = new Text[(int)Enum.GetNames(pkEnum.GetType()).Length];

        for (int i = 0; i < (int)Enum.GetNames(pkEnum.GetType()).Length; i++)
        {
            string str = Enum.GetName(pkEnum.GetType(), i);

            Text[] Texts = gameObject.GetComponentsInChildren<Text>(true);
            foreach (Text Text in Texts)
            {
                if (Text.name.Equals(str) == true)
                {
                    if (m_pkTexts[i] != null)
                    {
                        Debug.LogError("SetText Error : " + str);
                    }
                    m_pkTexts[i] = Text;
                }
            }
            if (m_pkTexts[i] == null)
            {
                Debug.LogError("Find not SetText Error : " + str);
            }
        }
    }

	private void SetButton()
	{
		Enum pkEnum = m_pkEnumButton;

		m_pkButtons = new Button[(int)Enum.GetNames(pkEnum.GetType()).Length];

		for (int i = 0; i < (int)Enum.GetNames(pkEnum.GetType()).Length; i++)
		{
			string str = Enum.GetName(pkEnum.GetType(), i);

			Button[] Buttons = gameObject.GetComponentsInChildren<Button>(true);
			foreach (Button Button in Buttons)
			{
				if (Button.name.Equals(str) == true)
				{
					if (m_pkButtons[i] != null)
					{
						Debug.LogError("SetButton Error : " + str);
					}
					m_pkButtons[i] = Button;
				}
			}
			if (m_pkButtons[i] == null)
			{
				Debug.LogError("Find not SetButton Error : " + str);
			}
		}
	}
    private void SetToggle()
	{
		Enum pkEnum = m_pkEnumToggle;

		m_pkToggles = new Toggle[(int)Enum.GetNames(pkEnum.GetType()).Length];

		for (int i = 0; i < (int)Enum.GetNames(pkEnum.GetType()).Length; i++)
		{
			string str = Enum.GetName(pkEnum.GetType(), i);

			Toggle[] Toggles = gameObject.GetComponentsInChildren<Toggle>(true);
			foreach (Toggle Toggle in Toggles)
			{
				if (Toggle.name.Equals(str) == true)
				{
					if (m_pkToggles[i] != null)
					{
						Debug.LogError("SetToggle Error : " + str);
					}
					m_pkToggles[i] = Toggle;
				}
			}
			if (m_pkToggles[i] == null)
			{
				Debug.LogError("Find not SetToggle Error : " + str);
			}
		}
	}
    private void SetImage()
	{
		Enum pkEnum = m_pkEnumImage;

		m_pkImages = new Image[(int)Enum.GetNames(pkEnum.GetType()).Length];

		for (int i = 0; i < (int)Enum.GetNames(pkEnum.GetType()).Length; i++)
		{
			string str = Enum.GetName(pkEnum.GetType(), i);

			Image[] Images = gameObject.GetComponentsInChildren<Image>(true);
			foreach (Image Image in Images)
			{
				if (Image.name.Equals(str) == true)
				{
					if (m_pkImages[i] != null)
					{
						Debug.LogError("SetImage Error : " + str);
					}
					m_pkImages[i] = Image;
				}
			}
			if (m_pkImages[i] == null)
			{
				Debug.LogError("Find not SetImage Error : " + str);
			}
		}
	}
	private void SetRectTransform()
	{
		Enum pkEnum = m_pkEnumRectTransform;

		m_pkRectTransforms = new RectTransform[(int)Enum.GetNames(pkEnum.GetType()).Length];

		for (int i = 0; i < (int)Enum.GetNames(pkEnum.GetType()).Length; i++)
		{
			string str = Enum.GetName(pkEnum.GetType(), i);

			RectTransform[] RectTransforms = gameObject.GetComponentsInChildren<RectTransform>(true);
			foreach (RectTransform RectTransform in RectTransforms)
			{
				if (RectTransform.name.Equals(str) == true)
				{
					if (m_pkRectTransforms[i] != null)
					{
						Debug.LogError("SetRectTransform Error : " + str);
					}
					m_pkRectTransforms[i] = RectTransform;
				}
			}
			if (m_pkRectTransforms[i] == null)
			{
				Debug.LogError("Find not SetRectTransform Error : " + str);
			}
		}
	}

	protected virtual void PopupClose()
	{
		transform.parent.gameObject.SetActive(false);
	}
}
