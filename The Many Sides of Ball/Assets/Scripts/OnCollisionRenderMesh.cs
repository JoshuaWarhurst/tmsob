using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionRenderMesh : MonoBehaviour {

    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
