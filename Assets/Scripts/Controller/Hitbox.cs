using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public PolygonCollider2D frame;
    public PolygonCollider2D frame2;

    private PolygonCollider2D[] colliders;

    private PolygonCollider2D localCollider;

    public enum hitBoxes
    {
        frameBox,
        frame2Box,
        clear
    }

    private void Start()
    {
        colliders = new PolygonCollider2D[] { frame, frame2 };

        localCollider = gameObject.AddComponent<PolygonCollider2D>();
        localCollider.isTrigger = true;

        localCollider.pathCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    public void setHitBox(hitBoxes val)
    {
        if(val != hitBoxes.clear)
        {
            localCollider.SetPath(0, colliders[(int)val].GetPath(0));
            return;
        }
        localCollider.pathCount = 0;
    }
}
