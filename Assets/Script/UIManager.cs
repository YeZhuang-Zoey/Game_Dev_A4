using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Text score;
    Text time;
    Tweener tweener;
    public GameObject cheese;
    private List<GameObject> itemList;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        itemList = new List<GameObject>();
        itemList.Add(cheese);

        tweener = GetComponent<Tweener>();

        score = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        time = GameObject.FindGameObjectWithTag("time").GetComponent<Text>();

        var highest_score = PlayerPrefs.GetString("score", "0");
        var timer = PlayerPrefs.GetString("time", "00:00:00");

        if (highest_score != "0" && timer != "00:00:00")
        {
            score.text = highest_score;
            time.text = timer;
        }

        StartCoroutine(CheeseCoroutine());
    }

    IEnumerator CheeseCoroutine()
    {
        var cheese = itemList[0];

        while (true)
        {
            yield return new WaitForSeconds(2.0f);

            Move(cheese, new Vector3(2f, 0f), 2f);
            yield return new WaitForSeconds(2.0f);

            Move(cheese, new Vector3(-4f, 0f), 2f);
            yield return new WaitForSeconds(2.0f);

            Move(cheese, new Vector3(4f, 0f), 2f);
            yield return new WaitForSeconds(2.0f);

            Move(cheese, new Vector3(-2f, 0f), 2f);
            yield return new WaitForSeconds(2.0f);

        }
    }

    void Move(GameObject item, Vector3 vector, float duration = 0.25f)
    {
        AddTweenToPosition(item, item.transform.position + vector, duration);
    }

    void AddTweenToPosition(GameObject item, Vector3 position, float duration)
    {
        tweener.AddTween(item.transform, item.transform.position, position, duration);
    }

    void Update()
    {

    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadFirstScene()
    {
        StopAllCoroutines();
        SceneManager.LoadSceneAsync(1);
    }

    /**
    public void LoadSecondScene()
    {
        StopAllCoroutines();
        SceneManager.LoadSceneAsync(2);
    }
    **/
}
