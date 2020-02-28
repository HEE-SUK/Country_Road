using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CarItem : MonoBehaviour
{
    [SerializeField]
    private Image carImage = null;
    [SerializeField]
    private Text nameText = null;
    private CarInfo info = null;
    
    public void Init(CarInfo _info)
    {
        this.info = _info;
        this.nameText.text = _info.name;
    }
    public CarInfo GetInfo()
    {
        return this.info;
    }
}
