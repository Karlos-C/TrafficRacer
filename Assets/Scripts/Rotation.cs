using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]Vector3 direction = Vector3.right;
    [SerializeField]int speedRotation = 800;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(direction * speedRotation * Time.deltaTime);
    }
}