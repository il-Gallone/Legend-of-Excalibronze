using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject attackObject;
    public Rigidbody2D rigid2D;
    public float speed = 3;
    float attackSpeed = 0.25f;
    float attackCD = 0;
    float comboSpeed = 0.4f;
    float comboCD = 0;
    int comboStep = 0;
    public int maxCombo = 3;
    public Color normal;
    public Color critcal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attackCD >0)
        {
            attackCD -= Time.deltaTime;
            if(attackCD <= 0)
            {
                attackObject.SetActive(false);
            }
        }
        if(comboCD > 0)
        {
            comboCD -= Time.deltaTime;
            if(comboCD <= 0)
            {
                comboStep = 0;
                attackObject.GetComponent<SpriteRenderer>().color = normal;
                attackObject.GetComponent<AttackBase>().isCritical = false;
            }
        }
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rigid2D.velocity = moveDirection * speed;
        if (Input.GetKeyDown(KeyCode.Mouse0) && attackCD <= 0)
        {
            attackObject.SetActive(true);
            attackCD = attackSpeed;
            comboStep++;
            comboCD = comboSpeed;
            if (comboStep % 2 == 0)
            {
                attackObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                attackObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if(comboStep == maxCombo)
            {
                attackObject.GetComponent<SpriteRenderer>().color = critcal;
                attackObject.GetComponent<AttackBase>().isCritical = true;
                attackCD = comboCD;
            }
        }
    }
}
