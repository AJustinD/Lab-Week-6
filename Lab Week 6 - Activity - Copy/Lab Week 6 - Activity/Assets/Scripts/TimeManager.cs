using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int lastTime = 0;
    private float myTimeScale = 1.0f;
    private float timer = 0.0f;
    Camera MainCamera;

    const float moveWait = 2.0f;
    const float scaleWait = 4.0f;

    [SerializeField]
    private Transform[] transformArray;

    Coroutine myRoutine;
    Coroutine myRoutine2;

    void Start()
    {
        MainCamera = Camera.main;
        MainCamera.enabled = true;
        MainCamera.orthographic = true;
        MainCamera.orthographicSize = 2.5f;
        ResetTime();
    }

    void Update()
    {
        
        timer += Time.deltaTime; 
        Time.timeScale = myTimeScale;

        // this is 60%
        if(timer > lastTime)
        {
            Debug.Log(lastTime);
            lastTime = (int) timer + 1;
        }
        
        /* this is 40%
        if (Time.time > lastTime)
        {
            Debug.Log(lastTime);
            lastTime = (int) Time.time + 1;
        }
        */

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed");
            if(myTimeScale == 1.0f)
            {
                myTimeScale = 0.0f;
            }
            else
            {
                myTimeScale = 1.0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetTime();
        }


        if(myRoutine == null)
        {
            myRoutine = StartCoroutine(MoveObjects());
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            myRoutine2 = null;
            float rand = Random.Range(0.5f, 1.0f);
            if(myRoutine2 == null)
            {
                myRoutine2 = StartCoroutine(RotateObjects(rand));
            }

        }


    }


    void ResetTime()
    {
        timer = 0;
        lastTime = 0;
        InvokeRepeating("ScaleObjects",4,scaleWait);
    }

    private IEnumerator MoveObjects()
    {
        yield return new WaitForSeconds(2);
        transformArray[0].position = new Vector3(transformArray[0].position.x,
                                                 transformArray[0].position.y * -1,
                                                 transformArray[0].position.z);
        transformArray[1].position = new Vector3(transformArray[1].position.x,
                                                 transformArray[1].position.y * -1,
                                                 transformArray[1].position.z);

        yield return new WaitForSeconds(2.0f);
        transformArray[0].position = new Vector3(transformArray[0].position.x * -1,
                                                 transformArray[0].position.y,
                                                 transformArray[0].position.z);
        transformArray[1].position = new Vector3(transformArray[1].position.x * -1,
                                                 transformArray[1].position.y,
                                                 transformArray[1].position.z);

        myRoutine = null;
    }

    private void ScaleObjects()
    {
        Vector3 objectScale1 = transformArray[0].localScale;
        Vector3 objectScale2 = transformArray[1].localScale;
        if (objectScale1.x > 1.5f)
        {
           
            transformArray[0].localScale = new Vector3( (objectScale1.x/1.2f),
                                                        (objectScale1.y/1.2f), 
                                                        (objectScale1.z/1.2f));
            
            transformArray[1].localScale = new Vector3( (objectScale2.x / 1.2f),
                                                        (objectScale2.y / 1.2f),
                                                        (objectScale2.z / 1.2f));
        }
        else
        {
            
            transformArray[0].localScale = new Vector3( (objectScale1.x * 1.2f),
                                                        (objectScale1.y * 1.2f),
                                                        (objectScale1.z * 1.2f));
            transformArray[1].localScale = new Vector3( (objectScale2.x * 1.2f),
                                                        (objectScale2.y * 1.2f),
                                                        (objectScale2.z * 1.2f));
        }
    }
    
    private IEnumerator RotateObjects(float randomDelay)
    {
        yield return new WaitForSeconds(randomDelay);
        transformArray[0].Rotate(0, 0, 90);
        transformArray[1].Rotate(0, 0, 90);

        yield return new WaitForSeconds(randomDelay);
        transformArray[0].Rotate(0, 0, 90);
        transformArray[1].Rotate(0, 0, 90);

        yield return new WaitForSeconds(randomDelay);
        transformArray[0].Rotate(0, 0, 90);
        transformArray[1].Rotate(0, 0, 90);

        yield return new WaitForSeconds(randomDelay);
        transformArray[0].Rotate(0, 0, 90);
        transformArray[1].Rotate(0, 0, 90);

        yield return null;
    }

}
