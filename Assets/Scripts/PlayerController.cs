using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRigidBody2D;
    [SerializeField]
    private Animator playerAnimator;
    private float playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        // Player velocity should be initialized according to other parameters if necessary
        // If not, a constant should be declared instead of a variable
        playerVelocity = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        playerRigidBody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * playerVelocity;

        playerAnimator.SetFloat("moveX", playerRigidBody2D.velocity.x);
        playerAnimator.SetFloat("moveY", playerRigidBody2D.velocity.y);

        if(Input.GetAxisRaw("Horizontal") != 0 ||
           Input.GetAxisRaw("Vertical") != 0)
        {
            playerAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            playerAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
}
