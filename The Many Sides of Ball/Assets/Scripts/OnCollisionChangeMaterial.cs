using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionChangeMaterial : MonoBehaviour {

    public Material newMaterial;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(ChangeMaterial());
        }
    }

    IEnumerator ChangeMaterial()
    {
        this.GetComponent<Renderer>().material.color = new Color (255,255,255);
        yield return new WaitForSeconds(1f);
        this.GetComponent<Renderer>().material = newMaterial;
    }
}
