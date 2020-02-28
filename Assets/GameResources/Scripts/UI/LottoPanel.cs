using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LottoPanel : MonoBehaviour
{
    public void Init()
    {
        
    }

    public void OnLotto()
    {
        Debug.Log($"뿌잉뿌잉!");
    }

    public void OnExit()
    {
        Destroy(this.gameObject);
    }
}
