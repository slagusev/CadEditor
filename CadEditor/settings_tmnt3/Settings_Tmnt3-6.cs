using CadEditor;
using System;
using System.Drawing;

public class Data 
{ 
  public GameType getGameType()       { return GameType.Generic; }
  public OffsetRec getScreensOffset() { return new OffsetRec(0x32603, 15, 8*6); }
  public int getScreenWidth()         { return 8; }
  public int getScreenHeight()        { return 6; }
  public string getBlocksFilename()   { return "settings_tmnt3/tmnt3_6.png"; }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return false; }
  public bool isLayoutEditorEnabled()   { return false; }
  public bool isEnemyEditorEnabled()    { return false; }
  public bool isVideoEditorEnabled()    { return false; }
}