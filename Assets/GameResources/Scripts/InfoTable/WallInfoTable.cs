using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallInfoTable : IInfoTable<WallInfo, WallTableData>
{
    private Dictionary<string, WallInfo> wallInfoDictionary = new Dictionary<string, WallInfo>();

    private string tableName = "WallTable";
    public WallInfoTable()
    {
        WallTable wallTable = Resources.Load($"DataTable/{this.tableName}", typeof(WallTable)) as WallTable;
        foreach (var data in wallTable.dataArray)
        {
            this.AddInfo(data);
        }
    }
    
    public WallInfo GetInfo(string _id)
    {
        // 키값에 해당되는 value 반환
        return this.wallInfoDictionary[_id];
    }
    public bool IsExist(string _id)
    {
        // 키값에 해당되는 key 존재여부
        return this.wallInfoDictionary.ContainsKey(_id);
    }

    public int GetLength() 
    {
        return this.wallInfoDictionary.Count;
    }

    public void AddInfo(WallTableData _data)
    {   
        WallInfo wallInfo = new WallInfo(_data);
        this.wallInfoDictionary.Add(wallInfo.id, wallInfo);
    }
}
