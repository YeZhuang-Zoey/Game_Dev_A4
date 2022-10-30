using UnityEngine;

public class CherryController : MonoBehaviour
{
    Tween tween;
    const float duration = 25f;

    Vector2 startPos, endPos;
    void Start()
    {
        InvokeRepeating("createCherry", 30, 30); //loop
        Camera camera = Camera.main;

        startPos = Camera.main.ViewportToWorldPoint(new Vector2(1.1f, .5f)); //set the start and end points to be just outside the camera
        endPos = Camera.main.ViewportToWorldPoint(new Vector2(-0.1f, .5f));
        tween = new Tween(transform, startPos, endPos, Time.time, duration);
    }

    void Update()
    {
        moveCherry();
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), tween.EndPos) < 0.05f)
        {
            Destroy(gameObject);
        }
    }
    void moveCherry()
    {
        //if not paused
        float timeFraction = (Time.time - tween.StartTime) / tween.Duration;
        transform.position = Vector2.Lerp(tween.StartPos, tween.EndPos, timeFraction);
    }

}
