using CadEditor;
using System.Collections.Generic;
using System.IO;
using System;
using System.Windows.Forms;

public class Data
{
  public GameType getGameType()  { return GameType.TT; }
  
  public OffsetRec getPalOffset()       { return new OffsetRec(0xB1F0, 16, 16        ) ;}
  public OffsetRec getVideoOffset()     { return new OffsetRec(0x4D10 , 1   , 0xD00  ) ;}
  public OffsetRec getVideoObjOffset()  { return new OffsetRec(0x4D10 , 1   , 0xD00  ) ;}
  public OffsetRec getBigBlocksOffset() { return new OffsetRec(0x99BF , 1   , 0x4000 ) ;}
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x1F1CB, 1   , 0x440  ) ;}
  public OffsetRec getScreensOffset()   { return new OffsetRec(0x98CF , 5   , 48 ) ;}
  public int getBigBlocksCount()        { return 22; }
  public int getScreenWidth()           { return 8; }
  public int getScreenHeight()          { return 6; }
  public IList<LevelRec> getLevelRecs() { return levelRecsTT; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return getTinyToonVideoAddress; }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return getTinyToonVideoChunk;   }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  public GetBigBlocksFunc     getBigBlocksFunc()     { return getBigBlocksTT;}
  public SetBigBlocksFunc     setBigBlocksFunc()     { return null;}
  public GetPalFunc           getPalFunc()           { return getPalleteLevel_5_1;}
  public SetPalFunc           setPalFunc()           { return null;}
  
  public IList<LevelRec> levelRecsTT = new List<LevelRec>() 
  {
    new LevelRec(0x0, 1, 8, 6, 0x0),
  };
  
  public int getTinyToonVideoAddress(int id)
  {
    return -1;
  }
  
  public byte[] getTinyToonVideoChunk(int videoPageId)
  {
    try
    {
        using (FileStream f = File.OpenRead("videoBack_TT_62.bin"))
        {
            byte[] videodata = new byte[0x1000];
            f.Read(videodata, 0, 0x1000);
            byte[] ans = new byte[0x1000];
            int offset = (videoPageId - 0x90)*0x1000;
            for (int i = 0; i < ans.Length; i++)
                ans[i] = videodata[offset + i];
            return ans;
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    return null;
  }
  
  public byte[] getBigBlocksTT(int bigTileIndex)
  {
    byte[] bigBlockIndexes = new byte[getBigBlocksCount() * 4];
    var bigBlocksAddr = Globals.getBigTilesAddr(bigTileIndex);
    int btc = getBigBlocksCount();
    for (int i = 0; i < btc; i++)
    {
      bigBlockIndexes[i*4+0] = Globals.romdata[bigBlocksAddr + btc*0 + i];
      bigBlockIndexes[i*4+1] = Globals.romdata[bigBlocksAddr + btc*1 + i];
      bigBlockIndexes[i*4+2] = Globals.romdata[bigBlocksAddr + btc*2 + i];
      bigBlockIndexes[i*4+3] = Globals.romdata[bigBlocksAddr + btc*3 + i];
      // BLOCK_COLOR_BYTE_ARRAY[i] = Globals.romdata[bigBlocksAddr + btc*4 + i];
    }
    return bigBlockIndexes;
  }
  
  public byte[] getPalleteLevel_5_1(int palId)
  {
    var pallete = new byte[] { 
      0x03, 0x0F, 0x00, 0x00, 0x03, 0x0f, 0x20, 0x10,
      0x03, 0x0F, 0x20, 0x21, 0x03, 0x0f, 0x20, 0x38
    }; 
    return pallete;
  }
  
  public bool isBigBlockEditorEnabled() { return true;  }
  public bool isBlockEditorEnabled()    { return true;  }
  public bool isLayoutEditorEnabled()   { return false; }
  public bool isEnemyEditorEnabled()    { return false; }
  public bool isVideoEditorEnabled()    { return true; }
  //--------------------------------------------------------------------------------------------
}