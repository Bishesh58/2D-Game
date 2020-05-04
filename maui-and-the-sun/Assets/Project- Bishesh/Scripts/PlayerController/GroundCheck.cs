using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    [SerializeField] private LayerMask platformLayer; //setting up layerMask


    public bool isGrounded; 
    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = collision != null && (((1 << collision.gameObject.layer) & platformLayer) != 0); //player is touching the ground
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false; //when player is not touching the ground
    }
}
