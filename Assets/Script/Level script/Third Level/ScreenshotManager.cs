using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ScreenshotManager : MonoBehaviour
{

    void DeleteAllInFolder()
    {
        string[] photoFolder = { "Assets/Screenshots" };
        foreach(var photo in AssetDatabase.FindAssets("", photoFolder))
        {
            var path = AssetDatabase.GUIDToAssetPath(photo);
            AssetDatabase.DeleteAsset(path);
        }
    }

    public void TakeScreenshot()
    {
         ScreenCapture.CaptureScreenshot(Application.dataPath + "/Screenshots/" + "Level3Screenshot.png");
    }

    public void DeletePhoto()
    {
        DeleteAllInFolder();
    }
}
