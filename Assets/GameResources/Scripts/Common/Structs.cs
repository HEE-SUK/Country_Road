

public struct BlockObjectSettingInfo{
    public int themeIndex;
    public bool isCrossWalk;
    public bool isWallActive;
    public int wallIndex;
    public WallInfo wallInfo;
    public BlockObjectSettingInfo(int themeIndex,bool isCrossWalk,bool isWallActive, int wallIndex,WallInfo wallInfo){
        this.themeIndex = themeIndex;
        this.isCrossWalk = isCrossWalk;
        this.isWallActive = isWallActive;
        this.wallIndex = wallIndex;
        this.wallInfo = wallInfo;
    }
}
