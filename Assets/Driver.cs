using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float rotateSpeed = 120f;
    [SerializeField] float moveSpeed = 7.5f;
    // [SerializeField] float slowSpeed = 15f;
    // [SerializeField] float fastSpeed = 30f;

    //test below
    bool touchingRightWall;

    // Update is called once per frame
    void Update()
    {
        float rotateAmount = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -rotateAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
    
        // increase speed if car hits boost
        if (other.tag == "Boost") {
            // moveSpeed = fastSpeed;
        }

        // decrease speed if car hits bump
        if (other.tag == "Bump") {
            // moveSpeed = slowSpeed;
        }
    }


}
