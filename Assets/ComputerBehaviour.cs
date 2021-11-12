using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerBehaviour : MonoBehaviour
{
    [SerializeField] private float computerSpeed;
    [SerializeField] private Rigidbody2D ball;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(ball.velocity.x > 0.0f)
        {
            if (ball.velocity.y > 0.0f && this.transform.position.y < ball.transform.position.y)
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.up * computerSpeed;
            }
            else if (ball.velocity.y < 0.0f && this.transform.position.y > ball.transform.position.y)
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.down * computerSpeed;
            }
            else this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else if (ball.velocity.x < 0.0f)
        {
            if (this.transform.position.y > 0.0f)
                this.GetComponent<Rigidbody2D>().velocity = Vector2.down * computerSpeed;
            else if (this.transform.position.y < 0.0f)
                this.GetComponent<Rigidbody2D>().velocity = Vector2.up * computerSpeed;
            else if (this.transform.position.y == 0.0f)this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }
    }
}
