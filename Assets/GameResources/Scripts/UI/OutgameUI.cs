using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutgameUI : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void Init()
    {
        this.gameObject.SetActive(true);
    }

}
