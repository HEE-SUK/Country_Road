using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStatus : MonoBehaviour
{
    [SerializeField]
    private CarStatusButton status0 = null;
    [SerializeField]
    private CarStatusButton status1 = null;
    [SerializeField]
    private CarStatusButton status2 = null;
    [SerializeField]
    private CarStatusButton status3 = null;

    public void Init(CarInfo _info)
    {
        // status 초기화
        this.status0.Init(CARSTATUSTYPE.STAT0, _info.mSpd);
        this.status1.Init(CARSTATUSTYPE.STAT1, _info.mSpd);
        this.status2.Init(CARSTATUSTYPE.STAT2, _info.mSpd);
        this.status3.Init(CARSTATUSTYPE.STAT3, _info.mSpd);
    }

}
