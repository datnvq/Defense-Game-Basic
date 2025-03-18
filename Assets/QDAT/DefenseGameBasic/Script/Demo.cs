using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    //public GameObject heroPrefab;

    //public Transform myTransForm;
    //public SpriteRenderer sp;
    //public Demo demoScript;

    float score;

    private void Awake()
    {
        //Debug.Log("Awake");
        //sp = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        //Debug.Log("OnEnable");
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        //if(heroPrefab != null)
        //{
        //    var heroClone = Instantiate(heroPrefab, new Vector3(3.5f, 1.5f, 0f), Quaternion.identity);
        //    Destroy(heroClone, 3f);
        //}
        //if(sp)
        //{
        //    sp.color = Color.red;
        //}

        //StartCoroutine("DemoCo");
        //Invoke("Work", 3);

        //score += 10;
        //PlayerPrefs.SetFloat("score", score);
        //float scoreCopy = PlayerPrefs.GetFloat("score", 0);
        //Debug.Log(scoreCopy);

        score = PlayerPrefs.GetFloat("score", 0);
        score += 10;
        PlayerPrefs.SetFloat("score", score);
        Debug.Log(score);

    }

    private IEnumerator DemoCo()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Đang xử lí công việc 1");
        yield return new WaitForSeconds(2);
        Debug.Log("Đang xử lí công việc 2");
    }

    private void Work()
    {
        Debug.Log("Cong viec can thuc hien");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
        //Debug.Log(Time.deltaTime);
        //var vectordemo = new Vector2(1, 4);
        //myTransForm.position = new Vector3(2, 1, 0);
        //myTransForm.localScale = new Vector3(3, 3, 0);
    }
    private void OnDisable()
    {
        //Debug.Log("OnDisable");
    }
    private void OnDestroy()
    {
        //Debug.Log("OnDestroy");
    }

    //private void OnCollisionEnter2D(Collision2D colTarget)
    //{
    //    Debug.Log(gameObject.GetComponent<SpriteRenderer>().color = Color.red);
    //    Debug.Log("Đã va chạm với nhau");
    //}
    //private void OnCollisionStay2D(Collision2D collision)
    //{
          //Debug.Log("Đang va chạm với nhau");
    //}
    //private void OnCollisionExit2D(Collision2D colTarget)
    //{
    //    Debug.Log(gameObject.GetComponent<SpriteRenderer>().color = Color.white);
    //    Debug.Log("Đã ngưng va chạm với nhau");
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log($"{gameObject.tag}Đã va chạm với {collision.gameObject.tag}");
    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log("Đang va chạm với nhau");
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("Đã ngưng va chạm với nhau");
    //}
}
