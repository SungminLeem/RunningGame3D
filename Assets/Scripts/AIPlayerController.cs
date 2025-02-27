using UnityEngine;

public class AIPlayerController : MonoBehaviour
{
    public float aiSpeed = 5f;
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
            transform.Translate(Vector3.forward * aiSpeed * Time.deltaTime);
            remainingDistance -= aiSpeed * Time.deltaTime;
        }
    }

    public void IncreaseSpeed(float amount)
    {
        aiSpeed += amount;
    }

    public void IncreaseFat(float amount)
    {
        aiSpeed -= amount;
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
            ConsumeItem();
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
}
