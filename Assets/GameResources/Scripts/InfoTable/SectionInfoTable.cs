using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionInfoTable : IInfoTable<SectionInfo, SectionTableData>
{
    private Dictionary<string, SectionInfo> sectionInfoDictionary = new Dictionary<string, SectionInfo>();

    private string tableName = "SectionTable";
    public SectionInfoTable()
    {
        SectionTable sectionTable = Resources.Load($"DataTable/{this.tableName}", typeof(SectionTable)) as SectionTable;
        foreach (var data in sectionTable.dataArray)
        {
            this.AddInfo(data);
        }
    }
    
    public SectionInfo GetInfo(string _id)
    {
        // 키값에 해당되는 value 반환
        return this.sectionInfoDictionary[_id];
    }
    public bool IsExist(string _id)
    {
        // 키값에 해당되는 key 존재여부
        return this.sectionInfoDictionary.ContainsKey(_id);
    }

    public SectionInfo[] GetSectionInfoArray(int _start, int _end)
    {
        // 전체 배열
        SectionInfo[] dataArray = (new List<SectionInfo>(this.sectionInfoDictionary.Values)).ToArray();
        
        // 원하는 길이만큼의 배열
        SectionInfo[] result = new SectionInfo[(_end + 1) - _start];
        int index = 0;
        for (int i = _start; i <= _end; i++)
        {
            result[index] = dataArray[i];
            index++;
        }
        return dataArray;
    }
    public int GetLength() 
    {
        return this.sectionInfoDictionary.Count;
    }

    public void AddInfo(SectionTableData _data)
    {   
        SectionInfo sectionInfo = new SectionInfo(_data);
        this.sectionInfoDictionary.Add(sectionInfo.id, sectionInfo);
    }
}
