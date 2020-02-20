using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmInfoTable : IInfoTable<RhythmInfo, RhythmTableData>
{
    private Dictionary<string, RhythmInfo> rhythmInfoDictionary = new Dictionary<string, RhythmInfo>();

    private string tableName = "RhythmTable";
    public RhythmInfoTable()
    {
        RhythmTable rhythmTable = Resources.Load($"DataTable/{this.tableName}", typeof(RhythmTable)) as RhythmTable;
        foreach (var data in rhythmTable.dataArray)
        {
            this.AddInfo(data);
        }
    }
    
    public RhythmInfo GetInfo(string _id)
    {
        // 키값에 해당되는 value 반환
        return this.rhythmInfoDictionary[_id];
    }
    public bool IsExist(string _id)
    {
        // 키값에 해당되는 key 존재여부
        return this.rhythmInfoDictionary.ContainsKey(_id);
    }

    public int GetLength() 
    {
        return this.rhythmInfoDictionary.Count;
    }

    public void AddInfo(RhythmTableData _data)
    {   
        RhythmInfo rhythmInfo = new RhythmInfo(_data);
        this.rhythmInfoDictionary.Add(rhythmInfo.id, rhythmInfo);
    }
}
