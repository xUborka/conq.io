using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private GameObject spawned_units_text;
    public float speed;
    public int units;
    public GameObject end;
    public int owner;
    public bool started;
    public int id;


    private Vector2 startpos;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        timer = 0.0f;
        spawned_units_text.GetComponent<TextMeshProUGUI>().SetText($"{units}");
    }

    // Update is called once per frame
    void Update()
    {
        spawned_units_text.GetComponent<TextMeshProUGUI>().SetText($"{units}");
        if (started){
            timer += Time.deltaTime;
            Vector3 from = new Vector3(transform.position.x, transform.position.y, 5);
            Vector3 to = new Vector3(end.transform.position.x, end.transform.position.y, 5);
            Vector3 tmp = Vector3.MoveTowards(from, to, speed * Time.deltaTime);
            transform.position = tmp;

            if (Vector2.Distance(transform.position, end.transform.position) < .6f){
                Spawner target_spawner = end.GetComponent<Spawner>();
                int value = units;
                if (target_spawner.Owner != owner){
                    value *= -1;
                }
                target_spawner.Spawned_units += value;
                if (target_spawner.Spawned_units < 0) {
                    target_spawner.Spawned_units += 2 * Mathf.Abs(target_spawner.Spawned_units);
                    target_spawner.Owner = owner;
                    target_spawner.ResetLineRenderer();
                    end.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
                }
                Destroy(gameObject);
            }
        }
        spawned_units_text.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
    }
}
