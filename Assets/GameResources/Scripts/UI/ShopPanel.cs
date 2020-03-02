using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public void Init()
    {
        
    }


    public void TestGold()
    {
        GameManager.Gold += 1000;
        EventManager.emit(EVENT_TYPE.UPDATE_UI, this);
    }

    public void TestJem()
    {
        GameManager.Jem += 100;
        EventManager.emit(EVENT_TYPE.UPDATE_UI, this);
    }

    public void OnExit()
    {
        Destroy(this.gameObject);
    }
}
