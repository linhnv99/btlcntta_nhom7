using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffLight : MonoBehaviour
{
    [SerializeField] GameObject m_Room;
    [SerializeField] Material green;
    [SerializeField] Material red;

    public void TurnOnOff()
    {
        if(m_Room.activeSelf == true)
        {
            m_Room.SetActive(false);
            this.gameObject.GetComponent<MeshRenderer>().material = red;
        }
        else
        {
            m_Room.SetActive(true);
            this.gameObject.GetComponent<MeshRenderer>().material = green;
        }
        Debug.Log(m_Room.activeSelf);
    }

    
}
