using System;
using System.Collections;
using UI.UIElements.ProgressBar;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [Header("External Dependencies")]
    [SerializeField] private BaseProgressBarController progressBarController;
    [SerializeField] private int currentSceneIndex = 0;
    [SerializeField] private int[] loadSceneOrder = new[] { 1 };
    [SerializeField] private float waitForSeconds = 5;

    private void Start()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        var startTime = Time.time;
        Debug.Log($"StartTime : {startTime}");
        
        var coroutine = StartCoroutine(LoadScenes());
        yield return coroutine;

        coroutine = StartCoroutine(CheckWaitForSeconds(startTime));
        yield return coroutine;
        
        SceneManager.UnloadSceneAsync(currentSceneIndex);
    }

    private IEnumerator LoadScenes()
    {
        Debug.Log("Loading scenes started.");
        var waitForEndOfFrame = new WaitForEndOfFrame();
        foreach (var loadSceneItem in loadSceneOrder)
        {
            var async = SceneManager.LoadSceneAsync(loadSceneItem, LoadSceneMode.Additive);
            while (!async.isDone)
            {
                progressBarController.SetPercentageAmount(async.progress);
                yield return null;
            }

            yield return waitForEndOfFrame;
        }
        Debug.Log("Scenes are loaded.");
    }

    private IEnumerator CheckWaitForSeconds(float startTime)
    {
        var currentTime = Time.time;
        Debug.Log($"CurrentTime : {currentTime}");
        var duration = currentTime - startTime;
        Debug.Log($"Duration : {duration}");
        if (duration >= waitForSeconds)
        {
            yield break;
        }

        var remainingTime = waitForSeconds - duration;
        Debug.Log($"RemainingTime : {remainingTime}");
        yield return new WaitForSeconds((int) remainingTime);
    }
}
