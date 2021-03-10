using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu_Next: MonoBehaviour
{
    //main menu handle
    public void Yes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void No()
    {
        SceneManager.LoadScene("10_offload");
    }
}
