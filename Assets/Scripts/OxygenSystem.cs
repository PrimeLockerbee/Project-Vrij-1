using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenSystem : MonoBehaviour
{
    [SerializeField]
    public float i_PlayerOxygen;

    [SerializeField]
    Text t_OxygenText;

    void Start()
    {
        InvokeRepeating("Subtract", 1f, 1f);
    }

    private void Update()
    {
        t_OxygenText.text = "Current Oxygen level: " + i_PlayerOxygen.ToString();
    }

    void Subtract()
    {
        i_PlayerOxygen -= .5f;
    }
}
