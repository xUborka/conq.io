using UnityEngine;
using UnityEngine.UI;

public class PowerBarScript : MonoBehaviour
{
    [SerializeField] private GameObject circles;
    [SerializeField] private GameObject projectiles;
    [SerializeField] private GameObject top_bar;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject my_text;
    [SerializeField] private GameObject en_text;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float mine = 0.0f;
        float enemy = 0.0f;
        for (int i = 0; i < circles.transform.childCount; ++i){
            Spawner current_circle = circles.transform.GetChild(i).gameObject.GetComponent<Spawner>();
            if (current_circle.Owner == 1){
                mine += current_circle.Spawned_units;
            } else if (current_circle.Owner == 2){
                enemy += current_circle.Spawned_units;
            }
        }
        for (int i = 0; i < projectiles.transform.childCount; ++i){
            ProjectileScript current_projectile = projectiles.transform.GetChild(i).gameObject.GetComponent<ProjectileScript>();
            if (current_projectile.owner == 1){
                mine += current_projectile.units;
            } else if (current_projectile.owner == 2){
                enemy += current_projectile.units;
            }
        }
        my_text.GetComponent<Text>().text = $"{mine}";
        en_text.GetComponent<Text>().text = $"{enemy}";
        mine /= mine + enemy;
        
        if (mine < 0.15f){
            my_text.GetComponent<Text>().text = "";
        } else if (mine > 0.85f){
            en_text.GetComponent<Text>().text = "";
        }

        slider.value = mine;
        mine -= 0.5f;
        float width = GetComponent<RectTransform>().rect.width;
        my_text.transform.localPosition = new Vector3(Mathf.Lerp(-0.5f*width, mine*width, 0.5f), 0f, 0);
        en_text.transform.localPosition = new Vector3(Mathf.Lerp(mine*width, 0.5f*width, 0.5f), 0f, 0);
    }
}
