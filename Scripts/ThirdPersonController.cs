using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonController : MonoBehaviour
{
    private Animator playerAnimator;
    public Transform objectToGrab;
    private AnimatorStateInfo currentState;
    private CapsuleCollider capsule;
    private bool active;
    private bool medidora;
    public int maxHealth = 25;
    public int currentHealth;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
        active = true;
        currentHealth = maxHealth;
    }
    public void ActiveController(bool state)
    {
        active = state;
        if (!active)
            playerAnimator.SetFloat("Speed", 0f);
    }
    void Update()
    {
        if (!active)
            return;
        currentState = 
            playerAnimator.GetCurrentAnimatorStateInfo(0);
        playerAnimator.SetFloat("Speed",
                  Input.GetAxis("Vertical"));
        playerAnimator.SetFloat("Direction",
                  Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space) 
            && currentState.IsName("Locomotion"))
            playerAnimator.SetTrigger("Jump");

        if (Input.GetKeyDown(KeyCode.Q))
            playerAnimator.SetTrigger("Wave");
        if (Input.GetKeyDown(KeyCode.G))
            playerAnimator.SetTrigger("Defense");
        if (Input.GetKeyDown(KeyCode.P))
        {
                        playerAnimator.SetTrigger("Attack");
                        //medidora = true;

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            playerAnimator.SetTrigger("Attack2");
                   }
        if (currentState.IsName("Jump"))
        {
            Physics.gravity =
                    Vector3.down * playerAnimator.GetFloat("Gravity");
            capsule.height =
                    playerAnimator.GetFloat("CapsuleHeight");
        }
        else
        {
            capsule.height = 1.17f;
            Physics.gravity =
                    Vector3.down * 9.81f;
        }
        if (currentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
        medidora = false;
    }
    void OnCollisionEnter(Collision collision)
    {
               if (collision.transform.tag == "Enemy")
        {
            currentHealth -= 1;
        }
        if (collision.gameObject.tag == "Enemy" && (Input.GetKeyDown(KeyCode.P) ||Input.GetKeyDown(KeyCode.O)))
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(1.0f);
        }
    }



}
