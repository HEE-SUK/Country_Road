using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointPanel : MonoBehaviour
{
    void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public void Init()
    {
        this.gameObject.SetActive(true);
    }
    
    public void OnExit()
    {
        this.gameObject.SetActive(false);
    }
}
