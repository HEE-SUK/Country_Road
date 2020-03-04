using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/BoosterTable")]
    public static void CreateBoosterTableAssetFile()
    {
        BoosterTable asset = CustomAssetUtility.CreateAsset<BoosterTable>();
        asset.SheetName = "CountryRoad";
        asset.WorksheetName = "BoosterTable";
        EditorUtility.SetDirty(asset);        
    }
    
}