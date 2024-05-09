using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class FinalVideo : MonoBehaviour
{
    [SerializeField] VideoPlayer finalScene;
    [SerializeField] VideoPlayer credits;

    public float loadDelay;
    public float transition;

    public static FinalVideo Instance { get; private set; } // Singleton Instance
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(PlayFinale());
    }

    IEnumerator PlayFinale()
    {
        yield return new WaitForSeconds(loadDelay);
        finalScene.Play();
        yield return new WaitForSeconds(1); // padding for condition check
        yield return new WaitUntil(() => !finalScene.isPlaying);
        finalScene.Stop();
        yield return new WaitForSeconds(transition);

        // MOVE
        SceneManager.LoadScene("MainMenu");
        //StartCoroutine(PlayCredits());
    }

    IEnumerator PlayCredits()
    {
        credits.Play();
        yield return new WaitForSeconds(1); // padding for condition check
        yield return new WaitUntil(() => !credits.isPlaying);
        credits.Stop();
    }
}
