using CadEditor;
using System;
using PluginMapEditor;
//css_include circus_caper/CircusCaperUtils.cs;
//css_include shared_settings/SharedUtils.cs;

public class Data 
{
  public string[] getPluginNames() 
  {
    return new string[] 
    {
      "PluginMapEditor.dll",
    };
  }
  
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x8688, 1 , 16*12, 16, 12);   }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return SharedUtils.fakeVideoAddr(); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return SharedUtils.getVideoChunk("chr1(b).bin");   }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x8208, 1  , 0x1000);  }
  public int getBlocksCount()           { return 128; }
  public int getBigBlocksCount()        { return 128; }
  public int getPalBytesAddr()          { return 0x8b08+1; }
  
  public GetBlocksFunc        getBlocksFunc() { return Utils.getBlocksLinear2x2withoutAttrib;}
  public SetBlocksFunc        setBlocksFunc() { return Utils.setBlocksLinearWithoutAttrib;}
  public GetPalFunc           getPalFunc()           { return SharedUtils.readPalFromBin("pal4(b).bin"); }
  public SetPalFunc           setPalFunc()           { return null;}
  //----------------------------------------------------------------------------
  public MapInfo[] getMapsInfo()      { return CircusCaperUtils.makeMapsInfo(); }
  public LoadMapFunc getLoadMapFunc() { return CircusCaperUtils.loadMap; }
  public SaveMapFunc getSaveMapFunc() { return CircusCaperUtils.saveAttribsT; }
  public bool isMapReadOnly()         { return true; }
  public bool mapEditorSharePallete() { return true; }
  //----------------------------------------------------------------------------
}