using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool isLaunched;
    private Rigidbody2D rigidbody2D;
    private Vector3 startPos;
    private List<Vector3> lastCollidedPositions = new List<Vector3>();
    private int collisionIndex;
    [SerializeField] private Transform PadTransform; 
    
    void Start()
    {
        isLaunched = false;
        rigidbody2D = GetComponent<Rigidbody2D>();
        collisionIndex = 0;
        startPos = new Vector3(PadTransform.position.x,transform.position.y,transform.position.z);
        Data.Score = 0;
    }
    
    private void Update()
    {
        
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            startPos.x = PadTransform.position.x;
            transform.position = startPos;
            rigidbody2D.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            isLaunched = true;
        }
#endif
        
        if (!isLaunched && Input.touchCount > 0 )
        {
            Touch touch = Input.touches[0];
            startPos.x = PadTransform.position.x;
            transform.position = startPos;
            
            if (touch.phase == TouchPhase.Ended)
            {
                rigidbody2D.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
                isLaunched = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Box"))
        {
            CoreBox coreBox = other.gameObject.GetComponent<CoreBox>();
            coreBox.Hit();
        }
        
        if (collisionIndex <= 2)
        {
            lastCollidedPositions.Add(transform.position);
            collisionIndex++;
        }
        else if (collisionIndex > 2)
        {
            if (lastCollidedPositions[0].y.Equals(lastCollidedPositions[1].y) && lastCollidedPositions[1].y.Equals(lastCollidedPositions[2].y))
            {
                ResetPosition();
                ResetData();
            }
            else
            {
                lastCollidedPositions[0] = lastCollidedPositions[1];
                lastCollidedPositions[1] = lastCollidedPositions[2];
                lastCollidedPositions[2] = transform.position;
            }
        }
    }

    private void ResetData()
    {
        lastCollidedPositions.Clear();
        collisionIndex = 0;
    }

    private void ResetPosition()
    {
        rigidbody2D.velocity = Vector3.zero;
        transform.position = new Vector3(PadTransform.position.x, startPos.y, startPos.z);
        isLaunched = false;
    }
}
