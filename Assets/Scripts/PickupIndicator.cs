using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupIndicator : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        Debug.Log(textMeshPro.text);
        //Debug.Log(this);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(textMeshPro.text);
        Debug.Log(textMeshPro.transform);
    }

}
