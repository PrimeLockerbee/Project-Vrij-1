using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class OxygenSystemObject : MonoBehaviour
    {
        [SerializeField] OxygenSystem go_PlayerReference;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("HET WERKT: " + other.gameObject.name);
                go_PlayerReference.i_PlayerOxygen += 40f;
                Destroy(this.gameObject);
            }
        }
    }
}


