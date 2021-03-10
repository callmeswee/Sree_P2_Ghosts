using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTouchDown(Vector3 startTouchPostion)
    {
        Debug.Log("on touch down");
    }

    public void OnTouchUp()
    {
        Debug.Log("on touch up");

    }

}
