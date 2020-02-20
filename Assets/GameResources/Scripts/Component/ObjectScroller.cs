using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScroller : MonoBehaviour
{
    // 스크롤 할 하나의 오브젝트
    [SerializeField] private GameObject scrollObject = null;
    // 스크롤에 쓰일 오브젝트 수 
    [SerializeField] private int objectCount = 0;
    // 앞 오브젝트와 간격
    [SerializeField] private float objectSpacing = 0f;
    // 스크롤 시작 위치
    [SerializeField] private Transform startPos = null;
    // 스크롤 끝 위치
    [SerializeField] private Transform endPos = null;

    // 오브젝트 큐 
    private Queue<BlockController> scrollObjQueue = new Queue<BlockController>();
    // 통과한 블럭의 수
    [SerializeField] int passBlockNum = 0;
    // Test 전용: 통과한 블럭 몇개당 벽을 생성할지
    [SerializeField] int wallSpawnTurm = 0;
    // Test 전용: 스크롤 스피드 
    [SerializeField] float scrollSpeed = 1;
    // Test 전용: 횡단보도 몇개당 생성할지;
    [SerializeField] int crossWalkNum = 5;
    // Test 전용: 현재 테마;
    [SerializeField] int currentThemeIndex = 0;
    // Test 전용: 벽 번호;
    [SerializeField] int wallIndex = 0;
    [SerializeField] string wallId = string.Empty;
    void Start()
    {
        Init();
        GameManager.GameSpeed = scrollSpeed;
    }
    void Init()
    {
        for (int i = 0; i < objectCount; i++)
        {
            var pos = new Vector3(transform.position.x, transform.position.y, endPos.position.z + i * objectSpacing);
            var roadCon = Instantiate(scrollObject, pos, scrollObject.transform.rotation).GetComponent<BlockController>();
            if (roadCon == null)
                Debug.Log("ObjectScroller: 해당 객체에 RoadPieceController 컴포넌트가 없음");
            roadCon.Init(endPos.position,ScrollingObject,
                new BlockObjectSettingInfo(this.currentThemeIndex,false,false,0,TableManager.WallInfoTable.GetInfo("W001")));
           
        }
    }

    // 스크롤 오브젝트가 끝 위치에 진입했을때 불릴 함수
    private void ScrollingObject(BlockController obj)
    {
        // 현재 지나간 블럭 수
        passBlockNum++;        
        Debug.Log(passBlockNum + " M");
        // 스크롤링
        obj.gameObject.SetActive(false);
        obj.transform.position = startPos.position;
        scrollObjQueue.Enqueue(obj);
        var newObj = scrollObjQueue.Dequeue();
        newObj.transform.position = startPos.position;
        // 벽 생성 주기
        bool wallActive = false;
        if(passBlockNum % wallSpawnTurm == 0){
            wallActive = true;
        }
        else
            wallActive = false;

        // 횡단보도 생성 주기
        bool isCrossWalk = false;
        if(passBlockNum % crossWalkNum == 0){
            isCrossWalk = true;
        }
        // 블럭 객체들 세팅하기 
        newObj.SetBlockObject(new BlockObjectSettingInfo(currentThemeIndex,isCrossWalk,wallActive,wallIndex,TableManager.WallInfoTable.GetInfo(wallId)));
        newObj.gameObject.SetActive(true);
    }
}
