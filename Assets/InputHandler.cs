using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    public GameObject start_node;
    public GameObject end_node;
    public LineRenderer lineRenderer;

    void Start()
    {
        start_node = null;
        end_node = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            start_node = null;
            end_node = null;
            Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse_pos_2d = new Vector2(mouse_pos.x, mouse_pos.y);
            RaycastHit2D raycastHit = Physics2D.Raycast(mouse_pos_2d, Vector2.zero);
            if (raycastHit.collider != null && raycastHit.transform != null)
            {
                start_node = raycastHit.transform.gameObject;
            }
        }
        if (Input.GetMouseButtonUp(0)){
            Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse_pos_2d = new Vector2(mouse_pos.x, mouse_pos.y);
            RaycastHit2D raycastHit = Physics2D.Raycast(mouse_pos_2d, Vector2.zero);
            if (raycastHit.collider != null && raycastHit.transform != null)
            {
                end_node = raycastHit.transform.gameObject;
                start_node.GetComponent<Spawner>().send_target = end_node;
            }
        }

        if (Input.GetMouseButton(0)){
            // Pressed and Held

        } else {
            // Released
            if (end_node == null && start_node != null){
                lineRenderer.SetPosition(0, new Vector3(start_node.transform.position.x, start_node.transform.position.y, 10));
                lineRenderer.SetPosition(1, new Vector3(start_node.transform.position.x, start_node.transform.position.y, 10));
                start_node = null;
            }
        }

        if (start_node != null){
            lineRenderer = start_node.GetComponentInChildren<LineRenderer>();
            lineRenderer.SetPosition(0, new Vector3(start_node.transform.position.x, start_node.transform.position.y, 10));
            if (end_node == null){
                Vector2 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                lineRenderer.SetPosition(1, new Vector3(mouse_position.x, mouse_position.y, 10));
            } else {
                lineRenderer.SetPosition(1, new Vector3(end_node.transform.position.x, end_node.transform.position.y, 10));
            }
        } else {
            lineRenderer = null;
        }
    }
}
