using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject1 : MonoBehaviour
{ 
    public GameObject elements2;
    SpriteRenderer _render;
    GameController gameController;

    void Start()
    {
        _render = gameObject.GetComponent<SpriteRenderer>();
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.transform.gameObject.tag == "elements2" && hit.collider != null)
            {
                GameObject click_obj = hit.transform.gameObject;
                _render.color = Color.black;
                Debug.Log(click_obj.name);
                StartCoroutine("FadeOut");

                gameController.GetScore();
            }

        }
    }

    IEnumerator FadeOut()
    {
        int i = 10;
        while (i > 0)
        {
            i -= 1;
            float f = i / 10.0f;
            Color c = _render.material.color;
            c.a = f;
            _render.material.color = c;
            yield return new WaitForSeconds(0.05f);
            Destroy(gameObject, 3);
        }
    }

    //������Ʈ�� Ŭ���� ��, ������Ʈ�� �����.
    //����� ������Ʈ�� �κ��丮�� ������. (����� ������Ʈ�� ui�� �����Ǵ� ������Ʈ���� ��ȣ�ۿ��� �ʿ���)
    //������ ������Ʈ�� �κ��丮�� ���� �� ������ ���̺��.
    //��� ������Ʈ�� �κ��丮�� ������ ������ �����.

}
