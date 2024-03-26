using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Texture2DExtension
{
    public static Sprite CreateSpriteOutOfTexture (this Texture2D texture) {
        Sprite tst = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), new Vector2 (0f, 0f), 100f);
        return tst;
    }
    public static void Save_Screenshot (this Texture2D screenshot, string postFixName, string extension) {
        string screenShotPath = Application.persistentDataPath + "/" + DateTime.Now.ToString ("dd-MM-yyyy_HH:mm:ss") + "_" + postFixName + extension;
        File.WriteAllBytes (screenShotPath, screenshot.EncodeToPNG ());
        Debug.Log (screenShotPath);
    }
}
