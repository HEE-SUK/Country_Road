using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStopActionCallback : MonoBehaviour
{
    public CallBack callBack = null;
    void OnParticleSystemStopped(){
        if(callBack != null)
            callBack();
    }
}
