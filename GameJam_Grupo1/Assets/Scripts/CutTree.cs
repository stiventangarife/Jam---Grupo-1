using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().isTouchTree = true;
        }
    }

    private void OnMouseDown()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isTouchTree == true)
        {
            StartCoroutine(TimeDestroyRoutine());
        } 
    }

    IEnumerator TimeDestroyRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.transform.parent.gameObject);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().wood = 5;
    }
}
