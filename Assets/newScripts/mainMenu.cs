using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    //main menu handle
    public void Yes()
    {
        SceneManager.LoadScene("2_introTWO");
    }

    public void No()
    {
        SceneManager.LoadScene("10_offload");
    }
}
