using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour
{
    public GameObject prefab;
    public Material[] materials;
    private GameObject balls;
    private int i;
    private bool running;
    void Start()
    {
        balls = new GameObject();
        balls.name = "Balls";
        i = 1;

        StartCoroutine(LaunchBalls());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus) && !running)
        {
            StartCoroutine(LaunchBalls());
        }
    }

    IEnumerator LaunchBalls()
    {
        running = true;
        while (!Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Vector3 pos = new Vector3(Random.Range(-4.5f, 4.5f), 10, Random.Range(-4.5f, 4.5f));
            GameObject ball = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
            ball.name = "Ball" + i.ToString();
            ball.transform.SetParent(balls.transform);

            Renderer rend = ball.GetComponent<MeshRenderer>();
            rend.material = materials[Random.Range(0, materials.Length)];
            yield return new WaitForSeconds(.01f);
            i++;
        }
        running = false;
    }
}
