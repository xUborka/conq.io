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
    [SerializeField] private int owner = 0;
    [SerializeField] private float menu_speed = 0.5f;

    [Header("Links")]
    [SerializeField] private GameObject spawned_units_text;
    [SerializeField] private GameObject projectile;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] public GameObject send_target;
    [SerializeField] public GameObject menu_object;

    private float spawn_timer;
    private float menu_timer;
    private float send_timer;

    private bool count_menu;
    public bool menu_displayed;

    public int get_owner(){
        return owner;
    }

    public void set_owner(int o){
        owner = o;
    }

    public void update_spawned_units(int value){
        spawned_units += value;
    }

    public int get_spawned_units(){
        return spawned_units;
    }

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
                    spawn_rate += 1;
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

    // Start is called before the first frame update
    void Start()
    {
        spawn_timer = 0.0f;
        menu_timer = 0.0f;
        send_timer = 0.0f;
        count_menu = false;
        menu_displayed = false;
        lineRenderer.positionCount = 2;
        spawned_units_text.GetComponent<TextMeshProUGUI>().SetText($"{spawned_units}");
        spawned_units_text.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        spawn_timer += Time.deltaTime;
        send_timer += Time.deltaTime;

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

        if (spawn_timer >= spawn_speed)
        {
            spawn_timer -= spawn_speed;
            spawned_units += spawn_rate;
        }

        if (menu_timer >= menu_speed)
        {
            menu_object.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 1), new Vector3(1, 1, 1), menu_timer * 1.3f);
            menu_displayed = true;
        }

        if (send_timer >= send_speed)
        {
            send_timer -= send_speed;
            if (send_target != null && spawned_units >= throughput)
            {
                GameObject new_projectile = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, 5), Quaternion.identity);
                new_projectile.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
                ProjectileScript projectile_attributes = new_projectile.GetComponent<ProjectileScript>();
                projectile_attributes.owner = owner;
                projectile_attributes.end = send_target;
                projectile_attributes.units = throughput;
                spawned_units -= throughput;
                projectile_attributes.started = true;
            }
        }

        spawned_units_text.GetComponent<TextMeshProUGUI>().SetText($"{spawned_units}");
    }
}
