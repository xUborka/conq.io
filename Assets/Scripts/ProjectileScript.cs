using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private GameObject spawned_units_text;
    public float speed = 2.0f;
    public int units = 1;
    public GameObject end;
    public int owner;
    public bool started;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        spawned_units_text.GetComponent<TextMeshProUGUI>().SetText($"{units}");
    }

    // Update is called once per frame
    void Update()
    {
        if (started){
            timer += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, end.transform.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, end.transform.position) < 0.5f){
                Spawner target_spawner = end.GetComponent<Spawner>();
                int value = units;
                if (target_spawner.get_owner() != owner){
                    value *= -1;
                }
                target_spawner.update_spawned_units(value);
                if (target_spawner.get_spawned_units() < 0) {
                    target_spawner.update_spawned_units(2 * Mathf.Abs(target_spawner.get_spawned_units()));
                    target_spawner.set_owner(owner);
                    end.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
                }

                Destroy(gameObject);
            }
        }
        spawned_units_text.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
    }
}
