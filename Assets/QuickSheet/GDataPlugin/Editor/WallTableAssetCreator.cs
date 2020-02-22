using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/WallTable")]
    public static void CreateWallTableAssetFile()
    {
        WallTable asset = CustomAssetUtility.CreateAsset<WallTable>();
        asset.SheetName = "CountryRoad";
        asset.WorksheetName = "WallTable";
        EditorUtility.SetDirty(asset);        
    }
    
}