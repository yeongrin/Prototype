using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TransitionVideoOfMiniGame2 : MonoBehaviour
{
    public enum WhichCursor { On, Off}

    public VideoPlayer transitionVid; //Transition video
    public GameObject transitionVidOb;
    public GameObject game2;
    public GameObject lastMinigame;
    public GameObject nextBackground;
    public GameObject gameThingy;

    public WhichCursor cursor;

    CursorState _cs;

    void Start()
    {
        _cs = FindObjectOfType<CursorState>();
        transitionVid.loopPointReached += CheckOver;
        transitionVid.Play();
        if (nextBackground != null)
        {
            print("next");
            StartCoroutine(Wait());
            
        }
        else
            return;
        
        
    }

    
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        //Spawning flies when video is over
        transitionVidOb.SetActive(false);
        if(cursor == WhichCursor.On)
        {
            _cs.showCursor = CursorState.CursorShowing.Invisible;
        }
        else 
            _cs.showCursor = CursorState.CursorShowing.Visible;

        
     
        if (gameThingy != null)
        {
            gameThingy.SetActive(true);
        }
        else
            return;
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        
        if (lastMinigame != null)
        {
            new WaitForSeconds(1f);
            lastMinigame.SetActive(false);
        }
        else
            yield return null;
        new WaitForSeconds(3f);
        nextBackground.SetActive(true);
        game2.SetActive(true);
    }
}
