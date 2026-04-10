using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    Animator anim;
    Rigidbody rb;
    Vector3 direction;
    bool isGrounded;
    [SerializeField] float iceAcceleration = 15f; 
    //находится ли игрок на скользом полу
    bool isOnIce = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
        }        
    }
    private void FixedUpdate()
    {
        if (isOnIce)
        {
            // Если пол - скользкий, то добавляем силу, имитируя скольжение
            rb.AddForce(direction * iceAcceleration); 
        }
        else
        {
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other != null)
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Ice"))
        {
            isOnIce = true;
        }
        else
        {
            isOnIce = false;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
        if (other.gameObject.CompareTag("Ice"))
        {
            isOnIce = false;
        }
    }    
}