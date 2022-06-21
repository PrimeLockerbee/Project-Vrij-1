using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class TempSystemObjects : MonoBehaviour
    {
        TempratureSystem go_PlayerReference;

        private void Start()
        {
            go_PlayerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<TempratureSystem>();
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
            go_PlayerReference.i_PlayerTemp += .2f;
        }
    }

}

