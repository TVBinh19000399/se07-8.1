using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] RectTransform fader;

    private void Start()
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInOutCirc).setOnComplete(()=> {
            fader.gameObject.SetActive (false);
        });
    }
    public void LoadArScene()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutCirc).setOnComplete(()=> {
            //Invoke("LoadAR", 0.5f);
            SceneManager.LoadScene(1);
        });
    }
    public void LoadMenuScene()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutCirc).setOnComplete(()=> {
            SceneManager.LoadScene(0);
        });
    }

    /*
    private void LoadAR()
    {
        SceneManager.LoadScene(1);
    }
    */

    public void Quit()
    {
        Debug.Log("Quitted");
        Application.Quit();
    }

}
