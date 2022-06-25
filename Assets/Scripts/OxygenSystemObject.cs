using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class OxygenSystemObject : MonoBehaviour
    {
        [SerializeField] OxygenSystem go_PlayerReference;

        [SerializeField] GameObject go_Container;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("HET WERKT: " + other.gameObject.name);
                go_PlayerReference.i_PlayerOxygen += 40f;
                Destroy(go_Container);
            }
        }
    }
}


