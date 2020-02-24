using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    

    void Update()
    {
        transform.Translate(Vector3.back * GameManager.GameSpeed * Time.deltaTime);
    }
}
