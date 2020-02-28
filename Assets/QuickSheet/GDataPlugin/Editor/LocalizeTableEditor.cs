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
[CustomEditor(typeof(LocalizeTable))]
public class LocalizeTableEditor : BaseGoogleEditor<LocalizeTable>
{	    
    public override bool Load()
    {        
        LocalizeTable targetData = target as LocalizeTable;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<LocalizeTableData>(targetData.WorksheetName) ?? db.CreateTable<LocalizeTableData>(targetData.WorksheetName);
        
        List<LocalizeTableData> myDataList = new List<LocalizeTableData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            LocalizeTableData data = new LocalizeTableData();
            
            data = Cloner.DeepCopy<LocalizeTableData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
