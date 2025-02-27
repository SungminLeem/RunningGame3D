using UnityEngine;

public class AIController : MonoBehaviour
{
    public float aiSpeed = 4.5f;
    private float remainingDistance = 300f;
    private bool raceStarted = false;

    void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            raceStarted = true;
        }
    }

    void Update()
    {
        if (raceStarted && remainingDistance > 0)
        {
            transform.Translate(Vector3.forward * aiSpeed * Time.deltaTime);
            remainingDistance -= aiSpeed * Time.deltaTime;
        }
    }
}
