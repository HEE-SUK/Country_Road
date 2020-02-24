

public struct BlockObjectSettingInfo{
    public int themeIndex;
    public bool isCrossWalk;
    public bool isWallActive;
    public WallInfo wallInfo;
    public BlockObjectSettingInfo(int themeIndex,bool isCrossWalk,bool isWallActive,WallInfo wallInfo){
        this.themeIndex = themeIndex;
        this.isCrossWalk = isCrossWalk;
        this.isWallActive = isWallActive;
        this.wallInfo = wallInfo;
    }
}
