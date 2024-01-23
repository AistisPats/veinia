using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AnimationState
{
    Idle,
    Walking,
    Crouching,
    Jumping,
    Whipping
}

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public IsGrounded isGrounded;
    public Animator animator;
    public float MovementSpeed;
    public float JumpForce;
    public AudioSource WalkingSound;


    private float Direction = 1;
    private bool jumpSkipFrame = false;
    private AnimationState state = AnimationState.Idle;
    private AnimationState lastState;
    private bool whipping = false;


    
    

    void Start()
    {
        
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorClipInfo(0).Length >= 1)
        {
            switch (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString())
            {
                case "Idle":
                    state = AnimationState.Idle;
                    break;
                case "Walking":
                    state = AnimationState.Walking;
                    break;
                case "Crouching":
                    state = AnimationState.Crouching;
                    break;
                case "Jumping":
                    state = AnimationState.Jumping;
                    break;
                case "Whipping":
                    state = AnimationState.Whipping;
                    break;

            }
        }

        if (Input.GetAxis("Horizontal") != 0 && !whipping)
        {
            if (Input.GetAxis("Horizontal") > 0) Direction = -1;
            else Direction = 1;
        }

        lastState = state;
        if(state.Equals(AnimationState.Jumping))
        {
            if(isGrounded.isGrounded() && jumpSkipFrame)
            {
                state = AnimationState.Idle;
            }
            else
            {
                jumpSkipFrame = true;
            }
        }
        else if(!whipping)
        {
            if (Input.GetKey(KeyCode.S) || !isGrounded.isGrounded())
            {
                state = AnimationState.Crouching;
                if (WalkingSound.isPlaying)
                {
                    WalkingSound.Stop();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                state = AnimationState.Whipping;
                whipping = true;
            }
            else if (Input.GetKeyDown(KeyCode.W) && isGrounded.isGrounded())
            {
                print("hielo");
                jumpSkipFrame = false;
                state = AnimationState.Jumping;
                rb.AddForce(Vector2.up * JumpForce);
                if (WalkingSound.isPlaying)
                {
                    WalkingSound.Stop();
                }
            }
            else if (Input.GetAxis("Horizontal") != 0)
            {
                state = AnimationState.Walking;
                if (!WalkingSound.isPlaying)
                    WalkingSound.Play();

            }
            else
            {
                state = AnimationState.Idle;
                if(WalkingSound.isPlaying)
                {
                    WalkingSound.Stop();
                }
            }
        }


        if(lastState != state || state == AnimationState.Idle)
        {
            switch (state)
            {
                case AnimationState.Idle:
                    animator.Play("Idle");
                    break;
                case AnimationState.Walking:
                    animator.Play("Walking");
                    break;
                case AnimationState.Crouching:
                    animator.Play("Crouching");
                    break;
                case AnimationState.Jumping:
                    animator.Play("Jumping");
                    break;
                case AnimationState.Whipping:
                    animator.Play("Whipping");
                    break;

            }
        }


        transform.localScale = new Vector3(Direction, 1, 1);
        if(!state.Equals(AnimationState.Crouching) && !state.Equals(AnimationState.Whipping)) rb.velocity = new Vector3(Input.GetAxis("Horizontal")*MovementSpeed, rb.velocity.y, 0);
    }

    public void SetStateToIdle()
    {
        state = AnimationState.Idle;
        whipping = false;
    }
}
