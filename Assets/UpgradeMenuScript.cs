using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UpgradeMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject parent_node;
    [SerializeField] private GameObject upgrade_object;
    [SerializeField] private GameObject upgrade_text;

    List<int> upgrade_prices = new List<int>();

    private bool display = false;

    public bool Display { get => display; set => display = value; }

    // Start is called before the first frame update
    void Start()
    {
        Display = false;
        upgrade_prices.Add(10); // Price from 0 to 1
        upgrade_prices.Add(15); // Price from 1 to 2
        upgrade_prices.Add(20); // Price from 2 to 3
        upgrade_prices.Add(25); // Price from 3 to 4
        upgrade_prices.Add(30); // Price from 4 to 5
        upgrade_text.GetComponent<TextMeshProUGUI>().SetText($"{upgrade_prices[parent_node.GetComponent<Spawner>().Spawn_rate]}");
        upgrade_text.transform.position = Camera.main.WorldToScreenPoint(upgrade_object.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Display){
            this.transform.localScale = new Vector3(1, 1, 1);
        } else {
            this.transform.localScale = new Vector3(0, 0, 1);
        }
        if (parent_node.GetComponent<Spawner>().Owner == 1)
        {
            if (parent_node.GetComponent<Spawner>().Spawn_rate < upgrade_prices.Count){
                upgrade_text.GetComponent<TextMeshProUGUI>().SetText($"{upgrade_prices[parent_node.GetComponent<Spawner>().Spawn_rate]}");
                if (parent_node.GetComponent<Spawner>().Spawned_units < upgrade_prices[parent_node.GetComponent<Spawner>().Spawn_rate])
                {
                    upgrade_object.GetComponent<SpriteRenderer>().color = Color.red;
                } else {
                    upgrade_object.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
            upgrade_text.transform.position = Camera.main.WorldToScreenPoint(upgrade_object.transform.position);

            if(Input.GetMouseButtonDown(0)){
                Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mouse_pos_2d = new Vector2(mouse_pos.x, mouse_pos.y);
                RaycastHit2D raycastHit = Physics2D.Raycast(mouse_pos_2d, Vector2.zero);
                if (raycastHit.transform != null &&
                    raycastHit.transform.gameObject == upgrade_object)
                {
                    int spawn_rate = parent_node.GetComponent<Spawner>().Spawn_rate;
                    if (spawn_rate < upgrade_prices.Count &&
                        parent_node.GetComponent<Spawner>().Spawned_units >= upgrade_prices[spawn_rate])
                    {
                        parent_node.GetComponent<Spawner>().Spawn_rate += 1;
                        parent_node.GetComponent<Spawner>().Spawned_units -= upgrade_prices[spawn_rate];
                        display = false;
                    }
                }
            }
        }
    }
}
