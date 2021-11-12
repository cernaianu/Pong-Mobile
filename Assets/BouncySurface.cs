using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    [SerializeField] private float reboundSpeed;
    [SerializeField] private AudioSource hitSfx;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallScript ball = collision.gameObject.GetComponent<BallScript>();

        if (ball != null)
        {
            hitSfx.Play();
            Vector2 normal = collision.GetContact(0).normal;

            ball.AddForce(-normal * reboundSpeed);
        }
    }
}
