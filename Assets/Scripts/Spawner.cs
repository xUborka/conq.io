using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int spawn_rate = 1;
    [SerializeField] private float spawn_speed = 1.0f;
    [SerializeField] private int throughput = 1;
    [SerializeField] private int spawned_units = 0;
    [SerializeField] private int owner = 0;
    [SerializeField] private float menu_speed = 0.5f;

    [Header("Links")]
    [SerializeField] private GameObject spawned_units_text;
    [SerializeField] private GameObject projectile;
    [SerializeField] public GameObject menu_object;

    private float spawn_timer;
    private float menu_timer;

    private bool count_menu;
    public bool menu_displayed;

    public int Spawn_rate { get => spawn_rate; set => spawn_rate = value; }
    public float Spawn_speed { get => spawn_speed; set => spawn_speed = value; }
    public int Throughput { get => throughput; set => throughput = value; }
    public int Spawned_units { get => spawned_units; set => spawned_units = value; }
    public int Owner { get => owner; set => owner = value; }
    public float Menu_speed { get => menu_speed; set => menu_speed = value; }

    void OnMouseDown(){
        count_menu = true;
    }

    void OnMouseUp(){
        if (menu_displayed){
            Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(new Vector2(mouse_pos.x, mouse_pos.y), Vector2.zero);
            if (raycastHit.collider != null && raycastHit.transform != null)
            {
                if (raycastHit.transform.gameObject.name == "Left_SpawnRate"){
                    Spawn_rate += 1;
                }
                if (raycastHit.transform.gameObject.name == "Right_Throughput"){
                    throughput += 1;
                }
            }
        }
        count_menu = false;
        menu_timer = 0.0f;
        menu_object.transform.localScale = new Vector3(0, 0, 1);
        menu_displayed = false;
    }

    public void send_projectile_to_target(GameObject target)
    {
        if (target != null && Spawned_units > 0)
        {
            GameObject parent = GameObject.Find("Projectiles");
            GameObject new_projectile = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, 5), Quaternion.identity);
            new_projectile.transform.parent = parent.transform;
            new_projectile.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            ProjectileScript projectile_attributes = new_projectile.GetComponent<ProjectileScript>();
            projectile_attributes.owner = Owner;
            projectile_attributes.units = Spawned_units;
            projectile_attributes.end = target;
            Spawned_units = 0;
            projectile_attributes.started = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spawn_timer = 0.0f;
        menu_timer = 0.0f;
        count_menu = false;
        menu_displayed = false;
        spawned_units_text.GetComponent<TextMeshProUGUI>().SetText($"{Spawned_units}");
        spawned_units_text.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        spawn_timer += Time.deltaTime;

        if (count_menu){
            Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(new Vector2(mouse_pos.x, mouse_pos.y), Vector2.zero);
            if (raycastHit.collider != null && raycastHit.transform != null)
            {
                if (gameObject == raycastHit.transform.gameObject){
                    menu_timer += Time.deltaTime;
                }
            }
        }

        if (spawn_timer >= Spawn_speed)
        {
            spawn_timer -= Spawn_speed;
            Spawned_units += Spawn_rate;
        }

        if (menu_timer >= Menu_speed)
        {
            menu_object.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 1), new Vector3(1, 1, 1), menu_timer * 1.3f);
            menu_displayed = true;
        }

        spawned_units_text.GetComponent<TextMeshProUGUI>().SetText($"{Spawned_units}");
        spawned_units_text.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
    }
}
