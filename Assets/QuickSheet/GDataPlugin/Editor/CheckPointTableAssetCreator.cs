using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/CheckPointTable")]
    public static void CreateCheckPointTableAssetFile()
    {
        CheckPointTable asset = CustomAssetUtility.CreateAsset<CheckPointTable>();
        asset.SheetName = "좀비카 레이싱";
        asset.WorksheetName = "CheckPointTable";
        EditorUtility.SetDirty(asset);        
    }
    
}