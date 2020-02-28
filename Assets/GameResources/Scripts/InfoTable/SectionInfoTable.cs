using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionInfoTable : InfoTable<SectionInfo>
{
    private string tableName = "SectionTable";
    public SectionInfoTable()
    {
        SectionTable sectionTable = Resources.Load($"DataTable/{this.tableName}", typeof(SectionTable)) as SectionTable;
        foreach (var data in sectionTable.dataArray)
        {
            this.AddInfo(data);
        }
    }
    public void AddInfo(SectionTableData _data)
    {   
        SectionInfo sectionInfo = new SectionInfo(_data);
        this.infoDictionary.Add(sectionInfo.id, sectionInfo);
    }
}
