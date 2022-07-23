using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class PlayerMagneticTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other) {
        CollactableBase i = other.transform.GetComponent<CollactableBase>();
        if(i != null)
        {
            if(i.gameObject.AddComponent<Magnetic>() == null)
            {
                i.gameObject.AddComponent<Magnetic>();
            }
        }
    }
}