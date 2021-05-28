using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string moveInputAxis = "Vertical";
    private float moveSpeed = 0.05f;

    void Start() {
        
    }

    void Update() {
        float moveAxis = Input.GetAxis(moveInputAxis);
        Move(moveAxis);
    }

    private void Move(float input){
        transform.Translate(Vector3.forward * input * moveSpeed);
    }
}
