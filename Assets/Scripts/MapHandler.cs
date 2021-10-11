using UnityEngine;

public class MapHandler : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private GameObject circle_prefab;

    // Start is called before the first frame update
    void Start()
    {
        // GameObject obj1 = Instantiate(circle_prefab, new Vector3(-3, 0, 0), Quaternion.identity);
        // Spawner obj1_attributes = obj1.GetComponent<Spawner>();
        // obj1_attributes.Owner = 1;
        // obj1.GetComponent<SpriteRenderer>().color = Color.red;

        // GameObject obj2 = Instantiate(circle_prefab, new Vector3(0, 0, 0), Quaternion.identity);
        // Spawner obj5_attributes = obj2.GetComponent<Spawner>();
        // obj5_attributes.Owner = 0;
        // obj5_attributes.Spawn_rate = 0;
        // obj5_attributes.Spawned_units = 40;
        // obj2.GetComponent<SpriteRenderer>().color = Color.gray;

        // GameObject obj3 = Instantiate(circle_prefab, new Vector3(3, 0, 0), Quaternion.identity);
        // Spawner obj3_attributes = obj3.GetComponent<Spawner>();
        // obj3_attributes.Owner = 2;
        // obj3.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
