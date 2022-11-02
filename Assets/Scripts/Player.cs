using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public PlayerActions inputActions;
    float move;
    Rigidbody rb;
    public float speed = 20.0f;
    public float jumpForce = 50.0f;
    bool canJump = false;
    public TextMeshProUGUI text;
    Subject subject = new Subject();

    // Start is called before the first frame update
    void Start()
    {
        inputActions = new PlayerActions();
        inputActions.Enable();
        inputActions.PlayerActionMap.Move.performed += cntxt => move = cntxt.ReadValue<float>();
        inputActions.PlayerActionMap.Move.canceled += cntxt => move = 0.0f;
        inputActions.PlayerActionMap.Jump.performed += cntxt => Jump();

        rb = GetComponent<Rigidbody>();

        ScoreManager manager = new ScoreManager(this.gameObject, text);
        subject.AddObserver(manager);
    }

    void Jump() 
    {
        if (canJump)
            rb.AddForce(Vector3.up * jumpForce) ;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(move * speed, rb.velocity.y, 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            PowerUpManager.instance.PowerUpActivated();
            Destroy(collision.gameObject);
            subject.Ping();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }
}
