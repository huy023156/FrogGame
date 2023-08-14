using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour {
    public event EventHandler<OnUpdateAnimationEventArgs> OnUpdateAnimation;
    public class OnUpdateAnimationEventArgs : EventArgs {
        public MovementState movementState;
    }

    public static Player Instance { get; private set; }

    private const string HORIZONTAL_AXIS = "Horizontal";

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float speed;
    private float jumpForce;
    private Rigidbody2D playerRigidBody;
    private BoxCollider2D coll;

     public enum MovementState {
        IsIdle,
        IsRunning,
        IsJumping,
        IsFalling,
     }

    [SerializeField] private AudioSource jumpSoundEffect;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        playerRigidBody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        playerRigidBody.gravityScale = 3;
        speed = 7f;
        jumpForce = 14f;
    }

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        MovementState movementState;

        float dirX = Input.GetAxisRaw(HORIZONTAL_AXIS);
        playerRigidBody.velocity = new Vector2(dirX * speed, playerRigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            jumpSoundEffect.Play();
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        }

        if (dirX < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
            movementState = MovementState.IsRunning;
        } else if (dirX > 0) {
            transform.localScale = new Vector3(1, 1, 1);
            movementState = MovementState.IsRunning;
        } else {
            movementState = MovementState.IsIdle;
        }

        if (playerRigidBody.velocity.y > .1f) {
            movementState = MovementState.IsJumping;
        }

        if (playerRigidBody.velocity.y < -.1f) {
            movementState = MovementState.IsFalling;
        }

        OnUpdateAnimation?.Invoke(this, new OnUpdateAnimationEventArgs {
            movementState = movementState,
        });
    }

    private bool IsGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
