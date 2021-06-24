using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItem : MonoBehaviour
{
    private Vector3 startPosition;
    private float Speed = 2000f;
  public void Delete()
    {
        startPosition = transform.GetChild(0).position;
        textManagerSC.DeleteTaskFromList(int.Parse(gameObject.name));
        transform.GetChild(1).gameObject.SetActive(false);
        StartCoroutine(StartMotion());
       
    }
    private IEnumerator StartMotion()
    {
        GetComponent<AudioSource>().Play();
        while (transform.GetChild(0).position.x > -300f)
        {
            transform.GetChild(0).position -= Vector3.right * Speed * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
