using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform parentBox;
    [SerializeField] private GameObject bustedCnvas;

    [SerializeField] private Transform rightDownPos;
    [SerializeField] private Transform centerDownPos;
    [SerializeField] private Transform leftDownPos;
    [SerializeField] private Transform rightUpPos;
    [SerializeField] private Transform centerUpPos;
    [SerializeField] private Transform leftUpPos;
    private Animator animator;

    [SerializeField] private bool rightDown = false;
    [SerializeField] private bool centerDown = true;
    [SerializeField] private bool leftDown = false;
    [SerializeField] private bool rightUp = false;
    [SerializeField] private bool centerUp = false;
    [SerializeField] private bool leftUp = false;


    [SerializeField] private GameObject moneyOnHand;
    [SerializeField] private GameObject moneyOnLap;

    [SerializeField] private bool gameStarted = false;

    [SerializeField] private int health = 3;

    Vector3 yeniKonum;

    private void Start()
    {
        animator = GetComponent<Animator>();

        moneyOnHand.SetActive(true);
        moneyOnLap.SetActive(false);
    }
    private void Update()
    {
        if (rightDown)
        {
            yeniKonum = new Vector3(rightDownPos.position.x, transform.position.y, parentBox.position.z);
        }
        if (centerDown)
        {
            yeniKonum = new Vector3(centerDownPos.position.x, transform.position.y, parentBox.position.z);
        }
        if (leftDown)
        {
            yeniKonum = new Vector3(leftDownPos.position.x, transform.position.y, parentBox.position.z);
        }


        if (rightUp)
        {
            transform.position = rightUpPos.position;
        }
        if (centerUp)
        {
            transform.position = centerUpPos.position;
        }
        if (leftUp)
        {
            transform.position = leftUpPos.position;
        }

        if (centerDown)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                rightDown = true;
                centerDown = false;
                leftDown = false;
                rightUp = false;
                centerUp = false;
                leftUp = false;
                animator.Play("Thief_Run_Right");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                rightDown = false;
                centerDown = false;
                leftDown = true;
                rightUp = false;
                centerUp = false;
                leftUp = false;
                animator.Play("Thief_Run_Left");
            }
        }
        if (rightDown)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                rightDown = false;
                centerDown = true;
                leftDown = false;
                rightUp = false;
                centerUp = false;
                leftUp = false;
                animator.Play("Thief_Run_Left");
            }
        }
        if (leftDown)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                rightDown = false;
                centerDown = true;
                leftDown = false;
                rightUp = false;
                centerUp = false;
                leftUp = false;
                animator.Play("Thief_Run_Right");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Thief_Jump");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.Play("Thief_Jump_Over");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.Play("Thief_Roll");
        }

        gameStarted = PlayerPositions.gameStarted;
        animator.SetBool("gameStarted", gameStarted);



        moneyOnHand.SetActive(!gameStarted);
        moneyOnLap.SetActive(gameStarted);

        transform.position = Vector3.Lerp(transform.position, yeniKonum, 5 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (health <= 0)
            {
                transform.SetParent(null);
                animator.Play("Thief_Death");
                PlayerPositions.gameStarted = false;
                bustedCnvas.SetActive(true);
            }
            else
            {
                health--;
                animator.Play("Thief_Hit");
            }

        }
    }
}
