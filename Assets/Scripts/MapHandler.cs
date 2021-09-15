using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private GameObject circle_prefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj1 = Instantiate(circle_prefab, new Vector3(-7, -3, 0), Quaternion.identity);
        Spawner obj1_attributes = obj1.GetComponent<Spawner>();
        obj1_attributes.set_owner(0);
        obj1.GetComponent<SpriteRenderer>().color = Color.red;
        GameObject obj2 = Instantiate(circle_prefab, new Vector3(-7, 3, 0), Quaternion.identity);
        Spawner obj2_attributes = obj2.GetComponent<Spawner>();
        obj2_attributes.set_owner(0);
        obj2.GetComponent<SpriteRenderer>().color = Color.red;
        GameObject obj3 = Instantiate(circle_prefab, new Vector3(-2, -2, 0), Quaternion.identity);
        Spawner obj3_attributes = obj3.GetComponent<Spawner>();
        obj3_attributes.set_owner(0);
        obj3.GetComponent<SpriteRenderer>().color = Color.red;
        GameObject obj4 = Instantiate(circle_prefab, new Vector3(-2, 2, 0), Quaternion.identity);
        Spawner obj4_attributes = obj4.GetComponent<Spawner>();
        obj4_attributes.set_owner(0);
        obj4.GetComponent<SpriteRenderer>().color = Color.red;

        GameObject obj5 = Instantiate(circle_prefab, new Vector3(7, -3, 0), Quaternion.identity);
        Spawner obj5_attributes = obj5.GetComponent<Spawner>();
        obj5_attributes.set_owner(1);
        obj5.GetComponent<SpriteRenderer>().color = Color.blue;
        GameObject obj6 = Instantiate(circle_prefab, new Vector3(7, 3, 0), Quaternion.identity);
        Spawner obj6_attributes = obj6.GetComponent<Spawner>();
        obj6_attributes.set_owner(1);
        obj6.GetComponent<SpriteRenderer>().color = Color.blue;
        GameObject obj7 = Instantiate(circle_prefab, new Vector3(2, -2, 0), Quaternion.identity);
        Spawner obj7_attributes = obj7.GetComponent<Spawner>();
        obj7_attributes.set_owner(1);
        obj7.GetComponent<SpriteRenderer>().color = Color.blue;
        GameObject obj8 = Instantiate(circle_prefab, new Vector3(2, 2, 0), Quaternion.identity);
        Spawner obj8_attributes = obj8.GetComponent<Spawner>();
        obj8_attributes.set_owner(1);
        obj8.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
