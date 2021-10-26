using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Camera camera;
    
    
    void Start()
    {
        camera = Camera.main;
        float width = camera.pixelWidth;
        float height = camera.pixelHeight;
        Vector2 offset;
        
        offset = camera.ScreenToWorldPoint(new Vector2 (width, height));
        //offset += new Vector2(0, -0.343f);
        transform.position = offset;
    }

    private void Update()
    {
        camera = Camera.main;
        float width = camera.pixelWidth;
        float height = camera.pixelHeight;
        Vector2 offset;
        offset = camera.ScreenToWorldPoint(new Vector2 (width, height));
        //offset += new Vector2(0, -0.343f);
        transform.position = offset;
    }
}
