using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject player;
    public string movementScript;

    private bool GUIActive;
    private int sceneNum;

    public GameObject BoxName;
    public GameObject BoxText;
    public TMPro.TextMeshProUGUI Name;
    public TMPro.TextMeshProUGUI Text;
    public TMPro.TextMeshProUGUI Click;

    public AudioSource phoneRing;
    public AudioSource aud1a;
    public AudioSource aud1b;
    public AudioSource aud1c;
    public AudioSource aud1d;
    public AudioSource aud1e;
    public AudioSource aud1f;
    public AudioSource aud1g;
    public AudioSource aud1h;
    public AudioSource phoneDisconn;

    public AudioSource aud2a;
    public AudioSource aud2b;
    public AudioSource aud2c;

    public AudioSource aud3a;
    public AudioSource aud3b;

    public AudioSource aud5a;

    public AudioSource aud6a;
    public AudioSource aud6b;

    public AudioSource aud71a;
    public AudioSource aud72a;

    // Start is called before the first frame update
    void Start()
    {
        (player.GetComponent(movementScript) as MonoBehaviour).enabled = false;

        sceneNum = 0;
        
        GUIActive = true;
        BoxName.SetActive(false);
        BoxText.SetActive(false);
        Name.text = "";
        Text.text = "";
        Click.text = "";

        StartCoroutine("Scene1a");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) & GUIActive)
        {
            sceneNum++;
            switch (sceneNum)
            {
                case 1:
                    StartCoroutine("Scene1b");
                    break;
                case 2:
                    StartCoroutine("Scene1c");
                    break;
                case 3:
                    StartCoroutine("Scene1d");
                    break;
                case 4:
                    StartCoroutine("Scene1e");
                    break;
                case 5:
                    StartCoroutine("Scene1f");
                    break;
                case 6:
                    StartCoroutine("Scene1g");
                    break;
                case 7:
                    StartCoroutine("Scene1h");
                    break;
                case 8:
                    phoneDisconn.Play();
                    BoxName.SetActive(false);
                    BoxText.SetActive(false);
                    Name.text = "";
                    Text.text = "";
                    Click.text = "";
                    GUIActive = false;
                    (player.GetComponent(movementScript) as MonoBehaviour).enabled = true;
                    sceneNum = 0;
                    break;
            }
        }
    }

    IEnumerator Scene1a()
    {
        phoneRing.Play();
        yield return new WaitForSeconds(3f);

        BoxName.SetActive(true);
        BoxText.SetActive(true);

        Name.text = "JUNIA";
        Text.text = "Hey Meg, where are you? I can't see your car anywhere.";
        Click.text = "CLICK TO CONTINUE";
        aud1a.Play();
        yield break;
    }

    IEnumerator Scene1b()
    {
        aud1a.Stop(); 
        Name.text = "MEG";
        Text.text = "Wait, I thought I told you. I can't tonight. I'm at my sister's right now to look \nafter her kids.";
        aud1b.Play();
        yield break;
    }

    IEnumerator Scene1c()
    {
        aud1b.Stop(); 
        Name.text = "JUNIA";
        Text.text = "Oh, but you said we we're gonna run errands together and it's kind of late.";
        aud1c.Play();
        yield break;
    }

    IEnumerator Scene1d()
    {
        aud1c.Stop();
        Name.text = "MEG";
        Text.text = "I know, I know. I'm sorry and I promise I'll make it up to you, but I can't \nleave the kids.";
        aud1d.Play();
        yield break;
    }

    IEnumerator Scene1e()
    {
        aud1d.Stop();
        Name.text = "JUNIA";
        Text.text = "It's totally fine. I get it. I guess I'll see you tommorow morning then?";
        aud1e.Play();
        yield break;
    }

    IEnumerator Scene1f()
    {
        aud1e.Stop();
        Name.text = "MEG";
        Text.text = "Yes, for sure. Tomorrow morning.";
        aud1f.Play();
        yield break;
    }

    IEnumerator Scene1g()
    {
        aud1f.Stop();
        Name.text = "MEG";
        Text.text = "Okay, good night then.";
        aud1g.Play();
        yield break;
    }

    IEnumerator Scene1h()
    {
        aud1b.Stop();
        Name.text = "MEG";
        Text.text = "Love you. See you later.";
        aud1h.Play();
        yield break;
    }

}
