using CadEditor;
using System;
using System.Drawing;

public class Data 
{ 
  public OffsetRec getScreensOffset() { return new OffsetRec(0x10, 16, 8*8, 8, 8); }
  
  public bool isBigBlockEditorEnabled() { return true; }
  public bool isBlockEditorEnabled()    { return false; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return getVideoAddress; }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return getVideoChunk;   }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0, 1 , 0x1000);  }
  public int getBlocksCount()           { return 64; }
  
  public GetBigBlocksFunc     getBigBlocksFunc() { return getBigBlocks;}
  public SetBigBlocksFunc     setBigBlocksFunc() { return setBigBlocks;}
  public GetBlocksFunc        getBlocksFunc() { return getBlocksConsts;}
  public SetBlocksFunc        setBlocksFunc() { return null;}
  public GetPalFunc           getPalFunc()    { return getPallete;}
  public SetPalFunc           setPalFunc()    { return null;}
  
  public LoadPhysicsLayer loadPhysicsLayerFunc() { return loadPhysicsLayer; }
  public SavePhysicsLayer savePhysicsLayerFunc() { return savePhysicsLayer; }
  
  public OffsetRec getBigBlocksOffset() { return new OffsetRec(0x5810, 1 , 0x4000); }
  public int getPalBytesAddr()          { return 0xA610; }
  public int getBigBlocksCount() { return 229; }
 
  //----------------------------------------------------------------------------
  public ObjRec[] getBlocksConsts(int blockIndex)
  {
        var objects = new ObjRec[getBlocksCount()];
        for (int i = 0; i < objects.Length; i++)
        {
            var indexes  = new int[4];
            var palBytes = new int[1];
            int bi = (i/8)*32 + i%8 * 2;
            indexes[0] = bi;
            indexes[1] = bi + 1;
            indexes[2] = bi + 16;
            indexes[3] = bi + 17;
            objects[i] = new ObjRec(2, 2, 0, indexes, palBytes);
        }
        return objects;
  }
  
  public BigBlock[] getBigBlocks(int bigTileIndex)
  {
    var data = Utils.readLinearBigBlockData(0, bigTileIndex);
    var bb = Utils.unlinearizeBigBlocks<BigBlockWithPal>(data, 2, 2);
    for (int i = 0; i < bb.Length; i++)
    {
      int palByte = Globals.romdata[getPalBytesAddr() + i];
      bb[i].palBytes[0] = palByte >> 0 & 0x3;
      bb[i].palBytes[1] = palByte >> 2 & 0x3;
      bb[i].palBytes[2] = palByte >> 4 & 0x3;
      bb[i].palBytes[3] = palByte >> 6 & 0x3;
      
      for (int ind = 0; ind < bb[i].indexes.Length; ind++)
      {
          bb[i].indexes[ind] = bb[i].indexes[ind] & 0x3F; //read only 6 bits
      }
    }
    return bb;
  }
  
  public void setBigBlocks(int bigTileIndex, BigBlock[] bigBlockIndexes)
  {
    var bigBlocksAddr = ConfigScript.getBigTilesAddr(0, bigTileIndex);
    var data = Utils.linearizeBigBlocks(bigBlockIndexes);
    
    //write only first 6 bits of block info (first 2 are physics info)
    int size = data.Length;
    int addr = ConfigScript.getBigTilesAddr(0, bigTileIndex);
    for (int i = 0; i < size; i++)
    {
        int mask = Globals.romdata[addr + i] & 0xC0;
        Globals.romdata[addr + i] =  (byte)(mask | data[i]);
    }
    //save pal bytes
    for (int i = 0; i < bigBlockIndexes.Length; i++)
    {
      var bb = bigBlockIndexes[i] as BigBlockWithPal;
      int palByte = bb.palBytes[0] | bb.palBytes[1] << 2 | bb.palBytes[2]<<4 | bb.palBytes[3]<< 6;
      Globals.romdata[getPalBytesAddr() + i] = (byte)palByte;
    }
  }
  
  int[] loadPhysicsLayer(int scrNo)
  {
    int w = getScreensOffset().width;
    int h = getScreensOffset().height;
    int size = w*h;
    int physicsAddr = 0xC010 + scrNo * size;
    
    var ans = new int[size];
    for (int i = 0; i < size; i++)
    {
       ans[i] = Globals.romdata[physicsAddr + i];
    }
    return ans;
  }
  
  void savePhysicsLayer(int scrNo, int[] data)
  {
    int w = getScreensOffset().width;
    int h = getScreensOffset().height;
    int size = w*h;
    int physicsAddr = 0xC010 + scrNo * size;
    for (int i = 0; i < size; i++)
    {
       Globals.romdata[physicsAddr + i] = (byte)data[i];
    }
  }
  
  public byte[] getPallete(int palId)
  {
      return Utils.readBinFile("pal1.bin");
  }
  
  public int getVideoAddress(int id)
  {
    return -1;
  }
  
  public byte[] getVideoChunk(int videoPageId)
  {
     return Utils.readVideoBankFromFile("chr1.bin", videoPageId);
  }
}