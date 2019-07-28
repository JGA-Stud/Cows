using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow_Animation_Behaviour : MonoBehaviour
{
    public Animator Cow;
    private Udderometer udderometer;
    private _Field_Manager manager;
    private Cow _cow;
    private Grass_Manager active_gm;



    private void Start()
    {
    

        _cow = GetComponent<Cow>();
        manager = GameObject.FindGameObjectWithTag("MAIN").GetComponent<_Field_Manager>();
        udderometer = GetComponentInChildren<Udderometer>();
        Cow = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Move();
        }
    }

    public void HeadUp()
    {
        Cow.SetBool("HEADISUP", true);
        Cow.SetBool("HEADDOWN", false);
        Cow.SetBool("STARTGRAZING", false);
        Cow.SetBool("HEADUP", true);



    }

    public void SetToIdle()
    {
        Cow.SetBool("HEADISUP", true);
        Cow.SetBool("HEADDOWN", false);
        Cow.SetBool("STARTGRAZING", false);
        Cow.SetBool("HEADUP", false);
        Cow.SetBool("SHAKEHEAD", false);
        Cow.SetBool("HEADISDOWN", false);
        Cow.SetBool("TRANSLATE", false);

       



    }
   
    public void StartGrazing()
    {
        
        if (!Cow.GetBool("COWISFULL"))
        {
            Cow.SetBool("HEADISUP", false);
            Cow.SetBool("HEADDOWN", true);
            Cow.SetBool("STARTGRAZING", true);
            if(Cow.GetBool("HEADISDOWN")) Feed();
            
            
        }
        else ShakeHead();
    }

    public void ShakeHead()
    {
        Cow.SetBool("SHAKEHEAD", true);
    }

   
    public void HeadDown()
    {
        Cow.SetBool("HEADISDOWN", true);
    }

    public void Feed()
    {
        if (Cow.GetBool("STARTGRAZING"))
        {
           
            udderometer.fillness += 1;
            if (udderometer.fillness == 100)
            {
                Cow.SetBool("COWISFULL", true);
                HeadUp();
            }
            
        }

        if (active_gm != null)
        {
            foreach (Grass grass in active_gm.L_Grass)
            {
                grass.EatGrass();
            }
        }

    }

    public void milk()
    {
        Debug.Log("Milking");
        Cow.SetBool("COWISFULL", false);
        if(udderometer.fillness>=10)udderometer.fillness -= 1;


    }

    public void Move()
    {
        Cow.SetBool("TRANSLATE", true);
    }


    private void OnMouseDown()
    {
        if (Cow.GetBool("HEADISUP")) StartGrazing();
        else HeadUp();
    }

    private int z;


    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0)) z++;
        if (Input.GetMouseButton(0) && z > 100)
        {
            Debug.Log("LONGPRESS");
            _cow.PrintPassport();
            z = 0;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            z = 0;
           
        }


        }
        

    public void startanim(Grass_Manager gm)
    {
        active_gm = gm;
        StartGrazing();
       
       

    }
}
