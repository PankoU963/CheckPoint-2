using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject nearItem;
    public GameObject itemPrefab;
    public Transform itemParent;


    public void PickUpItem()
    {
        if(nearItem != null)
        {
            Destroy(nearItem);
            GameObject instatiatedItem = Instantiate(itemPrefab, itemParent);

            instatiatedItem.transform.SetParent(itemParent);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            nearItem = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            nearItem = null;
        }
    }

}
