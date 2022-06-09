using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempratureSystem : MonoBehaviour
{
    [SerializeField]
    public float i_PlayerTemp = 37;

    void Start()
    {
        InvokeRepeating("Subtract", 1f, 1f);
    }

    void Subtract()
    {
        i_PlayerTemp -= .2f;
    }
}
