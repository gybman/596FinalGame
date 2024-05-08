using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGate : MonoBehaviour
{
    public static FinalGate Instance { get; private set; } // Singleton instance 
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField]
    private ObjectiveManager oM;
    [SerializeField]
    private GameObject barrier;
    [SerializeField]
    private GameObject marker;


    public enum s { INACTIVE, ACTIVE, DONE, TERMINATED}
    public s state;

    private void Start()
    {
        state = s.INACTIVE;
    }

    private void Update()
    {
        switch (state)
        {
            case s.INACTIVE:
                if (oM.final_objective_active)
                    state = s.ACTIVE;
                break;


            case s.DONE:
                if (barrier.activeSelf)
                    barrier.SetActive(false);
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (state == s.ACTIVE)
            {
                if (!marker.activeSelf)
                    marker.SetActive(true);
                
                state = s.DONE;
                marker.SetActive(false);
            }
        }
    }
}
