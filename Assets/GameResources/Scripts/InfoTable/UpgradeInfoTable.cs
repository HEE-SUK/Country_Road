using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeInfoTable : InfoTable<UpgradeInfo>
{
    private string tableName = "UpgradeTable";
    public UpgradeInfoTable()
    {
        UpgradeTable upgradeTable = Resources.Load($"DataTable/{this.tableName}", typeof(UpgradeTable)) as UpgradeTable;
        foreach (var data in upgradeTable.dataArray)
        {
            this.AddInfo(data);
        }
    }
    public void AddInfo(UpgradeTableData _data)
    {   
        UpgradeInfo upgradeInfo = new UpgradeInfo(_data);
        this.infoDictionary.Add(upgradeInfo.id, upgradeInfo);
    }
}
