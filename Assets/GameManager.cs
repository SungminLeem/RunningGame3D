using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private List<AIPlayerController> aiPlayers;
    private PlayerController player;
    private bool raceStarted = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        aiPlayers = new List<AIPlayerController>(FindObjectsByType<AIPlayerController>(FindObjectsSortMode.None));
        player = FindAnyObjectByType<PlayerController>();
    }

    public void StartRace()
    {
        raceStarted = true;
    }

    public bool IsRaceStarted()
    {
        return raceStarted;
    }

    public AIPlayerController GetFrontAI(PlayerController player)
    {
        AIPlayerController frontAI = null;
        float minDistance = float.MaxValue;

        foreach (AIPlayerController ai in aiPlayers)
        {
            float distanceDiff = ai.transform.position.z - player.transform.position.z;
            if (distanceDiff > 0 && distanceDiff < minDistance)
            {
                minDistance = distanceDiff;
                frontAI = ai;
            }
        }
        return frontAI;
    }
}
