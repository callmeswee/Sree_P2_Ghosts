using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScriptWAIT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timeWaiter());
    }

    IEnumerator timeWaiter()
    {
        Debug.Log("waiter entered");
        yield return new WaitForSecondsRealtime(7);
        Application.Quit();
    }
}
