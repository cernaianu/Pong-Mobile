using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private GameManager gameMng;

    private Rigidbody2D rb;

    public float moveSpeed;

    private float horizontalBoundaryRight = -6f;

    private float horizontalBoundaryLeft = -9f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    // Start is called before the first frame update
    void Start()
    {
        gameMng = FindObjectOfType<GameManager>();
        

    }

    private void Update()
    {
        
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameMng.GameState)
        {
            TouchMove();
        }
        
    }

    void TouchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPosition.y > (transform.position.y + 1) && touchPosition.x <= horizontalBoundaryRight && touchPosition.x >= horizontalBoundaryLeft)
            {
                //move up
                rb.velocity = Vector2.up * moveSpeed;
                //rb.AddForce(Vector2.up * moveSpeed);

            }

            else if (touchPosition.y < (transform.position.y - 1) && touchPosition.x <= horizontalBoundaryRight && touchPosition.x >= horizontalBoundaryLeft)
            {
                rb.velocity = Vector2.down * moveSpeed;
                //rb.AddForce(Vector2.down * moveSpeed);
            }

        }
        else rb.velocity = Vector2.zero;


    }


}
