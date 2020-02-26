using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScroller : MonoBehaviour
{
    #region 인스펙터
    [Header("블럭 프리펩")]
    [SerializeField] private GameObject scrollObject = null;
    [Header("스크롤에 쓰일 오브젝트 수")]
    [SerializeField] private int objectCount = 0;
    // 앞 오브젝트와 간격
    [Header("오브젝트 사이간격")]
    [SerializeField] private float objectSpacing = 0f;
    // 스크롤 시작 위치
    [Header("스크롤 시작 위치")]
    [SerializeField] private Transform startPos = null;
    // 스크롤 끝 위치
    [Header("스크롤 끝 위치")]
    [SerializeField] private Transform endPos = null;
    // 통과한 블럭의 수
    [Header("현재 통과한 섹션 수")]
    [SerializeField] int passSectionNum = 0;
    // Test 전용: 스크롤 스피드 
    [Header("스크롤 스피드")]
    [SerializeField] float scrollSpeed = 1;
    // Test 전용: 횡단보도 몇개당 생성할지;
    [Header("황단보도 생성 텀")]
    [SerializeField] int crossWalkNum = 5;
    // Test 전용: 현재 테마;
    [Header("현재 테마")]
    [SerializeField] int currentThemeIndex = 0;
    // Test 전용: 벽 번호;
    [Header("벽 레벨(0부터 시작)")]
    [SerializeField] int wallIndex = 0;
    [Header("현재 벽 데이터 키값")]
    [SerializeField] string wallId = string.Empty;
    #endregion

    // 블럭 생성 관련 변수 
    private Transform lastBlock = null;
    private List<GameObject> activeList = new List<GameObject>();
    // 오브젝트 큐 
    private Queue<BlockController> scrollObjQueue = new Queue<BlockController>();

    // 현재 지나온 거리
    private float curPassDistance = 0;
    private ScrollEndDataSetting scrollEndDataSetting = null;

    // Mono
    void Start()
    {
        GameManager.GameSpeed = scrollSpeed;
    }
    void Update()
    {
        GameManager.GameSpeed = scrollSpeed;
        curPassDistance += scrollSpeed * Time.deltaTime;
        for (int i = 0; i < activeList.Count; i++)
        {
            activeList[i].transform.Translate(Vector3.back * GameManager.GameSpeed * Time.deltaTime);
        }
    }
    public void Init(ScrollEndDataSetting scrollEndDataSetting)
    {
        this.scrollEndDataSetting = scrollEndDataSetting;
        InstantiateScrollObj(scrollEndDataSetting);
    }
    private void InstantiateScrollObj(ScrollEndDataSetting scrollEndDataSetting)
    {
        SectionInfo curSecInfo = scrollEndDataSetting();
        for (int i = 0; i < objectCount; i++)
        {
            var pos = new Vector3(transform.position.x, transform.position.y, endPos.position.z + i * objectSpacing);
            var blockCon = Instantiate(scrollObject, pos, scrollObject.transform.rotation).GetComponent<BlockController>();
            blockCon.transform.SetParent(this.transform);
            activeList.Add(blockCon.gameObject);
            blockCon.name = i.ToString();
            if (blockCon == null)
                Debug.Log("ObjectScroller: 해당 객체에 RoadPieceController 컴포넌트가 없음");
            blockCon.Init(endPos.position, ScrollEndCallBack,
                new BlockObjectSettingInfo(this.currentThemeIndex,false, TableManager.WallInfoTable.GetInfo(curSecInfo.wallID)));
            if (i == objectCount - 1)
            {
                lastBlock = blockCon.transform;
            }
        }
    }

    public void ChangeScollSpeed(float speed, bool isPlus)
    {
        float result = isPlus ? scrollSpeed + speed : scrollSpeed - speed;
        this.scrollSpeed = result < 0 ? 0 : result; // 마이너스 값인지 검사
        // Debug.Log($"현재 속도: {this.scrollSpeed}");
    }

    // 스크롤 오브젝트가 끝 위치에 진입했을때 불릴 함수
    private void ScrollEndCallBack(BlockController obj)
    {
        // 스크롤링
        obj.gameObject.SetActive(false);
        scrollObjQueue.Enqueue(obj);
        activeList.Remove(obj.gameObject);
        var newObj = scrollObjQueue.Dequeue();
        activeList.Add(newObj.gameObject);
        if (lastBlock != null)
            newObj.transform.position = new Vector3(lastBlock.position.x, lastBlock.position.y, lastBlock.position.z + objectSpacing);
        SectionInfo curSecInfo = this.scrollEndDataSetting();
        WallInfo wallInfo = TableManager.WallInfoTable.GetInfo(curSecInfo.wallID);
        newObj.SetBlockObject(new BlockObjectSettingInfo(curSecInfo.themeIndex,true, wallInfo));
        newObj.gameObject.SetActive(true);
        lastBlock = newObj.transform;
        Debug.Log("현재 지나온 거리: " + curPassDistance);
    }
}
