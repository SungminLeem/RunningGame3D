using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { SpeedUp, FatIncrease }
    public ItemType itemType;
    public float effectAmount;
    public float throwForce = 5f;

    public void ApplyEffect(PlayerController player)
    {
        if (itemType == ItemType.SpeedUp)
        {
            player.IncreaseSpeed(effectAmount);
            Debug.Log("SpeedUp applied to player");
        }
        else if (itemType == ItemType.FatIncrease)
        {
            player.IncreaseFat(effectAmount);
            Debug.Log("FatIncrease applied to player");
        }
    }

    public void ApplyEffect(AIPlayerController aiPlayer)
    {
        if (itemType == ItemType.SpeedUp)
        {
            aiPlayer.IncreaseSpeed(effectAmount);
            Debug.Log("SpeedUp applied to AI");
        }
        else if (itemType == ItemType.FatIncrease)
        {
            aiPlayer.IncreaseFat(effectAmount);
            Debug.Log("FatIncrease applied to AI");
        }
    }

    public void ThrowItem(Transform thrower)
    {
        transform.parent = null;
        gameObject.SetActive(true);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(thrower.forward * throwForce, ForceMode.Impulse);
            Debug.Log("Item thrown by " + thrower.name);
        }
    }
}
