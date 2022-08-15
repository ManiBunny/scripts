using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public abstract class interactor : MonoBehaviour
{
    private void Rest()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public abstract void interact();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<movement_player>().openInteractebleIcon();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<movement_player>().closeInteractebleIcon();
    }
}
