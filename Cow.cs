using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    private int ID;

    public Grass_Manager activeField;
    public Cow_Animation_Behaviour pCow;
    public _Field_Manager manager;

    bool fieldAvailable = false;
    public bool collided = false;


    private void Awake()
    {

        manager = GameObject.FindGameObjectWithTag("MAIN").GetComponent<_Field_Manager>();
        ID = _Field_Manager.CowCount;
        _Field_Manager.CowCount++;
        
        _Field_Manager.Cows_.Add(gameObject);
        
    }

   

    private void Start()
    {


        pCow = GetComponentInParent<Cow_Animation_Behaviour>();


        foreach (Grass_Manager field in _Field_Manager.Subfields)
        {
            if (!field.busy)
            {
                Debug.Log("FIELD FOUND");
                activeField = field;
                field.busy = true;
                fieldAvailable = true;
                break;
            }

        }

    }

    private void Update()
    {
        if(fieldAvailable)LookForField();
    }

    public void PrintPassport()
    {
        Instantiate(manager.Passport, new Vector3(0, 0, 0), Quaternion.identity).transform.parent = null;

    }


    public void LookForField()
    {


        transform.position = Vector3.MoveTowards(transform.position,activeField.transform.position+ new Vector3(0, 0, -1), .61f);
        if (Vector3.Distance(gameObject.transform.position, activeField.transform.position)< .10f) {
           
            pCow.startanim(activeField);
            fieldAvailable = false;
        }
 
        
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Destroy(gameObject);
           
            activeField.busy = false;
        }
    }

    

}
