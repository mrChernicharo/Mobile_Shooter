using UnityEngine;

public class Paralax : MonoBehaviour
{

    [SerializeField] private float paralaxSpeed = 5f;

    private float spriteHeight;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * paralaxSpeed * Time.deltaTime);

        if (transform.position.y < startPos.y - spriteHeight)
        {
            transform.position = startPos;
        }
    }
}
