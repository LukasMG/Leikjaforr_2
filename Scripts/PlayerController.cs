using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GamaManage gamemanager; //bý til breytur
    Rigidbody2D rigidbody2d;
    Animator animator;
    public int speed = 4;
    float vertical = 0;
    float horizontal = 0;


    void Start()
    {  
        rigidbody2d = GetComponent<Rigidbody2D>(); // gríp nauðsýnlega components
        animator = GetComponent<Animator>();
    }

    void Update(){
        horizontal = Input.GetAxis("Horizontal"); // tekk inntak
        vertical = Input.GetAxis("Vertical");

        animator.SetFloat("o", horizontal); // sendi gildið á animator

        Vector2 position = rigidbody2d.position; // næ núverandi stöðu

        if (Input.GetKeyDown(KeyCode.E)){ // gá hvort það sé verið að ýta á E
            gamemanager.Interact(position); // Sendi á gamemanager að player er að reyna nota eitthvað
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //gá hvort það sé verið að ýta á Esc
        {
            gamemanager.endPuzzle(); // sendi á gamemanager að slökkva á UI
        }
    }

    void FixedUpdate(){
        Vector2 position = rigidbody2d.position; // gríp núverandi position

        position.x = position.x + speed * horizontal * Time.deltaTime;// breyti um magnið sem á að breyta
        position.y = position.y + speed * vertical * Time.deltaTime;// breyti um magnið sem á að breyta

        if (gamemanager.canvas.activeSelf == false) // Gá hvort það sé slökkt á ui interface
        {
            rigidbody2d.MovePosition(position); //Leyfi character að færa sig
        }
    }
}