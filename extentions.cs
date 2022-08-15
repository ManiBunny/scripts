using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class extentions
{
    public static bool isInteractable(this RaycastHit2D hit)
    {
        return hit.transform.GetComponent<interactor>();
    }
    public static void interact(this RaycastHit2D hit)
    {
        hit.transform.GetComponent<interactor>().interact();
    }
}
