using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStatus : MonoBehaviour
{
    [SerializeField]
    private CarStatusButton defence = null;
    [SerializeField]
    private CarStatusButton maxSpeed = null;
    [SerializeField]
    private CarStatusButton rhythm = null;
    [SerializeField]
    private CarStatusButton attack = null;

    public void Init(CarItem _item)
    {
        CarInfo info = _item.GetInfo();
        // status 초기화
        this.defence.Init(CARSTATUSTYPE.DEF, info.bumper, info.price);
        this.maxSpeed.Init(CARSTATUSTYPE.MSPD, info.booster, info.price);
        this.rhythm.Init(CARSTATUSTYPE.RHM, info.tire, info.price);
        this.attack.Init(CARSTATUSTYPE.ATK, info.atk, info.price);
    }

}
