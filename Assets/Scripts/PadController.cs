using UnityEngine;

public class PadController : MonoBehaviour
{
    public GameObject[] Pads;

    public GameObject Pad;
    private Camera mainCamera;
    private float yPos;

    private void Start()
    {
        mainCamera = Camera.main;
        yPos = transform.position.y;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.position.y <= Screen.height && touch.position.y > Screen.height * 0.91f)
            {
                return;
            }
            
            Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            touchPosition.y = yPos;
            touchPosition.x = Mathf.Clamp(touchPosition.x, -2f, 2f);
            transform.position = touchPosition;

            var padPosition = Pad.transform.position;
            padPosition = new Vector3(transform.position.x, padPosition.y, padPosition.z);
            Pad.transform.position = padPosition;
        }
    }

    public void ChangePlatform(int id)
    {
        Destroy(Pad);
        Pad = Instantiate(Pads[id]);
    }
}