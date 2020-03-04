using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/UpgradeTable")]
    public static void CreateUpgradeTableAssetFile()
    {
        UpgradeTable asset = CustomAssetUtility.CreateAsset<UpgradeTable>();
        asset.SheetName = "CountryRoad";
        asset.WorksheetName = "UpgradeTable";
        EditorUtility.SetDirty(asset);        
    }
    
}