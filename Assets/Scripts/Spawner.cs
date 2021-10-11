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

    [Header("Links")]
    [SerializeField] private GameObject spawned_units_text;
    [SerializeField] private GameObject projectile;
    [SerializeField] public GameObject menu_object;

    private float spawn_timer;

    public int Spawn_rate { get => spawn_rate; set => spawn_rate = value; }
    public float Spawn_speed { get => spawn_speed; set => spawn_speed = value; }
    public int Throughput { get => throughput; set => throughput = value; }
    public int Spawned_units { get => spawned_units; set => spawned_units = value; }
    public int Owner { get => owner; set => owner = value; }

    public void hide_menu(){
        menu_object.GetComponent<UpgradeMenuScript>().Display = false;
    }

    void OnMouseDown(){
    }

    void OnMouseUp(){
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouse_pos_2d = new Vector2(mouse_pos.x, mouse_pos.y);
        RaycastHit2D raycastHit = Physics2D.Raycast(mouse_pos_2d, Vector2.zero);
        if (raycastHit.transform != null &&
            raycastHit.transform.gameObject == this.transform.gameObject && 
            owner == 1)
        {
            menu_object.GetComponent<UpgradeMenuScript>().Display = !menu_object.GetComponent<UpgradeMenuScript>().Display;
            if (spawn_rate >= 5){
                menu_object.GetComponent<UpgradeMenuScript>().Display = false;
            }
        }
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
        spawned_units_text.GetComponent<TextMeshProUGUI>().SetText($"{Spawned_units}");
        spawned_units_text.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        spawn_timer += Time.deltaTime;

        if (spawn_timer >= Spawn_speed)
        {
            spawn_timer -= Spawn_speed;
            Spawned_units += Spawn_rate;
        }

        spawned_units_text.GetComponent<TextMeshProUGUI>().SetText($"{Spawned_units}");
        spawned_units_text.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
    }
}
