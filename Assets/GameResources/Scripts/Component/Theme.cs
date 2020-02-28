using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theme : MonoBehaviour
{
    [SerializeField] private GameObject[] sections = null;

    public void Init(){
        // 모두 disable 시키기
        ReturnDisableObj(sections);
        // 랜덤 엑티브 
        sections[Random.Range(0,sections.Length)].SetActive(true);
    }

    public GameObject ReturnDisableObj(GameObject[] objArr){
        var shuffleArray = Utility.ShuffleArray(objArr);
        for (int i = 0; i < shuffleArray.Length; i++)
        {
            if(!shuffleArray[i].activeSelf){
                return shuffleArray[i];
            }
        }
        return null;
    }
}
