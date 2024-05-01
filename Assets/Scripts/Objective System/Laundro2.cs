using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laundro2 : MonoBehaviour
{
    public Laundromat lm;

    [SerializeField]
    private GameObject indicator;

    [SerializeField]
    private Material on_mat;

    [SerializeField]
    private Material off_mat;

    [SerializeField]
    private Material done_mat;

    [SerializeField]
    private AudioSource dryerSounds;

    [SerializeField]
    private AudioSource alarm;

    [SerializeField]
    private float waitDuration;

    private bool playerInRange;
    public bool startedCycle;
    public bool activateMarker;
    public bool primeAudio;

    public ObjectiveManager om;
    private Objective obj;

    private void Start()
    {
        obj = om.GetObjective("Laundromat");
        indicator.GetComponent<Renderer>().material = off_mat;
        dryerSounds.loop = true;
        startedCycle = false;
        activateMarker = false;
        primeAudio = true;
        dryerSounds.time = 4;
        alarm.time = 9;
    }

    private void Update()
    {
        if (lm.cycleComplete)
        {
            activateMarker = true;
            if (primeAudio && playerInRange && Input.GetKeyDown(KeyCode.E))
                StartCoroutine(DryerCycle());
        }
        
    }

    IEnumerator DryerCycle()
    {
        Debug.Log("Starting Second Cycle");
        indicator.GetComponent<Renderer>().material = on_mat;
        dryerSounds.Play();
        startedCycle = true;
        yield return new WaitForSeconds(waitDuration);
        dryerSounds.Stop();
        alarm.Play();
        Debug.Log("Second Cycle finished");
        indicator.GetComponent<Renderer>().material = done_mat;
        primeAudio = false;
        yield return new WaitUntil(() => playerInRange && Input.GetKeyDown(KeyCode.E));
        om.CompleteObjective("Laundromat");
        alarm.Stop();
        dryerSounds.Stop();
        indicator.GetComponent<Renderer>().material = off_mat;
        activateMarker = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Laundromat detected Player");
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player left Laundromat boundary");
        playerInRange = false;
    }
}
