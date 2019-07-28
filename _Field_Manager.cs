using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class _Field_Manager : MonoBehaviour
{

    public static List<Grass_Manager> Subfields = new List<Grass_Manager>();
    public static List<GameObject> Cows_ = new List<GameObject>();

    public GameObject Sun;
    public GameObject Sky;
    public GameObject Cow;
    public GameObject Passport;

    private GameObject CowParent;


    public Transform[] Places;

    public static int CowCount = 0;

             
    
    private void Start()
    {
       CowParent = new GameObject("CowParent");
    }

    public void BuyCow(Vector3 position)
    {
        Instantiate(Cow, position, Quaternion.identity).transform.parent = CowParent.transform;
               
    }

   

}
