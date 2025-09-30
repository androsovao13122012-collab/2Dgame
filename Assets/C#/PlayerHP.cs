using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public event Action OnDead;
    public bool isDead;
    Image imageHP;
     public float currenHP = 100;
    private void Awake()
    {
        imageHP = GetComponentInChildren<Image>();
    }
    private void OnEnable()
    {
        isDead = false;
    }
    public void TakeDemog(float demog)
    {
        currenHP -= demog;
        currenHP = Mathf.Clamp(currenHP, 0, 100);
        imageHP.fillAmount = currenHP/100;
        Dead();

    }
    public void HillHP(float hill)
    {
        currenHP += hill;
        currenHP = Mathf.Clamp(currenHP, 0, 100);
        imageHP.fillAmount = currenHP / 100;
    }
    public void Dead()
    {
        if ( currenHP <= 0)
        {
            isDead=true;
            OnDead?.Invoke();
        } 
    }
   

}
