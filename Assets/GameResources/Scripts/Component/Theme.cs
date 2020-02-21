using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theme : MonoBehaviour
{
    [SerializeField] private GameObject[] wall = null;
    [SerializeField] private GameObject[] leftHouse = null;
    [SerializeField] private GameObject[] rightHouse = null;

    [SerializeField] private GameObject[] powerpole = null;
    [SerializeField] private GameObject[] road = null; // 0: 신호 표시 있는거, 1: 신호표시 없는거
    [SerializeField] private GameObject[] leftTrafficlight;
    [SerializeField] private GameObject[] rightTrafficlight;
    [SerializeField] private GameObject[] leftFloor = null;
    [SerializeField] private GameObject[] rightFloor = null;
    [SerializeField] private GameObject[] leftGround = null;
    [SerializeField] private GameObject[] rightGround = null;
    [SerializeField] private GameObject[] options = null;
    [SerializeField] private Transform[] optionPos = null;

    public void Init(BlockObjectSettingInfo settingData){
        
        // 세팅 전 비활성화
        DisableObjectArr(wall);
        DisableObjectArr(leftHouse);
        DisableObjectArr(powerpole);
        DisableObjectArr(rightHouse);
        DisableObjectArr(road);
        DisableObjectArr(leftFloor);
        DisableObjectArr(rightFloor);
        DisableObjectArr(leftGround);
        DisableObjectArr(rightGround);
        DisableObjectArr(options);
        DisableObjectArr(leftTrafficlight);
        DisableObjectArr(rightTrafficlight);
        // 랜덤으로 객체 활성
        leftHouse[Random.Range(0,leftHouse.Length)].SetActive(true);
        leftFloor[Random.Range(0,leftFloor.Length)].SetActive(true);
        leftGround[Random.Range(0,leftGround.Length)].SetActive(true);
        rightHouse[Random.Range(0,rightHouse.Length)].SetActive(true);
        rightFloor[Random.Range(0,rightFloor.Length)].SetActive(true);
        rightGround[Random.Range(0,rightGround.Length)].SetActive(true);
        powerpole[Random.Range(0,powerpole.Length)].SetActive(true);
        // 벽 생성
        if(settingData.isWallActive){
            int wallIndex = settingData.wallIndex < wall.Length ? settingData.wallIndex : wall.Length - 1;
            Wall activeWall = wall[wallIndex].GetComponent<Wall>();
            if(activeWall == null)
                Debug.Log("this object have not WallComponent");
            activeWall.Init(settingData.wallInfo);
            wall[wallIndex].SetActive(true);
        }else{

        }
        
        // 신호 표시 있는 길과 없는길 규칙 적용 
        if(settingData.isCrossWalk){
            road[0].SetActive(true);
            leftTrafficlight[Random.Range(0,road.Length)].SetActive(true);
            rightTrafficlight[Random.Range(0,road.Length)].SetActive(true);
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
