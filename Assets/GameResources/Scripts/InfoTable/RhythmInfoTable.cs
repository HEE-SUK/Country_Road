using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmInfoTable : InfoTable<RhythmInfo>
{

    private string tableName = "RhythmTable";
    public RhythmInfoTable()
    {
        RhythmTable rhythmTable = Resources.Load($"DataTable/{this.tableName}", typeof(RhythmTable)) as RhythmTable;
        foreach (var data in rhythmTable.dataArray)
        {
            this.AddInfo(data);
        }
    }
    public void AddInfo(RhythmTableData _data)
    {   
        RhythmInfo rhythmInfo = new RhythmInfo(_data);
        this.infoDictionary.Add(rhythmInfo.id, rhythmInfo);
    }
}
