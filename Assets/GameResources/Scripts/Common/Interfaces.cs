using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// infotable 인터페이스
public interface IInfoTable<T,G>
{
    // 테이블에서 id를 매개변수로 Info 클래스 호출
    T GetInfo(string _id);
    // 해당 id를 가지는 Info가 존재하는지 확인
    bool IsExist(string _id);
    // 테이블에 들어있는 info 갯수 확인
    int GetLength();
    void AddInfo(G _data);
}
