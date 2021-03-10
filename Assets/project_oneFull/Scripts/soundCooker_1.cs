using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundCooker_1 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Color hoverColor;

    private Color originalColor;
    private Material material;


    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent <Renderer>().material;
        originalColor = material.color;
    }

    public void OnPointerEnter()
    {
        //update audio source and position
        //play audio clip

        audioSource.transform.position = transform.position;
        audioSource.PlayOneShot(audioClip);

    }

    public void OnPointerExit()
    {
        material.color = originalColor;
    }
}
