using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LuoiCau : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    Vector3 direction;
    public float speed = 0.2f;

    public bool isMoving;
    private Vector3 _enpos;
    private Vector3 _target;
    public bool huong;

    private bool canCau;
    
    void Update()
    {
        if (TheGameUI.Instance.currentState != State.Stop)
        {
            if (Input.GetMouseButtonDown(0) && !isMoving)
            {
                isMoving = true;
                huong = true;
                _enpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _target = _enpos;
            }
            else if (Vector2.Distance(transform.localPosition, Vector2.zero) < 1f && isMoving && !huong)
            {
                isMoving = false;

                var count = transform.childCount;

                for (int i = 0; i < count; i++)
                {
                    Destroy(transform.GetChild(0).gameObject);
                }
                
                canCau = false;
                TheGameUI.Instance.Check();
            }
            else if (Vector2.Distance(transform.position, _enpos) < 0.3f && isMoving && huong)
            {
                ComeBack();
            }
        }


        direction = _target - transform.position;
    }

    void ComeBack()
    {
        _target = transform.parent.position;
        huong = false;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rigidbody2D.MovePosition(transform.position + direction.normalized * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fish") && !canCau)
        {
            canCau = true;
            col.transform.parent = transform;
            ComeBack();
        }
    }
}