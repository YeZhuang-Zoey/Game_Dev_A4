using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine.UI;

public class PacmanController : MonoBehaviour
{
    private GameObject rat;

    public float speed = 0.4f;
    public ParticleSystem dustTrail;
    public Collider2D wall;

    Tween tween;
    private Timer timer;
    private Tweener tweener;

    //char lastInput, currentInput;
    private int status, nextStatus;
    Vector2 currentInput, dest, lastInput;

    void Start()
    {
        tweener = GetComponent<Tweener>();
        timer = new Timer();
        timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        timer.Interval = 100 * speed;
        timer.Enabled = true;
        currentInput = Vector2.right;
        dustTrail.Play();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) currentInput = Vector2.up;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) currentInput = Vector2.down;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) currentInput = Vector2.left;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) currentInput = Vector2.right;

        if ((Vector2)transform.position == dest && !blocked())
        {
            lastInput = currentInput;
            dest = (Vector2)transform.position + currentInput;
            dustTrail.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
        }

        if (blocked()) dustTrail.gameObject.GetComponent<ParticleSystem>().enableEmission = false;

        transform.position = Vector2.Lerp((Vector2)transform.position, dest, speed * Time.deltaTime);
    }
 
    private bool blocked() //check if blocked by wall
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + currentInput, transform.position, 0.1f);
        if (!hit.collider) return false;
        return (hit.transform.gameObject.CompareTag("wall"));
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
    }

    public void eat()
    {
        Debug.Log("eat");
    }

}