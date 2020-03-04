using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(UpgradeTable))]
public class UpgradeTableEditor : BaseGoogleEditor<UpgradeTable>
{	    
    public override bool Load()
    {        
        UpgradeTable targetData = target as UpgradeTable;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<UpgradeTableData>(targetData.WorksheetName) ?? db.CreateTable<UpgradeTableData>(targetData.WorksheetName);
        
        List<UpgradeTableData> myDataList = new List<UpgradeTableData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            UpgradeTableData data = new UpgradeTableData();
            
            data = Cloner.DeepCopy<UpgradeTableData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
