using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{

    private Udderometer udderometer;
    private SpriteRenderer BackGroundSprite;

    private int Segments;
    private int SegmentToUse;
    private float factor;
    private float maxSize = 38.6f;

       
    private void Start()
    {
        udderometer = GetComponentInParent<Udderometer>();
        Segments = _ColorMap.colors.Length;
        SegmentToUse = udderometer.fillness % Segments;
        BackGroundSprite = GetComponent<SpriteRenderer>();      
    }

    private void Update()
    {
        SegmentToUse = udderometer.fillness % Segments;
        if (gameObject.tag == "SEGMENT") SetScale(udderometer.fillness % 101);
        SetBGColor(udderometer.fillness);
             
    }

    public void SetBGColor(int fillness)
    {
        float _g = 232-(232*(fillness/100f));
        BackGroundSprite.color = new Color32(232,(byte)_g,(byte)_g,255);
    }
    public void SetScale(int fillness)
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, maxSize*(fillness/100f) , 1);
    }
}
