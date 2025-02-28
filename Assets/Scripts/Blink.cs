using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Blink : MonoBehaviour
{
    TMP_Text txt;
    Color colorIntial;

    [Range(0.05f, 1f)]
    [SerializeField] float delay = 0.2f;
    
    void Start()
    {
        txt = GetComponent<TMP_Text>();
        colorIntial = txt.color;
        StartCoroutine(BlinText());
    }

    IEnumerator BlinText()
    {
        while(true)
        {
            colorIntial.a = 0;
            txt.color = colorIntial;
            yield return new WaitForSeconds(delay);
            colorIntial.a = 1;
            txt.color = colorIntial;
            yield return new WaitForSeconds(delay);
        }
    }
}