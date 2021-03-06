using CadEditor;
using System.Collections.Generic;
//css_include tiny_toon/TinyToon-Utils.cs;

public class Data
{ 
  public OffsetRec getPalOffset()       { return new OffsetRec(0xB1F0, 16, 16        ) ;}
  public OffsetRec getVideoOffset()     { return new OffsetRec(0x4D10 , 1   , 0xD00  ) ;}
  public OffsetRec getVideoObjOffset()  { return new OffsetRec(0x4D10 , 1   , 0xD00  ) ;}
  public OffsetRec getBigBlocksOffset() { return new OffsetRec(0x75C8 , 1   , 0x4000 ) ;}
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x1F1CB, 1   , 0x440  ) ;}
  public OffsetRec getScreensOffset()   { return new OffsetRec(0x7408 , 4   , 112 , 8, 14) ;}
  public int getBigBlocksCount()        { return 53; }
  public GetLevelRecsFunc getLevelRecsFunc() { return ()=> {return levelRecsTT;}; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return getTinyToonVideoAddress; }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return getTinyToonVideoChunk;   }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  public GetBigBlocksFunc     getBigBlocksFunc()     { return TinyToonUtils.getBigBlocksTT;}
  public SetBigBlocksFunc     setBigBlocksFunc()     { return TinyToonUtils.setBigBlocksTT;}
  public GetBlocksFunc        getBlocksFunc()        { return TinyToonUtils.getBlocks;}
  public SetBlocksFunc        setBlocksFunc()        { return TinyToonUtils.setBlocks;}
  public GetPalFunc           getPalFunc()           { return getPalleteLevel_3_3;}
  public SetPalFunc           setPalFunc()           { return null;}
  public GetObjectsFunc getObjectsFunc() { return TinyToonUtils.getObjectsTT; }
  public SetObjectsFunc setObjectsFunc() { return TinyToonUtils.setObjectsTT; }
  public string getObjTypesPicturesDir() { return "obj_sprites_TT"; }
  public GetLayoutFunc  getLayoutFunc()  { return TinyToonUtils.getLayoutLinearTT;   }
  
  public IList<LevelRec> levelRecsTT = new List<LevelRec>() 
  {
    new LevelRec(0x14683, 5, 4, 1, 0x0),
  };
  
  public int getTinyToonVideoAddress(int id)
  {
    return -1;
  }
  
  public byte[] getTinyToonVideoChunk(int videoPageId)
  {
    return Utils.readVideoBankFromFile("videoBack_TT_33.bin", videoPageId);
  }
  
  public byte[] getPalleteLevel_3_3(int palId)
  {
    var pallete = new byte[] { 
      0x0f, 0x0F, 0x26, 0x2A, 0x0f, 0x0f, 0x13, 0x03,
      0x0f, 0x0F, 0x37, 0x18, 0x0f, 0x0f, 0x20, 0x38
    }; 
    return pallete;
  }
  
  public bool isBigBlockEditorEnabled() { return true;  }
  public bool isBlockEditorEnabled()    { return true;  }
  public bool isEnemyEditorEnabled()    { return true; }
  //--------------------------------------------------------------------------------------------
}