using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlat : MonoBehaviour
{
    public float fallDelay = 0.5f;
    public float returnDelay = 2f;
    private Vector3 startPosition;
    private Renderer renderer;
    private Collider collider;

    void Start()
    {
        startPosition = transform.position; 
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			if (collision.gameObject.tag == "Player")
			{
				StartCoroutine(FallAndReturn());
			}
		}
	}

    IEnumerator FallAndReturn()
    {
        yield return new WaitForSeconds(fallDelay);

        // Замість вимкнення об'єкта, робимо його невидимим і вимикаємо коллайдер
        renderer.enabled = false;
        collider.enabled = false;

        yield return new WaitForSeconds(returnDelay);

        // Відновлюємо позицію, робимо об'єкт видимим і вмикаємо коллайдер
        transform.position = startPosition;
        renderer.enabled = true;
        collider.enabled = true;
    }
}
