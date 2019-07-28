using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass_Manager : MonoBehaviour
{
    public  List<Grass> L_Grass = new List<Grass>();
    public bool busy = false;
    private void Awake()
    {
        _Field_Manager.Subfields.Add(this);
    }


    public void Cut()
    {
        
        foreach(Grass grass in L_Grass)
        {
           grass.CutGrass();
        }
    }

}
