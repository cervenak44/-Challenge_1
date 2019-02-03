using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text pointText;
    public Text winText;
    public Text livesText;


    private Rigidbody rb;
    private int count;
    private int point;
    private int enemy;
    private int lives;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        point = 0;
        SetPointText();
        enemy = 0;
        lives = 3;
        setlivestext();
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            point = count - enemy;
            SetPointText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            lives = lives - 1;
            setlivestext();
            enemy = enemy + 1;
            other.gameObject.SetActive(false);
            point = count - enemy;
            SetPointText();
        }
    }

    void SetCountText()
    {
        countText.text = "The Total Count: " + count.ToString();
        if (count == 13)
        {
            rb.MovePosition(new Vector3(105, 0, 0));
        }

    }
    void SetPointText()
    {
        pointText.text = "point: " + point.ToString();
        if (point >= 21)
        {
            winText.text = "Congrats, You Win";
        }
    }
    void setlivestext()
    {
        livesText.text = "Lives:" + lives.ToString();
        if (lives <= 0)
        {
            winText.text = "You Lose";
            Destroy(rb)
        ;
        }

    }
}
