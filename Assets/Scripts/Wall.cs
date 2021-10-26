using System;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Camera camera;
    private Vector2 offset;
    public WallEnum WallEnumSide;
    
    private void Start()
    {
        camera = Camera.main;
        float width = camera.pixelWidth;
        float height = camera.pixelHeight;
        
        switch (WallEnumSide)
        {
            case WallEnum.Upper:
                offset = camera.ScreenToWorldPoint(new Vector2 (width/2, height));
                //offset += new Vector2(0, -0.343f);
                transform.position = offset;
                break;
            case WallEnum.Right:
                offset = camera.ScreenToWorldPoint(new Vector2 (width, height/2));
                //offset += new Vector2(+0.4f, 0);
                transform.position = offset;
                break;
            case WallEnum.Bottom:
                offset = camera.ScreenToWorldPoint(new Vector2 (width/2, 0));
                //offset += new Vector2(0, -0.4f);
                transform.position = offset;
                break;
            case WallEnum.Left:
                offset = camera.ScreenToWorldPoint(new Vector2 (0, height/2));
                //offset += new Vector2(-0.4f, 0);
                transform.position = offset;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum WallEnum
{
    Upper,
    Right,
    Bottom,
    Left
}