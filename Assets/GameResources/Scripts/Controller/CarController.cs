using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private ParticleSystem wallBrokenParticle = null;
    [SerializeField] private CarWeapon weapon = null;

    private CarInfo carInfo = null;
    void Start(){
        OnEvent();
        Init(TableManager.CarInfoTable.GetInfo("C001"));
    }
    void OnDestroy()
    {
        EventManager.off(EVENT_TYPE.WALL_BROKEN, this.WallBroken);
    }



    public void Init(CarInfo carInfo){
        this.carInfo = carInfo;
        this.weapon.Init(carInfo);
    }

    private void OnEvent(){
        EventManager.on(EVENT_TYPE.WALL_BROKEN,WallBroken);
    }

    private void WallBroken(EVENT_TYPE eventType, Component sender, object param = null){
        var particle = Instantiate(wallBrokenParticle.gameObject,this.transform.position + Vector3.forward,wallBrokenParticle.transform.rotation);
        particle.gameObject.SetActive(true);
    }
}
