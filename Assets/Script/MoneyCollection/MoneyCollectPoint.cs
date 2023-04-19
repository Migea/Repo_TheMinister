using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCollectPoint : MonoBehaviour
{
    public int Value = 100;
    public string Name = "����";
    public string State = "����";
    public bool OnRoit = false;
    public Collider2D Trigger;
    public GameObject Wrapper;
    public RoitSpawnRange RoitSpawnRange;
    public static MoneyCollectManager manager => MoneyCollectManager.Instance;

    public Text text;
    public void Start()
    {
        Wrapper.SetActive(false);
    }
    public void OnContact()
    {
        if (RoitSpawnRange != null) 
            State = RoitSpawnRange.onRoit ? "���" : "����";
        text.text = $"{Name}����Ӫҵ״̬{State}\r\n����˰��<color=green>{Value}</color>��";
        Wrapper.SetActive(true);
        var handler = new MoneyCollectAnimationHandler(Wrapper.GetComponent<RectTransform>(), manager.YChange, manager.duration, manager.delay);
        handler.Play();
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 1);
    }


}
