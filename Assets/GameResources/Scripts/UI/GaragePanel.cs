using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaragePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject lottoPanelPrefab = null;
    [SerializeField]
    private CarStatus carStatus = null;
    void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void Init()
    {
        // TODO: 자동자 모든 정보 호출
        this.gameObject.SetActive(true);
    }
    private void InitCar(CarInfo _info)
    {
        this.carStatus.Init(_info);
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
