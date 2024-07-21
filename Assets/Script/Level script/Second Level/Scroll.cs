using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed;
    private float nul = 0;
    public Renderer ren;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ren.material.SetTextureOffset("_MainTex", new Vector2( nul += speed * Time.deltaTime,0));
    }
}
