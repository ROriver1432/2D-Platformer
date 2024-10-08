using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, Examine }
    [SerializeField] public InteractionType type;
    [Header("Examine")]
    public string descriptionText;
    [Header("Custom Event")]
    public UnityEvent customEvent;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 10;
    }

    public void Interact()
    {
        switch (type)
        {
            case InteractionType.PickUp:
                // Add the object to the PickedUpItems list
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                // Disable
                gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                // Call the Examine item in the interaction system
                FindObjectOfType<InteractionSystem>().ExamineItem(this);
                break;
            default:
                Debug.Log("Null Item");
                break;
        }

        // Invoke the custom event
        customEvent.Invoke();
    }
}
