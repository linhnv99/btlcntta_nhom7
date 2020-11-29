using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    Animator m_Animator;
    private void OnEnable()
    {
        m_Animator = this.GetComponent<Animator>();
        m_Animator.SetBool("OnOff", false);
    }

    public void Interact()
    {
        bool isOpen = m_Animator.GetBool("OnOff");
        if (isOpen) m_Animator.SetBool("OnOff", false);
        else m_Animator.SetBool("OnOff", true);
    }
}
