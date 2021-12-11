using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleAndRotate : MonoBehaviour
{
    private Slider scaleSlider;

    // Start is called before the first frame update
    void Start()
    {
        scaleSlider = GameObject.Find("scalesl").GetComponent<Slider>();
        scaleSlider.maxValue = 1f;
        scaleSlider.minValue = 0.005f;
        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);
    }

    public void ScaleSliderUpdate(float value)
    {
        transform.localScale = new Vector3(value, 0.0001f, value);
    }


}
