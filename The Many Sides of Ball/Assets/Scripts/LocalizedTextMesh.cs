using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizedTextMesh : MonoBehaviour {

    public string key;

    void Start ()
    {
        TextMesh textMesh = GetComponent<TextMesh>();
        textMesh.text = LocalizationManager.instance.GetLocalizedValue(key);
    }
}
