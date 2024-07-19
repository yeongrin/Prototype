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
    int maxAllowedScreenshots = 5;
    int nextScreenshotIndex = 0;

    public List<Sprite> screenshots = new List<Sprite>();

    void Start()
    {
        DeleteAllInFolder();
    }

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
        if (nextScreenshotIndex < maxAllowedScreenshots)
        {
            ScreenCapture.CaptureScreenshot(Application.dataPath + "/Screenshots/" + "Level3Screenshot" + nextScreenshotIndex + ".png");
            nextScreenshotIndex++;
        }
        else
            return;
    }
}
