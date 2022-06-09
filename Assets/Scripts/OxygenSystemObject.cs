using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenSystemObject : MonoBehaviour
{
    OxygenSystem go_PlayerReference;

    float f_OxygenAmount = 10;

    private void Start()
    {
        go_PlayerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<OxygenSystem>();
    }

    private void Update()
    {
        if(f_OxygenAmount <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            InvokeRepeating("Addition", 1f, 1f);
        }
    }

    void Addition()
    {
        go_PlayerReference.i_PlayerOxygen += 2f;
        f_OxygenAmount -= 1f;
    }
}
