using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startAR : MonoBehaviour
{
public void Start()

    {
        SceneManager.LoadScene(1);
    }

public void Quit()
    {
        Debug.Log("Quit App");
        Application.Quit();
    }
}
