using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plataforma : MonoBehaviour
{
    public Text AltuTxt;
    public GameObject plat;
    void Start()
    {
        AltuTxt = GameObject.Find("Altura").GetComponent<Text>();
    }
    public void Slider_Changed(float newValue)
    {
        Vector3 pos = plat.transform.position;
        pos.y = newValue;
        plat.transform.position = pos;
        var altnormal = newValue + 10.63;
        var cero = 0;
        if (altnormal>=0) {
            AltuTxt.text = altnormal.ToString();
        }
        else
        {
            AltuTxt.text = cero.ToString();
        }
    }
}
