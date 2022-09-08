using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Dashes")
        {
            other.gameObject.tag = "Normal";
            PlayerControl.Instance.TakeDashes(other.gameObject);
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.AddComponent<StackScript>();
            Destroy(this);
        }
    }
}
