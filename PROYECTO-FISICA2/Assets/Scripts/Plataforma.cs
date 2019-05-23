using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject plat;
    public void Slider_Changed(float newValue)
    {
        Vector3 pos = plat.transform.position;
        pos.y = newValue;
        plat.transform.position = pos;
    }
}
