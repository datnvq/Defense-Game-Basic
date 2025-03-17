using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    //public GameObject heroPrefab;

    //public Transform myTransForm;
    //public SpriteRenderer sp;
    //public Demo demoScript;

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

    private void OnCollisionEnter2D(Collision2D colTarget)
    {
        Debug.Log(gameObject.GetComponent<SpriteRenderer>().color = Color.red);
        Debug.Log("Đã va chạm với nhau");
    }
    private void OnCollisionExit2D(Collision2D colTarget)
    {
        Debug.Log(gameObject.GetComponent<SpriteRenderer>().color = Color.white);
        Debug.Log("Đã va chạm với nhau");
    }
}
