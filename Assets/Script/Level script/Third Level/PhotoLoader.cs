using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoLoader : MonoBehaviour
{
    public GameObject album;
    public List<GameObject> photos;
    public List<GameObject> replacePhotos;
    public List<GameObject> thoughtBubbles;
    public int photosTaken;
    public GameObject scene;



    public void TakePhoto()
    {
        photosTaken++;
    }

    public void PhotoLoop()
    {
        album.SetActive(true);
        for (int i = 0; i < photosTaken; ++i)
        {
            replacePhotos[i].SetActive(true);
            photos[i].SetActive(true);
            thoughtBubbles[i].SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            PhotoLoop();

        }
        if(scene.gameObject.activeSelf)
        {
            PhotoLoop();
        }
    }
}
