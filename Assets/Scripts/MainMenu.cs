using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void OnClickPlay()
    {
        // play animation where everything goes dark.
        SceneManager.LoadScene("Main");
    }
}
