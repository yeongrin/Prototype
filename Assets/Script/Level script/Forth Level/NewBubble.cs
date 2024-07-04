using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBubble : MonoBehaviour
{

    public bool isShaking = false;

    public float shakeAmount;

    void Update()
    {
        if (isShaking)
        {
            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * shakeAmount);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            transform.position = newPos;
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

        yield return new WaitForSeconds(0.5f);

        isShaking = false;
        transform.position = originalPos;
        //After a set amount of time has passed, set the isShaking to false and set the position of the object back to its original position.
    }

}
