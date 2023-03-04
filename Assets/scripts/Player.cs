using UnityEngine;



public class Player : MonoBehaviour
{   
    private Animator anim;

    public float jumpForce = 800f;

    private Spawner spawner;

    private float elapsedTime;

    private bool isGrounded;

    private Vector3 originalPosition;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spawner = FindObjectOfType<Spawner>();
        originalPosition = transform.position;
    }


    private void Update()
    {
        if(isGrounded){
            if (Input.GetButton("Jump")) {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce; 
                anim.SetBool("jump",true);
            }
        }
   
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Piso")){
            isGrounded = true;
            if(anim.GetBool("jump")==true){
                anim.SetBool("jump",false);
            }
        }
        if(other.collider.CompareTag("Block")){
            SetHit();
        }
        if (other.collider.CompareTag("enemy")) {
            print("GameOver");
            FindObjectOfType<GameManager>().GameOver();
        }
        if(other.collider.CompareTag("Collectable")){
            FindObjectOfType<GameManager>().addPoints();
            Destroy(other.collider.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.collider.CompareTag("Piso")){
            isGrounded = false;
        }
        if(other.collider.CompareTag("Block")){
            transform.position = new Vector3(-6, transform.position.y, transform.position.z);
            SetHitOff();
        }
    }

    public void SetHit()
    {
        anim.SetBool("hit",true);
    }

    public void SetHitOff()
    {
        anim.SetBool("hit",false);
    }

}
