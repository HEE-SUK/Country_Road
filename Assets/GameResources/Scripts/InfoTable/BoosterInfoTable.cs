using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterInfoTable : InfoTable<BoosterInfo>
{

    private string tableName = "BoosterTable";
    public BoosterInfoTable()
    {
        BoosterTable boosterTable = Resources.Load($"DataTable/{this.tableName}", typeof(BoosterTable)) as BoosterTable;
        foreach (var data in boosterTable.dataArray)
        {
            this.AddInfo(data);
        }
    }
    public void AddInfo(BoosterTableData _data)
    {   
        BoosterInfo boosterInfo = new BoosterInfo(_data);
        this.infoDictionary.Add(boosterInfo.id, boosterInfo);
    }
}
