using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnime : MonoBehaviour
{
    Animator anim;
    PlayerHP hp;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        hp = GetComponent<PlayerHP>();
    }
    private void OnEnable()
    {
        hp.OnDead += DeadAnim;
    }
    public void MoveAnim(float x)
    {
        anim.SetFloat("x", Mathf.Abs(x));
    }
    public void JumpAnim()
    {
        anim.SetTrigger("jumpTrigger");
    }
    public void DeadAnim()
    {
        anim.SetTrigger("deadTrigger");
        hp.OnDead -= DeadAnim;
    }
    
}
