using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookyEventtrigger : MonoBehaviour
{
    [SerializeField] GameObject go_SpookyEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(go_SpookyEvent, 7f);
        }
    }
}
