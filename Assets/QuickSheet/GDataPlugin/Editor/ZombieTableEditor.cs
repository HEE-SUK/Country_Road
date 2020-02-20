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
[CustomEditor(typeof(ZombieTable))]
public class ZombieTableEditor : BaseGoogleEditor<ZombieTable>
{	    
    public override bool Load()
    {        
        ZombieTable targetData = target as ZombieTable;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<ZombieTableData>(targetData.WorksheetName) ?? db.CreateTable<ZombieTableData>(targetData.WorksheetName);
        
        List<ZombieTableData> myDataList = new List<ZombieTableData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            ZombieTableData data = new ZombieTableData();
            
            data = Cloner.DeepCopy<ZombieTableData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
