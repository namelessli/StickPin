using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float speed = 10f;
    private bool isFly = false;  //是否到达出发点
    private bool isReach = false; //是否到达终点

    private Transform startPos;
    private Transform circle;


    void Start()
    {
        startPos = GameObject.Find("StartPos").transform;
        circle = GameObject.Find("Circle").transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(isFly == false)
        {
            if(isReach == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos.position, speed * Time.deltaTime);
                if(Vector3.Distance(transform.position , startPos.position) < 0.05f)
                {
                    isReach = true;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, circle.position - new Vector3(0,2,0), speed * Time.deltaTime);
            if(Vector3.Distance(transform.position,circle.position - new Vector3(0,2,0))<0.5f)
            {
                transform.position = circle.position - new Vector3(0, 2, 0);
                transform.parent = circle;
                isFly = false;
            }
        }
    }

    public void StartFly()
    {
        isFly = true;
        isReach = true;
    }
}
