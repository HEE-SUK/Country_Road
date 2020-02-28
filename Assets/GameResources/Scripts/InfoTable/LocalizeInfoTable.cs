using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizeInfoTable : InfoTable<LocalizeInfo>
{
    private string tableName = "LocalizeTable";
    public LocalizeInfoTable()
    {
        LocalizeTable localizeTable = Resources.Load($"DataTable/{this.tableName}", typeof(LocalizeTable)) as LocalizeTable;
        foreach (var data in localizeTable.dataArray)
        {
            this.AddInfo(data);
        }
    }
    public void AddInfo(LocalizeTableData _data)
    {   
        LocalizeInfo localizeInfo = new LocalizeInfo(_data);
        this.infoDictionary.Add(localizeInfo.id, localizeInfo);
    }
}
