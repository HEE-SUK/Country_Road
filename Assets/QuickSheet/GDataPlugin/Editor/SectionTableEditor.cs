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
[CustomEditor(typeof(SectionTable))]
public class SectionTableEditor : BaseGoogleEditor<SectionTable>
{	    
    public override bool Load()
    {        
        SectionTable targetData = target as SectionTable;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<SectionTableData>(targetData.WorksheetName) ?? db.CreateTable<SectionTableData>(targetData.WorksheetName);
        
        List<SectionTableData> myDataList = new List<SectionTableData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            SectionTableData data = new SectionTableData();
            
            data = Cloner.DeepCopy<SectionTableData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
