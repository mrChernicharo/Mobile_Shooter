using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] meteor;
    [SerializeField] private float spawnTime;
    private float timer = 0f;
    private int i;

    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPos;

    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            i = Random.Range(0, meteor.Length);

            GameObject obj = Instantiate(meteor[i], new Vector3(Random.Range(maxLeft, maxRight), yPos, 0), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            float size = Random.Range(0.85f, 1.15f);
            obj.transform.localScale = new Vector3(size, size, 1);

            timer = 0;
        }
    }

    private IEnumerator SetBoundaries()
    {
        // accessing mainCam.ViewportToWorldPoint in start doesn't give Cinemachine enough time
        // to adjust the VirtualCamera to the viewport, that's why we create a coroutine here.

        // wait...
        yield return new WaitForSeconds(0.4f);

        // ...then
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0f)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0f)).x;
        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }
}
