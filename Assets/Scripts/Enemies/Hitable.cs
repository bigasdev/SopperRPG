using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    public int lives = 2;
    private Rigidbody2D rb;

    public float knockback = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(lives <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Hit(int damage)
    {
        lives -= damage;
        rb.AddForce(Vector2.up * 1.5f, ForceMode2D.Impulse);
        rb.AddForce(Vector2.right * knockback, ForceMode2D.Impulse);
    }
}
