using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : MonoBehaviour
{
    public GameObject follower;    
    public CircleCollider2D coll;

    private Vector3 Start_Pos;
    private Vector3 v3;

    private float radius;



    private void Start()
    {
       coll = follower.GetComponent<CircleCollider2D>();
        radius = coll.radius;

        Start_Pos = follower.transform.position;   

    }

    private void Update()
    {
        
        v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            follower.transform.position = v3;
            follower.GetComponent<CircleCollider2D>().radius = 100;
        }
        if (Input.GetMouseButtonUp(0))
        {
            follower.transform.position = Start_Pos;
            follower.GetComponent<CircleCollider2D>().radius = radius;

        }

    }



}
