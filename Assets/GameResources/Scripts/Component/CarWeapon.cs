using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWeapon : MonoBehaviour
{
    [SerializeField] private AutoAttack autoAttack = null;
    [SerializeField] private Animator anim = null;
    private CarInfo carInfo = null;
    public void Init(CarInfo carInfo){
        this.carInfo = carInfo;
        this.autoAttack.Init(carInfo.bullet,carInfo.atkSpd,carInfo.reload,carInfo.atk, SetFireAnimActive);
    }
    public void SetFireAnimActive(bool active){
        anim.SetBool("Fire", active);
    }

}
