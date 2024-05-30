using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrenth;
    public LogicScript logic;
    public bool isDogAlive = true;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    private Sprite originalSprite;
    public float swingDelay;
    // Start is called before the first frame update
    void Start()
    {
        originalSprite = spriteRenderer.sprite;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isDogAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrenth;
            StartCoroutine(ChangeSpriteTemporarily());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isDogAlive = false;
    }

    IEnumerator ChangeSpriteTemporarily()
    {
        spriteRenderer.sprite = newSprite;
        yield return new WaitForSeconds(swingDelay);
        spriteRenderer.sprite = originalSprite;
    }
}
