

public struct BlockObjectSettingInfo{
    public int themeIndex;
    public bool isWallActive;
    public WallInfo wallInfo;
    public BlockObjectSettingInfo(int themeIndex,bool isWallActive,WallInfo wallInfo){
        this.themeIndex = themeIndex;
        this.isWallActive = isWallActive;
        this.wallInfo = wallInfo;
    }
}
