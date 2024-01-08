using UnityEngine;
using UnityEngine.UI;

public class AstronautPlayer : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;

    public static float MAX_HEALTH = 100.0f;
    public static float MAX_O2_LEVEL = 1000.0f;

    public HealthBar healthBar;
    public OxygenBar o2Bar;

    private float forwardSpeed = 4.0f;
    private float strafeSpeed = 3.0f;
    private float sprintMultiplier;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 jump = Vector3.zero;
    private float gravity = 10.0f;
    private float jumpVel = 7.0f;

    public Menus gameOverMenu;

    private float timeAccum = 0;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();

        transform.position = GameManager.Instance.playerPosition;
    }

    void FixedUpdate() {
        
        healthBar.UpdateHealthBar();

        timeAccum += Time.deltaTime;
        if (timeAccum > 1.0) {
            timeAccum -= 1;
            GameManager.Instance.decrementO2Level();
        }

        o2Bar.UpdateOxygenBar();

        if (Menus.gamePaused) return;

        if (GameManager.Instance.isGameOver()) {
            gameOverMenu.ShowGameOver();
            return;
        }

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) {
        
            anim.SetBool("walk", true);

            // check sprint
            if (Input.GetKey(KeyCode.LeftShift)) {
                anim.SetBool("run", true);
                sprintMultiplier = 2.0f;
            }
            else {
                anim.SetBool("run", false);
                sprintMultiplier = 1.0f;
            }
        }
        else {
            anim.SetBool("walk", false);
        }

        jump = Vector3.zero;

        if (controller.isGrounded) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                // jump
                anim.SetBool("jumpstart", true);
                jump.y = jumpVel;
            }
            else {
                if (anim.GetBool("jumploop")) {
                    anim.SetBool("jumploop", false);
                    anim.SetBool("jumpend", true);
                }
            }

            // move
            
            moveDirection = transform.forward * Input.GetAxis("Vertical") * forwardSpeed * sprintMultiplier
                + transform.right * Input.GetAxis("Horizontal") * strafeSpeed * sprintMultiplier
                + jump;

        } else {
            if (anim.GetBool("jumpstart")) {
                anim.SetBool("jumpstart", false);
                anim.SetBool("jumploop", true);
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }


    void TakeDamagePlayer(float damage)
    {
        GameManager.Instance.takePlayerHealth(damage);
        healthBar.UpdateHealthBar();
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("drop")) {

            UnityEngine.Debug.Log("Item collided with 'drop' object.");
            GameObject item = other.gameObject;
            string itemName = item.name;
            const string cloneSuffix = "(Clone)";

            if (itemName.EndsWith(cloneSuffix)) {
                itemName = itemName.Substring(0, itemName.Length - cloneSuffix.Length);
            }
            GameManager.Instance.addItemToInventory(itemName);
            Destroy(item);
        }
    }

}

