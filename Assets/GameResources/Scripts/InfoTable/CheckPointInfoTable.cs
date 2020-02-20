using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointInfoTable : IInfoTable<CheckPointInfo, CheckPointTableData>
{
    private Dictionary<string, CheckPointInfo> checkPointInfoDictionary = new Dictionary<string, CheckPointInfo>();

    private string tableName = "CheckPointTable";
    public CheckPointInfoTable()
    {
        CheckPointTable checkPointTable = Resources.Load($"DataTable/{this.tableName}", typeof(CheckPointTable)) as CheckPointTable;
        foreach (var data in checkPointTable.dataArray)
        {
            this.AddInfo(data);
        }
    }
    
    public CheckPointInfo GetInfo(string _id)
    {
        // 키값에 해당되는 value 반환
        return this.checkPointInfoDictionary[_id];
    }
    public bool IsExist(string _id)
    {
        // 키값에 해당되는 key 존재여부
        return this.checkPointInfoDictionary.ContainsKey(_id);
    }

    public int GetLength() 
    {
        return this.checkPointInfoDictionary.Count;
    }

    public void AddInfo(CheckPointTableData _data)
    {   
        CheckPointInfo checkPointInfo = new CheckPointInfo(_data);
        this.checkPointInfoDictionary.Add(checkPointInfo.id, checkPointInfo);
    }
}
