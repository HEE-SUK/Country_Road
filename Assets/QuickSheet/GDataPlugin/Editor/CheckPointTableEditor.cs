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
[CustomEditor(typeof(CheckPointTable))]
public class CheckPointTableEditor : BaseGoogleEditor<CheckPointTable>
{	    
    public override bool Load()
    {        
        CheckPointTable targetData = target as CheckPointTable;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<CheckPointTableData>(targetData.WorksheetName) ?? db.CreateTable<CheckPointTableData>(targetData.WorksheetName);
        
        List<CheckPointTableData> myDataList = new List<CheckPointTableData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            CheckPointTableData data = new CheckPointTableData();
            
            data = Cloner.DeepCopy<CheckPointTableData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
