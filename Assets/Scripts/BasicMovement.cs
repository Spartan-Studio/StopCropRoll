using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BasicMovement : MonoBehaviour
{
   
    public Animator animator;
    public GameObject crossHair;
    public bool useController;
    public GameObject bulletPrefab;
    public Rigidbody2D rb;
    private AnimCamShake shake;
    public string sceneNamePlay;

    Vector3 movement;
    Vector3 aim;
    bool isAiming;
    bool endOfAiming;
    AudioSource gunShot;
    public float playerHealth;
    public Slider playerHealthBar;
    public float playerDamage;


    [Header("Invulnerablility Frames")]
    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D playerCollider;
    public SpriteRenderer mySprite;



    void Start()
    {
        crossHair = GameObject.FindGameObjectWithTag("crosshair");
    }


    void Awake()
    {
        playerHealth = 100;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<AnimCamShake>();
        playerDamage = 10;
    }




    void Update()
    {
        ProcessInputs();
        AimAndShoot();
        Animate();
        Move();
        playerHealthBar.value = playerHealth;

        if (playerHealth <= 0)
        {
            playerHealth = 0;
            SceneManager.LoadScene(sceneNamePlay);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


    }

    private void ProcessInputs()
    {

        if (useController)
        {
            movement = new Vector3(Input.GetAxisRaw("MoveHorizontal"), Input.GetAxisRaw("MoveVertical"), 0.0f);
            aim = new Vector3(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical"), 0.0f);
            aim.Normalize();
            isAiming = Input.GetButtonDown("Fire");
            endOfAiming = Input.GetButtonUp("Fire");
        }
        else
        {
            movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
            Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);
            aim = aim + mouseMovement;
            if (aim.magnitude > 1.0f)
            {
                aim.Normalize();
            }
            
            isAiming = Input.GetButtonDown("Fire1");
            endOfAiming = Input.GetButtonUp("Fire1");
        }

        if (movement.magnitude > 1.0f)
        {
            movement.Normalize();
        }

    }

    private void Move()
    {
        //transform.position = transform.position + movement * Time.deltaTime;
        rb.velocity = new Vector2(movement.x, movement.y);
       
    }

       void OnTriggerEnter2D(Collider2D zombie)
    {
        if(zombie.gameObject.tag == "Enemies")
        {
            if (playerCollider.enabled == true)
            {
                    StartCoroutine(FlashCo());
                  

                Vector2 difference = transform.position - zombie.transform.position;
                transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
                playerHealth = playerHealth - playerDamage;
            }
            
        }
       

    }



    private IEnumerator FlashCo()
        {
        int temp = 0;
        playerCollider.enabled = false;
        while(temp < numberOfFlashes)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        playerCollider.enabled = true;
    }

    private void Animate()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
    }


    private void AimAndShoot()
    {
        Vector2 shootingDirection = new Vector2(aim.x, aim.y);

        if (aim.magnitude > 0.0f)
        {
            crossHair.transform.localPosition = aim * 0.4f;
            crossHair.SetActive(true);

            shootingDirection.Normalize();
            if (isAiming)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                Debug.Log("FIRE!");
                bulletScript.velocity = shootingDirection * 4.5f;
                gunShot = GetComponent<AudioSource>();
                gunShot.Play(0);
                shake.CamShake();
                bulletScript.self = gameObject;
                bullet.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
                Destroy(bullet, 0.55f);
            }

        }
        else
        {
            crossHair.SetActive(false);
        }
    }
}

