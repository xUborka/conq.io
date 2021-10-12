using UnityEngine;
using TMPro;

public class PowerBarScript : MonoBehaviour
{
    [SerializeField] private GameObject circles;
    [SerializeField] private GameObject my_start;
    [SerializeField] private GameObject my_mid;
    [SerializeField] private GameObject my_end;
    [SerializeField] private GameObject my_text;
    [SerializeField] private GameObject en_start;
    [SerializeField] private GameObject en_mid;
    [SerializeField] private GameObject en_end;
    [SerializeField] private GameObject en_text;
    [SerializeField] private GameObject npc_mid;
    [SerializeField] private GameObject npc_text;
    // Start is called before the first frame update
    void Start()
    {
        npc_text.GetComponent<TextMeshProUGUI>().SetText($"1");
        npc_text.transform.position = Camera.main.WorldToScreenPoint(npc_mid.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float mine = 0.0f;
        float npc = 0.0f;
        float enemy = 0.0f;
        for (int i = 0; i < circles.transform.childCount; ++i){
            Spawner current_circle = circles.transform.GetChild(i).gameObject.GetComponent<Spawner>();
            if (current_circle.Owner == 0){
                npc += current_circle.Spawned_units;
            } else if (current_circle.Owner == 1){
                mine += current_circle.Spawned_units;
            } else if (current_circle.Owner == 2){
                enemy += current_circle.Spawned_units;
            }
        }
        float sum = mine + npc + enemy;
        mine /= sum;
        npc /= sum;
        enemy /= sum;
        my_mid.transform.localScale = new Vector3(mine * 7.4f, 1.0f, 1.0f);
        npc_text.transform.position = Camera.main.WorldToScreenPoint(npc_mid.transform.position);
        en_text.transform.position = Camera.main.WorldToScreenPoint(en_mid.transform.position);
        my_text.transform.position = Camera.main.WorldToScreenPoint(my_mid.transform.position);
    }
}
