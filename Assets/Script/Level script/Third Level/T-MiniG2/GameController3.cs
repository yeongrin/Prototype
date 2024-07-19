using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController3 : MonoBehaviour
{
    public GameObject flashObject;
    public IEnumerator CameraFlash()
    {
        yield return new WaitForSeconds(0.1f);
        flashObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        flashObject.SetActive(false);
    }
}
