using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/CarTable")]
    public static void CreateCarTableAssetFile()
    {
        CarTable asset = CustomAssetUtility.CreateAsset<CarTable>();
        asset.SheetName = "CountryRoad";
        asset.WorksheetName = "CarTable";
        EditorUtility.SetDirty(asset);        
    }
    
}