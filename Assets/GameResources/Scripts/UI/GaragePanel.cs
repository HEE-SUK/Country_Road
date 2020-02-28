using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GaragePanel : MonoBehaviour
{
    [SerializeField]
    private SlidePanel slidePanel = null;
    [SerializeField]
    private GameObject lottoPanelPrefab = null;
    [SerializeField]
    private Transform carItemParent = null;
    [SerializeField]
    private GameObject carItemPrefab = null;

    [SerializeField]
    private CarStatus carStatus = null;

    private CarItem[] carItems = {};
    private int currentIndex = 0;
    void Awake()
    {
        this.gameObject.SetActive(false);
        CarInfo[] carInfos = TableManager.CarInfoTable.GetArray(0, TableManager.CarInfoTable.GetLength() - 1);
        this.carItems = new CarItem[carInfos.Length];
        for (int i = 0; i < carInfos.Length; i++)
        {
            CarItem carItem = Instantiate(this.carItemPrefab).GetComponent<CarItem>();
            carItem.transform.SetParent(this.carItemParent, false);
            carItem.Init(carInfos[i]);
            this.carItems[i] = carItem;
        }
    }

    public void Init()
    {
        this.gameObject.SetActive(true);
        this.carItemParent.localPosition -= this.carItems[this.currentIndex].transform.localPosition;
        this.InitCar(this.currentIndex);
    }
    private void InitCar(int _index)
    {
        // index 제한
        if(_index <= 0) 
        {
            this.currentIndex = 0;
        }
        else if(_index >= this.carItems.Length - 1)
        {
            this.currentIndex = this.carItems.Length - 1;
        }
        else
        {
            this.currentIndex = _index;
        }
        // Car정보 초기화
        this.slidePanel.Init(this.InitCar, this.currentIndex);

        CarItem currentItem = this.carItems[this.currentIndex];
        this.carStatus.Init(currentItem);            

        this.carItemParent.DOKill();
        this.carItemParent.DOLocalMoveX(-currentItem.transform.localPosition.x, 0.5f);
        EventManager.emit(EVENT_TYPE.CHOICE_CAR, this, currentItem.GetInfo());
    }

    public void OnLotto()
    {
        LottoPanel lottoPanel = Instantiate(this.lottoPanelPrefab).GetComponent<LottoPanel>();
        lottoPanel.transform.SetParent(this.transform, false);
        lottoPanel.Init();
    }
    public void OnExit()
    {
        this.gameObject.SetActive(false);
    }
}
