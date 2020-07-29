using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    public int lives = 2;
    private Rigidbody2D rb;
    private Animator anim;
    public AudioSource hit;
    public AudioSource death;
    public GameObject deathVFX;

    public float knockback = 10f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(lives <= 0)
        {
            Destroy(gameObject);
            var vfx = Instantiate(deathVFX, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(vfx, .3f);
            death.Play();
        }
    }

    public void Hit(int damage)
    {
        lives -= damage;
        rb.AddForce(Vector2.up * 1.5f, ForceMode2D.Impulse);
        rb.AddForce(Vector2.right * knockback, ForceMode2D.Impulse);
        StartCoroutine(hurtAnim());
        if (lives >= 1)
        {
            hit.Play();
        }
    }

    IEnumerator hurtAnim()
    {
        anim.SetBool("Hurt", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Hurt", false);
    }
}
