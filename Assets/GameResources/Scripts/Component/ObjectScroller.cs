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
    [Header("현재 통과한 블럭 수")]
    [SerializeField] int passBlockNum = 0;
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
    [Header("현재 섹션 인덱스")]
    [SerializeField] int curSecIndex = 0;
    #endregion
    
    public SectionInfo CurSecInfo{
        get{
            return curSecInfo;
        }set{
            curSecInfo = value;
            EventManager.emit(EVENT_TYPE.SECTION_CHANGE,this,curSecInfo.id);
        }
    }

    // 블럭 생성 관련 변수 
    private Transform lastBlock = null;
    private List<GameObject> activeList = new List<GameObject>();
    private SectionInfo[] sectionInfos = null;
    // 현재 섹션 정보
    private SectionInfo curSecInfo = null;
    // 현재 섹션에서 지나간 블럭 수 
    private int passBlockNumInSection = 0;
    // 오브젝트 큐 
    private Queue<BlockController> scrollObjQueue = new Queue<BlockController>();


    // Mono
    void Start()
    {
        Init();
        GameManager.GameSpeed = scrollSpeed;
    }
    void Update(){
        GameManager.GameSpeed = scrollSpeed;
        for (int i = 0; i < activeList.Count; i++)
        {
            activeList[i].transform.Translate(Vector3.back * GameManager.GameSpeed * Time.deltaTime);
        }
    }
    void OnDestroy()
    {
        EventManager.off(EVENT_TYPE.TOUCH_RHYTHM, this.TouchRhythm);

    }


    private void Init()
    {
        OnEvent();
        DataSetting();
        InstantiateScrollObj();
    }
    private void DataSetting(){
        this.sectionInfos = TableManager.SectionInfoTable.GetArray(curSecIndex,TableManager.SectionInfoTable.GetLength() - 1);
        this.CurSecInfo = sectionInfos[curSecIndex];
    }
    private void InstantiateScrollObj(){
        for (int i = 0; i < objectCount; i++)
        {
            var pos = new Vector3(transform.position.x, transform.position.y, endPos.position.z + i * objectSpacing);
            var roadCon = Instantiate(scrollObject, pos, scrollObject.transform.rotation).GetComponent<BlockController>();
            activeList.Add(roadCon.gameObject);
            roadCon.name = i.ToString();
            if (roadCon == null)
                Debug.Log("ObjectScroller: 해당 객체에 RoadPieceController 컴포넌트가 없음");
            roadCon.Init(endPos.position,ScrollingObject,
                new BlockObjectSettingInfo(this.currentThemeIndex,false,false,0,TableManager.WallInfoTable.GetInfo(curSecInfo.wallID)));
            if(i == objectCount - 1){
                lastBlock = roadCon.transform;
            }
        }
    }
    private void OnEvent(){
        EventManager.on(EVENT_TYPE.TOUCH_RHYTHM, TouchRhythm);
    }

    private void TouchRhythm(EVENT_TYPE eventType, Component sender, object param = null)
    {
        float extraSpeed = (float)param;
        // Debug.Log($"추가 속도: {extraSpeed}");
        ChangeScollSpeed(extraSpeed, true);
    }

    public void ChangeScollSpeed(float speed, bool isPlus){
        float result = isPlus ? scrollSpeed + speed : scrollSpeed - speed;
        this.scrollSpeed = result < 0 ? 0 : result; // 마이너스 값인지 검사
        Debug.Log($"현재 속도: {this.scrollSpeed}");

    }

    // 스크롤 오브젝트가 끝 위치에 진입했을때 불릴 함수
    private void ScrollingObject(BlockController obj)
    {
        // 현재 지나간 블럭 수
        passBlockNum++;
        // 현재 섹션에서 지나간 블럭 수
        passBlockNumInSection++;        
        // 스크롤링
        obj.gameObject.SetActive(false);
        scrollObjQueue.Enqueue(obj);
        activeList.Remove(obj.gameObject);
        var newObj = scrollObjQueue.Dequeue();
        activeList.Add(newObj.gameObject);
        if(lastBlock != null)
        newObj.transform.position = new Vector3(lastBlock.position.x,lastBlock.position.y,lastBlock.position.z + objectSpacing);
        // 벽 생성 주기
        bool wallActive = false;
        if(passBlockNumInSection >= curSecInfo.sectionBlocks){
            // 다음 섹션 넘어가기
            wallActive = true;
            passBlockNumInSection = 0;
            curSecIndex++;
            CurSecInfo = sectionInfos[curSecIndex < sectionInfos.Length ? curSecIndex : sectionInfos.Length - 1];
            if(curSecInfo.checkPointID != "None") // Test용 
                Debug.Log("체크포인트 도달");
        }
        else
            wallActive = false;
        // 횡단보도 생성 주기
        bool isCrossWalk = false;
        if(passBlockNum % crossWalkNum == 0){
            isCrossWalk = true;
        }
        // 블럭 객체들 세팅하기 
        WallInfo wallInfo = TableManager.WallInfoTable.GetInfo(curSecInfo.wallID);
        wallId = curSecInfo.wallID;
        // TODO: wall Index 바꿔야함 테이블에서 추가 필요 
        newObj.SetBlockObject(new BlockObjectSettingInfo(int.Parse(curSecInfo.themeID[curSecInfo.themeID.Length-1].ToString()),isCrossWalk,wallActive,wallIndex,wallInfo));
        newObj.gameObject.SetActive(true);
        lastBlock = newObj.transform;
    }
}
