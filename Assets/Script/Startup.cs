using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startup : MonoBehaviour
{
    public Slider Slider;
    private AsyncOperation async;
    private int number = 0;
    private int num = 0;
    private void Start()
    {
        Slider.value = 0;
        StartCoroutine("start");
    }

    void Update()
    {
        Slider.value = number / 100f;
    }

    private IEnumerator start()
    {
        async = SceneManager.LoadSceneAsync("SampleScene");
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            num = (int)async.progress * 100;
            while (number < num)
            {
                ++number;
                yield return new WaitForSeconds(0);
            }
        }

        num = 100;
        while (number < num)
        {
            ++number;
            yield return new WaitForSeconds(0);
        }
        async.allowSceneActivation = true;
    }
}