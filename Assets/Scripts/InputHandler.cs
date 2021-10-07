using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    public GameObject start_node;
    public LineRenderer lineRenderer;

    public bool blocked;

    void Start()
    {
        start_node = null;
        blocked = false;
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Clicked on something?
        if(Input.GetMouseButtonDown(0)){
            start_node = null;
            Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse_pos_2d = new Vector2(mouse_pos.x, mouse_pos.y);
            RaycastHit2D raycastHit = Physics2D.Raycast(mouse_pos_2d, Vector2.zero);
            if (raycastHit.collider != null && raycastHit.transform != null && raycastHit.transform.GetComponent<Spawner>().Owner == 1)
            {
                start_node = raycastHit.transform.gameObject;
            }
        }

        // Released - do stuff
        if (Input.GetMouseButtonUp(0)){
            if (start_node != null) {
                Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mouse_pos_2d = new Vector2(mouse_pos.x, mouse_pos.y);
                RaycastHit2D raycastHit = Physics2D.Raycast(mouse_pos_2d, Vector2.zero);
                if (raycastHit.collider != null && raycastHit.transform != null && raycastHit.transform.gameObject != start_node)
                {
                    if (!blocked){
                        GameObject end_node = raycastHit.transform.gameObject;
                        if (end_node.layer == LayerMask.NameToLayer("Circles")){
                            start_node.GetComponent<Spawner>().send_projectile_to_target(end_node);
                        }
                    }
                }
                lineRenderer.SetPosition(0, new Vector3(start_node.transform.position.x, start_node.transform.position.y, 10));
                lineRenderer.SetPosition(1, new Vector3(start_node.transform.position.x, start_node.transform.position.y, 10));
                start_node = null;
            }
        }

        if (start_node != null){
            if (!start_node.GetComponent<Spawner>().menu_displayed){
                lineRenderer.SetPosition(0, new Vector3(start_node.transform.position.x, start_node.transform.position.y, 10));
                Vector2 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                lineRenderer.SetPosition(1, new Vector3(mouse_position.x, mouse_position.y, 10));
                print(mouse_position);
                LayerMask mask = LayerMask.GetMask("Wall");
                RaycastHit2D hitInfo = Physics2D.Linecast(lineRenderer.GetPosition(0), lineRenderer.GetPosition(1), mask);
                if (hitInfo){
                    lineRenderer.startColor = Color.red;
                    lineRenderer.endColor = Color.red;
                    blocked = true;
                } else {
                    lineRenderer.startColor = Color.green;
                    lineRenderer.endColor = Color.green;
                    blocked = false;
                }
            }
        } else {
            lineRenderer.SetPosition(0, new Vector3(0.0f, 0.0f, 10));
            lineRenderer.SetPosition(1, new Vector3(0.0f, 0.0f, 10));
        }
    }
}
