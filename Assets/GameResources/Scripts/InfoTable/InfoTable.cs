using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTable<Info>
{
    protected Dictionary<string, Info> infoDictionary = new Dictionary<string, Info>();

    public Info GetInfo(string _id)
    {
        // 키값에 해당되는 value 반환
        return this.infoDictionary[_id];
    }
    public bool IsExist(string _id)
    {
        // 키값에 해당되는 key 존재여부
        return this.infoDictionary.ContainsKey(_id);
    }
    public int GetLength() 
    {
        // 딕셔너리 길이 호출
        return this.infoDictionary.Count;
    }
    public Info[] GetArray(int _start, int _end)
    {
        // 전체 배열
        Info[] dataArray = (new List<Info>(this.infoDictionary.Values)).ToArray();
        
        // 원하는 길이만큼의 배열
        Info[] result = new Info[(_end + 1) - _start];
        int index = 0;
        for (int i = _start; i <= _end; i++)
        {
            result[index] = dataArray[i];
            index++;
        }
        return dataArray;
    }
}
