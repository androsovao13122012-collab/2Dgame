using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{

    [SerializeField] private Transform person;
    [SerializeField] private Renderer render;
    [SerializeField] private float speedRotateBG = 1;
    [SerializeField] private float speedMove = 50;
    private Transform trBG;


    private void Awake()
    {
        trBG = GetComponent<Transform>();
    }
    private void Update()
    {

        FollowBG();
    }
    private void FollowBG()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 axis = new Vector3(x, 0, 0);
        trBG.position = Vector2.Lerp(trBG.position, person.position, speedMove * Time.deltaTime);
        trBG.position = new Vector3(trBG.position.x, trBG.position.y, 0);
        if (axis.sqrMagnitude > 0.2f)
        {
            render.material.mainTextureOffset += new Vector2(axis.x * speedRotateBG * Time.deltaTime, 0);
        }

    }










}
