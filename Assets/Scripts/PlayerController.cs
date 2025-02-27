using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;
    private float remainingDistance = 300f;
    private bool raceStarted = false;
    private GameObject heldItem;

    void Start()
    {
        raceStarted = GameManager.Instance.IsRaceStarted();
    }

    void Update()
    {
        if (raceStarted && remainingDistance > 0)
        {
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
            remainingDistance -= playerSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.T) && heldItem != null)
        {
            ApplyItemToOpponent();
        }

        if (Input.GetKeyDown(KeyCode.E) && heldItem != null)
        {
            ConsumeItem();
        }
    }

    public void IncreaseSpeed(float amount)
    {
        playerSpeed += amount;
    }

    public void IncreaseFat(float amount)
    {
        playerSpeed -= amount;
    }

    void ApplyItemToOpponent()
    {
        AIPlayerController targetAI = GameManager.Instance.GetFrontAI(this);
        if (targetAI != null)
        {
            Item item = heldItem.GetComponent<Item>();
            if (item != null)
            {
                item.ApplyEffect(targetAI);
                Destroy(heldItem);
                heldItem = null;
            }
        }
    }

    void ConsumeItem()
    {
        Item item = heldItem.GetComponent<Item>();
        if (item != null)
        {
            item.ApplyEffect(this);
            Destroy(heldItem);
            heldItem = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (heldItem != null)
            {
                Destroy(heldItem);
            }

            heldItem = other.gameObject;
            other.transform.SetParent(transform);
            other.gameObject.SetActive(false);
        }
    }
}
