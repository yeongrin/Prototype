using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBubble : MonoBehaviour
{

    public bool isShaking = false;
    public Transform startPos;
    public float shakeAmount;
    
    void Update()
    {

        if (isShaking)
        {
            /*Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * shakeAmount);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;*/
            //StartCoroutine(TestShake());
            

            //transform.position = newPos;
            //While isShaking is true, the position of the object will change to a new position to cause the shake effect.
        }
    }

    public void Shake()
    {
        StartCoroutine(ShakeBubble());
    }

    IEnumerator ShakeBubble()
    {
        Vector3 originalPos = transform.position;
        //Before shaking, this sets the original position of the object.

        if(isShaking == false)
        {
            isShaking = true;
        }
        //If it isn't shaking already, start shaking the object.

        transform.localPosition += new Vector3(10, 0, 0);
        yield return new WaitForSeconds(0.1f);
        transform.localPosition -= new Vector3(10, 0, 0);
        yield return new WaitForSeconds(0.1f);
        transform.localPosition += new Vector3(5, 0, 0);
        yield return new WaitForSeconds(0.1f);
        transform.localPosition -= new Vector3(5, 0, 0);
        yield return new WaitForSeconds(0.1f);

        yield return new WaitForSeconds(0.5f);

        isShaking = false;
        transform.position = originalPos;
        //After a set amount of time has passed, set the isShaking to false and set the position of the object back to its original position.
    }

    
}
