using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/ZombieTable")]
    public static void CreateZombieTableAssetFile()
    {
        ZombieTable asset = CustomAssetUtility.CreateAsset<ZombieTable>();
        asset.SheetName = "CountryRoad";
        asset.WorksheetName = "ZombieTable";
        EditorUtility.SetDirty(asset);        
    }
    
}