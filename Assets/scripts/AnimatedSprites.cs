
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]

public class AnimatedSprites : MonoBehaviour
{
    private Animator anim;

    private CharacterController character;

    private bool isJumping = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        character = GetComponent<CharacterController>();
    }

    private void Update() {
        if(character.isGrounded){
            isJumping = false;
            anim.SetBool("jump",false);
            if (Input.GetButton("Jump")) {
                anim.SetBool("jump",true);
                anim.SetTrigger("jump");
                isJumping = true;

            }
        }
    }

    
}
