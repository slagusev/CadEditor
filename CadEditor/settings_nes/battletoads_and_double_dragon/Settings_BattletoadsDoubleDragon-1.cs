using CadEditor;
using System;
using System.Drawing;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x2C8A0, 1 , 72*8, 72, 8);   }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return getVideoAddress; }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return getVideoChunk;   }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x2cae0 , 1  , 0x1000);  }
  public int getBlocksCount()           { return 155; }
  public int getBigBlocksCount()        { return 155; }
  public int getPalBytesAddr()          { return 0x2d490; }
  public GetBlocksFunc        getBlocksFunc() { return Utils.getBlocksFromTiles16Pal1;}
  public SetBlocksFunc        setBlocksFunc() { return Utils.setBlocksFromTiles16Pal1;}
  
  public GetPalFunc           getPalFunc()           { return getPallete;}
  public SetPalFunc           setPalFunc()           { return null;}
  
  /*public LoadPhysicsLayer loadPhysicsLayerFunc() { return loadPhysicsLayer; }
  public SavePhysicsLayer savePhysicsLayerFunc() { return savePhysicsLayer; }
  public int getPhysicsBlocksCount() { return 16; }*/
  
  //----------------------------------------------------------------------------
  public int getVideoAddress(int id)
  {
    return -1;
  }
  
  public byte[] getVideoChunk(int videoPageId)
  {
     return Utils.readVideoBankFromFile("ppu_dump1.bin", videoPageId);
  }
  
  public byte[] getPallete(int palId)
  {
      return Utils.readBinFile("pal1.bin");
  }
  
  /*int[] loadPhysicsLayer(int scrNo)
  {
    int width = getScreensOffset().width;
    int height = getScreensOffset().height;
    int size = width*height;
    int physicsAddr = 0x2ba82;
    int lineLen = 4;
    
    var ans = new int[size];
    for (int line = 0; line < width; line++)
    {
       var lineBytes = new int[lineLen];
       for(int lb = 0; lb < lineLen; lb++)
       {
         lineBytes[lb] = Globals.romdata[physicsAddr + line * lineLen + lb];
       }
       ans[0 * width + line]  = lineBytes[3] & 0x0F;
       ans[1 * width + line]  = lineBytes[3] >> 4;
       ans[2 * width + line]  = lineBytes[2] & 0x0F;
       ans[3 * width + line]  = lineBytes[2] >> 4;
       ans[4 * width + line]  = lineBytes[1] & 0x0F;
       ans[5 * width + line]  = lineBytes[1] >> 4;
       ans[6 * width + line]  = lineBytes[0] & 0x0F;
       ans[7 * width + line]  = lineBytes[0] >> 4; 
    }
    return ans;
  }
  
  void savePhysicsLayer(int scrNo, int[] data)
  {
    int width = getScreensOffset().width;
    int height = getScreensOffset().height;
    int size = width*height;
    int physicsAddr = 0x2ba82;
    int lineLen = 4;
    
    for (int line = 0; line < width; line++)
    {
       var lineBytes = new int[lineLen];
       lineBytes[0] = data[7 * width + line] << 4 | data[6 * width + line];
       lineBytes[1] = data[5 * width + line] << 4 | data[4 * width + line];
       lineBytes[2] = data[3 * width + line] << 4 | data[2 * width + line];
       lineBytes[3] = data[1 * width + line] << 4 | data[0 * width + line];
       for(int lb = 0; lb < lineLen; lb++)
       {
          Globals.romdata[physicsAddr + line * lineLen + lb] = (byte)lineBytes[lb];
       }
    }
  }*/
}