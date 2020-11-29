using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayController : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] GameObject selectedObject;
    Vector3 offset;
    int m_Layer;
    private void OnEnable()
    {
        Rect rect = new Rect(0, 0, 200, 100);
        text.fontSize = 16;
        text.alignment = TextAnchor.MiddleCenter;
        text.text = "Press F to Interact";
        text.color = Color.red;
        text.GetComponent<RectTransform>().anchoredPosition = rect.position;
        text.GetComponent<RectTransform>().sizeDelta = rect.size;
        text.gameObject.SetActive(false);
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin,ray.direction, out hit, 1.5f,1<<11| 1<<9 | 1<<10,QueryTriggerInteraction.Collide))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
            Debug.Log("Did not Hit");
            text.gameObject.SetActive(false);
        }
        if (hit.collider != null)
        {
            m_Layer = hit.collider.gameObject.layer;
            if (m_Layer == 9)   GrabInteract(hit);
            else if(m_Layer == 10)  TurnOnOffLightInteract(hit);
            else if(m_Layer == 11)  DoorInteract(hit);
        }
        else
        {
            if (selectedObject != null)
            {
                if(m_Layer == 9)    selectedObject.GetComponent<Rigidbody>().useGravity = true;
                selectedObject = null;
            }
        }
    }

    private void DoorInteract(RaycastHit hit)
    {
        if (!Input.GetKey(KeyCode.F)) text.gameObject.SetActive(true);
        if (selectedObject == null) selectedObject = hit.collider.gameObject;
        if (Input.GetKeyDown(KeyCode.F)) selectedObject.GetComponent<DoorInteract>().Interact();
    }

    private void TurnOnOffLightInteract(RaycastHit hit)
    {
        if(!Input.GetKey(KeyCode.F)) text.gameObject.SetActive(true);
        if (selectedObject == null) selectedObject = hit.collider.gameObject;
        if (Input.GetKeyDown(KeyCode.F)) selectedObject.GetComponent<OnOffLight>().TurnOnOff();
    }

    private void GrabInteract(RaycastHit hit)
    {
        if (!Input.GetKey(KeyCode.F))
        {
            text.gameObject.SetActive(true);
            if (selectedObject != null)
            {
                selectedObject.GetComponent<BoxCollider>().isTrigger = false;
                selectedObject.GetComponent<Rigidbody>().useGravity = true;
                selectedObject = null;
            }
        }
        else
        {
            if (selectedObject == null)
            {
                text.gameObject.SetActive(false);
                selectedObject = hit.collider.gameObject;
                selectedObject.GetComponent<Rigidbody>().useGravity = false;
                selectedObject.GetComponent<BoxCollider>().isTrigger = true;
                offset = selectedObject.transform.position - gameObject.transform.position;
            }
            else
            {

                Vector3 posOrigin = this.gameObject.transform.position;
                Vector3 posDir = this.gameObject.transform.forward;
                offset = posOrigin + posDir;
                offset.y = (offset.y < 0.7f) ? 0.8f : offset.y;
                selectedObject.transform.position = offset;
            }
        }
    }
}
