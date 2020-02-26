using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutgameUI : MonoBehaviour
{
    [SerializeField]
    private GaragePanel garagePanel = null;

    void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void Init()
    {
        this.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        this.gameObject.SetActive(false);
    }
    public void OnGarage()
    {
        this.garagePanel.Init();
    }
    public void OnCheckList()
    {
        this.gameObject.SetActive(false);
    }
    public void OnOption()
    {
        this.gameObject.SetActive(false);
    }
}
