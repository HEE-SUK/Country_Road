using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaragePanel : MonoBehaviour
{
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

    public void OnExit()
    {
        this.gameObject.SetActive(false);
    }
}
