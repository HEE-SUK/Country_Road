using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theme : MonoBehaviour
{
    [SerializeField] private GameObject[] wall = null;
    [SerializeField] private GameObject[] house = null;
    [SerializeField] private GameObject[] powerpole = null;
    [SerializeField] private GameObject[] road = null; // 0: 신호 표시 있는거, 1: 신호표시 없는거
    [SerializeField] private GameObject[] floor = null;
    [SerializeField] private GameObject[] ground = null;
    [SerializeField] private GameObject[] options = null;
    [SerializeField] private Transform[] optionPos = null;

    public void Init(BlockObjectSettingInfo settingData){
        
        // 세팅 전 비활성화
        DisableObjectArr(wall);
        DisableObjectArr(house);
        DisableObjectArr(powerpole);
        DisableObjectArr(road);
        DisableObjectArr(floor);
        DisableObjectArr(ground);
        DisableObjectArr(options);
        // 랜덤으로 객체 활성
        house[Random.Range(0,house.Length)].SetActive(true);
        powerpole[Random.Range(0,powerpole.Length)].SetActive(true);
        floor[Random.Range(0,floor.Length)].SetActive(true);
        ground[Random.Range(0,ground.Length)].SetActive(true);
        // 벽 생성
        if(settingData.isWallActive){
            int wallIndex = settingData.wallIndex < wall.Length ? settingData.wallIndex : wall.Length - 1;
            Wall activeWall = wall[wallIndex].GetComponent<Wall>();
            if(activeWall == null)
                Debug.Log("this object have not WallComponent");
            activeWall.Init(settingData.wallInfo);
            wall[wallIndex].SetActive(true);
        }
        
        // 신호 표시 있는 길과 없는길 규칙 적용 
        if(settingData.isCrossWalk){
            road[0].SetActive(true);
        }else{
            road[Random.Range(1,road.Length)].SetActive(true);
        }

        // 주변 사물 위치 
        for (int i = 0; i < optionPos.Length; i++)
        {
            var obj = ReturnDisableObj(options);
            if(obj != null){
                obj.transform.position = optionPos[i].position;
                obj.SetActive(true);
            }
        }
    }
    private void DisableObjectArr(GameObject[] objArr){
        if(objArr.Length == 0){
            Debug.Log("DisableObjectArr Failed, objArr.Length is " + objArr.Length);
            return;
        }
        for (int i = 0; i < objArr.Length; i++)
        {
            objArr[i].SetActive(false);
        }
    }

    public GameObject ReturnDisableObj(GameObject[] objArr){
        var shuffleArray = CollectionUtil.ShuffleArray(objArr);
        for (int i = 0; i < shuffleArray.Length; i++)
        {
            if(!shuffleArray[i].activeSelf){
                return shuffleArray[i];
            }
        }
        return null;
    }
}
