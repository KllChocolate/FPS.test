using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public Player player;

    public bool stand = true;
    public bool IsCrouch;
    public bool IsProne;

    public void Awake()
    {
        player = gameObject.GetComponentInChildren<Player>();
    }
    public void Crouch()
    {
        //ถ้านั่ง
        if (stand && !IsCrouch && !IsProne)
        {
            stand = false; 
            IsCrouch = true; 
            player.animator.SetBool("IsCrouch", true);
        }
        else if (IsCrouch && !IsProne)
        {
            stand = true;
            IsCrouch = false;
            player.animator.SetBool("IsCrouch", false);

        }
        else if (!IsCrouch && IsProne)
        {
            player.animator.SetBool("IsProneToCrouch", true);
            StartCoroutine(DelayTimeCrouch());  
        }

    }
    public void Prone()
    {
        if (stand && !IsCrouch && !IsProne)
        {
            stand = false;
            IsProne = true;
            player.animator.SetBool("IsProne", true);
        }
        else if (!IsCrouch && IsProne)
        {
            stand = true;
            IsProne = false;
            player.animator.SetBool("IsProne", false);

        }
        else if (IsCrouch && !IsProne)
        {
            player.animator.SetBool("IsCrouchToProne", true);
            StartCoroutine(DelayTimeProne());
        }

    }

    IEnumerator DelayTimeCrouch()
    {
        yield return new WaitForSeconds(1.5f);
        player.animator.SetBool("IsProneToCrouch", false);
        player.animator.SetBool("IsCrouch", true);
        player.animator.SetBool("IsProne", false);
        IsCrouch = true;
        IsProne = false;
    }

    IEnumerator DelayTimeProne()
    {
        yield return new WaitForSeconds(1.5f);
        player.animator.SetBool("IsCrouchToProne", false);
        player.animator.SetBool("IsProne", true);
        player.animator.SetBool("IsCrouch", false);
        IsProne = true;
        IsCrouch = false;
    }
}
