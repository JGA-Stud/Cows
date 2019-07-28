using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Udderometer : MonoBehaviour
{
    private Cow_Animation_Behaviour cab;
    private Color BackGroundColor;
    private _ColorMap palette;

    public int fillness;



    private void Update()
    {
        cab = GetComponentInParent<Cow_Animation_Behaviour>();
     
    }
    public void feed()
    {
        fillness += 5;
    }

    private void OnMouseDown()
    {
        Debug.Log("Collision");
        cab.milk();
    }

}
