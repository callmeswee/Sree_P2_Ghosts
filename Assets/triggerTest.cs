 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTest : MonoBehaviour
{
    [Header("Feedback")]
    public Renderer renderer2;
    public Color highlightColor = Color.black;


    public GameObject currentGameObject;
    public float alpha = 0.25f;//half transparency
    public float backAlpha = 1f; // no transparency
    //Get current material
    private Material currentMat;


    // Start is called before the first frame update
    void Start()
    {
        currentGameObject = gameObject;
        currentMat = currentGameObject.GetComponent<Renderer>().material;
        if(highlightColor == Color.black)
        {
            highlightColor = currentMat.color;
        }
        currentMat.EnableKeyword("_EMISSION");
    }

    private void OnTriggerEnter(Collider other)
    {
        //(currentMat, alpha);
        Debug.Log("on trigger enter");
        currentMat.SetColor("_EmissionColor", highlightColor);
    }

    private void OnTriggerExit(Collider other)
    {
        //  ChangeAlphaBack(currentMat, backAlpha);
        Debug.Log("on trigger exit");
        currentMat.SetColor("_EmissionColor", Color.black);

    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);

    }

    void ChangeAlphaBack(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
   
}
