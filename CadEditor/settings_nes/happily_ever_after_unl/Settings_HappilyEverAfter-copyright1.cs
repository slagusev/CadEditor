using CadEditor;
using System;
//css_include shared_settings/SharedUtils.cs;
//css_include shared_settings/BlockUtils.cs;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x7006, 1 , 16*15, 16, 15);   }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return SharedUtils.fakeVideoAddr(); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return SharedUtils.getVideoChunk("chr-copy.bin");    }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x6e42, 1  , 0x1000);  }
  public int getBlocksCount()           { return 256; }
  public int getBigBlocksCount()        { return 256; }
  public int getPalBytesAddr()          { return 0x6f92; }
  
  public GetBlocksFunc        getBlocksFunc() { return BlockUtils.getBlocksLinear2x2Masked;}
  public SetBlocksFunc        setBlocksFunc() { return BlockUtils.setBlocksLinear2x2Masked;}
  public GetPalFunc           getPalFunc()           { return SharedUtils.readPalFromBin(new[] {"pal-copy.bin"}); }
  public SetPalFunc           setPalFunc()           { return null;}
}