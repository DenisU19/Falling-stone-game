using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMoveController : MonoBehaviour
{
    public float moveSpeed;
    private float moveX;
    private float moveZ;
    private Vector3 move;
    Animator heroAnim;
    Rigidbody rb;
    void Start()
    {
        heroAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (StartTimer.isGameStart)
        {
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                heroAnim.SetBool("IsRunning", true);
            }
            else
            {
                heroAnim.SetBool("IsRunning", false);
            }
            moveX = Input.GetAxis("Horizontal") * moveSpeed;
            moveZ = Input.GetAxis("Vertical") * moveSpeed;
            move = new Vector3(moveX, 0, moveZ);
            move = Vector3.ClampMagnitude(move, moveSpeed);
            move *= Time.deltaTime;
            rb.velocity = new Vector3(move.x, -9.8f, move.z);
            if (Vector3.Angle(transform.forward, move) > 0)
            {
                Vector3 rotateDir = Vector3.RotateTowards(transform.forward, move, moveSpeed, 0f);
                transform.rotation = Quaternion.LookRotation(rotateDir);
            }
        }
    }
}
