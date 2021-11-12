using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private GameManager gameMng;
    private Rigidbody2D rb;
    public float BallSpeed;
    private Vector2 horizontalDirection;
    private Vector2 verticalDirection;
    static public bool startSignal;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;


    // Start is called before the first frame update
    void Start()
    {
        
        Random.InitState((int)System.DateTime.Now.Ticks);

        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;

        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        gameMng = FindObjectOfType<GameManager>();

        rb = GetComponent<Rigidbody2D>();

        int randomVerticalConstant;

        if((Random.Range(0,2)) == 0)
        {
            horizontalDirection = Vector2.left;
        }
        else horizontalDirection = Vector2.right;

        if ((randomVerticalConstant = Random.Range(-50, 50)) < 0)
        {
            verticalDirection = Vector2.down;
        }
        else verticalDirection = Vector2.up;

        //if (Random.Range(-50, 50) < 0)
        //{
        //    verticalDirection = Vector2.down;
        //}
        //else verticalDirection = Vector2.up;

       
    }

    // Update is called once per frame
    public void AddInitialForce()
    {     
            rb.AddForce((horizontalDirection + verticalDirection) * BallSpeed);
           // rb.velocity = rb.velocity + verticalDirection * BallSpeed;
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    public IEnumerator ResetPosition()
    {
        this.transform.position = Vector3.zero;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1.0f); 
        AddInitialForce();

    }

}
