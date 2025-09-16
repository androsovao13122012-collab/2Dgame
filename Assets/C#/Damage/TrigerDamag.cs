using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerDamag : MonoBehaviour
{
    public float damage = 5;
    private float timer = 5;
    public float interwal = 0.5f;
    private bool isTrigger;
    private PlayerHP hp;
    private void Update()
    {
        if (isTrigger)
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        if (timer <= Time.time)
        {
            timer = Time.time + interwal;
            hp.TakeDemog(damage);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isTrigger = true;
            hp = FindObjectOfType<PlayerHP>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTrigger = false;
        }
    }
}
