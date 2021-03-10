using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorSound_interaction : MonoBehaviour
{

    [Header("Feedback")]
    public Renderer renderer_2;
    public Color highlightColor = Color.black;

    private Material material;

    private Vector3 touchOffset;

    private float startAngle;
    private Quaternion startRotation;



    // Start is called before the first frame update
    void Start()
    {
        if (renderer_2 == null)
        {
            renderer_2 = GetComponentInChildren<Renderer>();
        }
        material = renderer_2.material;

        if (highlightColor == Color.black)
        {
            highlightColor = material.color;
        }
        material.EnableKeyword("_EMISSION");
    }


    public void OnTouchDown(Vector3 startTouchPosition)
    {
        Debug.Log("on touch down");
        material.SetColor("_EmissionColor", highlightColor);

    }

    public void OnTouchUp()
    {
        Debug.Log("on touch up");

        material.SetColor("_EmissionColor", Color.black);

    }

}
