using CadEditor;
using System;
//css_include tiny_toon_2/TT2Utils.cs;
//css_include shared_settings/SharedUtils.cs;

public class Data 
{  
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x29df, 1 , 16*21, 16, 21);   }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return SharedUtils.fakeVideoAddr(); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return SharedUtils.getVideoChunk("chr5.bin");   }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x3ec3, 1  , 0x1000);  }
  public int getBlocksCount()           { return 80; }
  public int getBigBlocksCount()        { return 80; }
  public int getPalBytesAddr()          { return 0x3ffb; }
  
  public GetBlocksFunc        getBlocksFunc() { return TT2Utils.getBlocks;}
  public SetBlocksFunc        setBlocksFunc() { return TT2Utils.setBlocks;}
  public GetPalFunc           getPalFunc()           { return SharedUtils.readPalFromBin("pal5.bin"); }
  public SetPalFunc           setPalFunc()           { return null;}
}