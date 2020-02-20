using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInfoTable : IInfoTable<ZombieInfo, ZombieTableData>
{
    private Dictionary<string, ZombieInfo> zombieInfoDictionary = new Dictionary<string, ZombieInfo>();

    private string tableName = "ZombieTable";
    public ZombieInfoTable()
    {
        ZombieTable zombieTable = Resources.Load($"DataTable/{this.tableName}", typeof(ZombieTable)) as ZombieTable;
        foreach (var data in zombieTable.dataArray)
        {
            this.AddInfo(data);
        }
    }
    
    public ZombieInfo GetInfo(string _id)
    {
        // 키값에 해당되는 value 반환
        return this.zombieInfoDictionary[_id];
    }
    public bool IsExist(string _id)
    {
        // 키값에 해당되는 key 존재여부
        return this.zombieInfoDictionary.ContainsKey(_id);
    }

    public int GetLength() 
    {
        return this.zombieInfoDictionary.Count;
    }

    public void AddInfo(ZombieTableData _data)
    {   
        ZombieInfo zombieInfo = new ZombieInfo(_data);
        this.zombieInfoDictionary.Add(zombieInfo.id, zombieInfo);
    }
}
