using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class TempSystemObjects : MonoBehaviour
    {
        [SerializeField] TempratureSystem go_PlayerReference;

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("HET WERKT: " + other.gameObject.name);
                go_PlayerReference.i_PlayerTemp += 4f;
            }
        }
    }

}

