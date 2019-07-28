using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public static Grass_Manager igm;

    public static bool CUTGRASS;

    [SerializeField]
    private float GrowSpeed;
    
    private void Awake()
    {
        igm = GetComponentInParent<Grass_Manager>();
        igm.L_Grass.Add(this);
    }

    private void Start()
    {
        GrowSpeed = Random.Range(.0003f, .0012f);
    }


    public void EatGrass()
    {
        gameObject.transform.localScale -= new Vector3(0, .010f, 0);
    }

    public void CutGrass()
    {
        CUTGRASS = true;
        gameObject.transform.localScale = new Vector3(1, .1f, 1);
        CUTGRASS = false;
    }

}
