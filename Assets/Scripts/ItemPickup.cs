using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private float pickupRange = 3f;
    [SerializeField] private Transform handPosition; // dónde se sujeta el arma al recogerla
    private GameObject objectToPickup;
    private GameObject currentWeapon;

    private void Update()
    {
        DetectItemInFront();
    }

    private void DetectItemInFront()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, pickupRange))
        {
            if (hit.collider.CompareTag("Weapon"))
            {
                objectToPickup = hit.collider.gameObject;
                // Aquí podrías mostrar un UI tipo “Presiona F para recoger”
            }
            else
            {
                objectToPickup = null;
            }
        }
        else
        {
            objectToPickup = null;
        }
    }

    public void OnInteractPressed()
    {
        if (objectToPickup != null)
        {
            PickupWeapon(objectToPickup);
        }
    }

    private void PickupWeapon(GameObject weapon)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon); // o suéltala, según prefieras
        }

        currentWeapon = weapon;
        weapon.transform.SetParent(handPosition);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;

        // Desactivar físicas
        if (weapon.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.isKinematic = true;
        }

        weapon.GetComponent<Collider>().enabled = false;
    }
}
