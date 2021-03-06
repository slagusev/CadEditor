using CadEditor;
using System;
//css_include shared_settings/BlockUtils.cs;
//css_include shared_settings/SharedUtils.cs;

public class Data 
{ 
  public OffsetRec getScreensOffset() { return new OffsetRec(0x14010, 1, 96*80, 96, 80); }
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return SharedUtils.fakeVideoAddr(); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return SharedUtils.getVideoChunk(new[] {"chr6.bin", "chr6-2.bin"}); }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  public OffsetRec getVideoOffset()     { return new OffsetRec(0x0 , 2   , 0x1000);  }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x15e10, 1  , 0x1000);  }
  public int getBlocksCount()           { return 256; }
  public int getBigBlocksCount()        { return 256; }
  public int getPalBytesAddr()          { return 0x15e10 + 256*4; }
  
  public GetBlocksFunc        getBlocksFunc() { return BlockUtils.getBlocksFromAlignedArrays;}
  public SetBlocksFunc        setBlocksFunc() { return BlockUtils.setBlocksToAlignedArrays;}
  public GetPalFunc           getPalFunc()           { return SharedUtils.readPalFromBin(new[] {"pal6.bin"}); }
  public SetPalFunc           setPalFunc()           { return null;}
}