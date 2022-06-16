using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempratureSystem : MonoBehaviour
{
    [SerializeField]
    public float i_PlayerTemp;

    [SerializeField]
    Text t_TempratureText;

    void Start()
    {
        InvokeRepeating("Subtract", 1f, 1f);
    }

    private void Update()
    {
        t_TempratureText.text = "Curren temprature: " + i_PlayerTemp.ToString();
    }

    void Subtract()
    {
        i_PlayerTemp -= .2f;
    }
}
