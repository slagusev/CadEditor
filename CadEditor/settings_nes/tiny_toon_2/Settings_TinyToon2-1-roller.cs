using CadEditor;
using System;
//css_include tiny_toon_2/TT2Utils.cs;
//css_include shared_settings/SharedUtils.cs;

public class Data 
{
  public OffsetRec[] getScreensOffsetsForLevels() {
    var ans = new OffsetRec[] {
      new OffsetRec(0x9235, 19 , 16*12, 16, 12),
      new OffsetRec(0x8065, 19 , 16*15, 16, 15),
    };
    return ans;  
  }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return SharedUtils.fakeVideoAddr(); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return SharedUtils.getVideoChunk("chr1.bin");   }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xa075, 1  , 0x1000);  }
  public int getBlocksCount()           { return 128; }
  public int getBigBlocksCount()        { return 128; }
  public int getPalBytesAddr()          { return 0xa26d; }
  
  public GetBlocksFunc        getBlocksFunc() { return TT2Utils.getBlocks;}
  public SetBlocksFunc        setBlocksFunc() { return TT2Utils.setBlocks;}
  public GetPalFunc           getPalFunc()           { return SharedUtils.readPalFromBin("pal1.bin"); }
  public SetPalFunc           setPalFunc()           { return null;}
}