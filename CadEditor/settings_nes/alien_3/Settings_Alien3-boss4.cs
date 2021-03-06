using CadEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset() { return new OffsetRec(0xd471, 1, 64*22, 64, 22); }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public OffsetRec getVideoOffset()   { return new OffsetRec(0x27010, 1, 0x1000); }
  public OffsetRec getPalOffset()     { return new OffsetRec(0xD252,  1, 16   ); }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xC2D0, 1  , 0x1000);  }
  public int getBlocksCount()           { return 229; }
  public int getBigBlocksCount()           { return 229; }
  public int getPalBytesAddr()          { return 0xC2D0+229*16; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc()         { return Utils.getChrAddress; }
  public GetVideoChunkFunc    getVideoChunkFunc()            { return Utils.getVideoChunk; }
  public SetVideoChunkFunc    setVideoChunkFunc()            { return Utils.setVideoChunk; }
  public GetBlocksFunc        getBlocksFunc() { return Utils.getBlocksFromTiles16Pal1;}
  public SetBlocksFunc        setBlocksFunc() { return Utils.setBlocksFromTiles16Pal1;}
  public GetPalFunc           getPalFunc() { return Utils.getPalleteLinear;}
  public SetPalFunc           setPalFunc() { return Utils.setPalleteLinear;}
  //-------------------------------------------------------------------------------
}