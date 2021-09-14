using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int spawn_rate = 1;
    [SerializeField] private float spawn_speed = 1.0f;
    [SerializeField] private float send_speed = 1.0f;
    [SerializeField] private int throughput = 1;
    [SerializeField] private int spawned_units = 0;

    [Header("Links")]
    [SerializeField] private GameObject spawned_units_text;
    [SerializeField] private GameObject projectile;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] public GameObject send_target;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        lineRenderer.positionCount = 2;
        spawned_units_text.GetComponent<TextMeshProUGUI>().SetText($"{spawned_units}");
        spawned_units_text.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= spawn_speed){
            timer -= spawn_speed;
            spawned_units += spawn_rate;
            spawned_units_text.GetComponent<TextMeshProUGUI>().SetText($"{spawned_units}");
        }
    }
}
