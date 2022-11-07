using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int HP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnDamaged(int damage)
    {
        HP -= damage;
    }
}
