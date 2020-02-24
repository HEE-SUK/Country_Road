using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] ParticleSystem wallBrokenParticle = null;

    void Start(){
        OnEvent();
    }
    void OnDestroy()
    {
        EventManager.off(EVENT_TYPE.WALL_BROKEN, this.WallBroken);
    }

    private void OnEvent(){
        EventManager.on(EVENT_TYPE.WALL_BROKEN,WallBroken);
    }

    private void WallBroken(EVENT_TYPE eventType, Component sender, object param = null){
        var particle = Instantiate(wallBrokenParticle.gameObject,this.transform.position + Vector3.forward,wallBrokenParticle.transform.rotation);
        particle.gameObject.SetActive(true);
    }
}
