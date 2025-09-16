using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hill : MonoBehaviour
{
    PlayerHP hp;
    public float hill = 50;
    private void Awake()
    {
        hp = FindObjectOfType<PlayerHP>();

    }
    private void OnMouseDown()
    {
        hp.HillHP(hill);
        gameObject.SetActive(false);
    }
}
