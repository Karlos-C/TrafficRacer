using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [Range(0.0f, 3f)]
    [SerializeField]float speed = 1f;
    Renderer rend;
    float offset;

    void Start()
    {
        rend= GetComponent<Renderer>();
    }

    void Update()
    {
        offset += (Time.deltaTime * speed);
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }
}