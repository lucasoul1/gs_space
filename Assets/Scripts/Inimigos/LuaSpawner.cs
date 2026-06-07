using System.Collections;
using UnityEngine;

public class LuaSpawner : MonoBehaviour
{
    private Vector2[] posicoes = new Vector2[3];
    [SerializeField] private GameObject prefab;
    private float tempo = 10;

    void Start()
    { 
        posicoes[0].x = -2.29f;
        posicoes[0].y = 28f;
        posicoes[1].x = -0.05f;
        posicoes[1].y = 28f;
        posicoes[2].x = 2f;
        posicoes[2].y = 28f;
        StartCoroutine(spawnar());
    }

    IEnumerator spawnar()
{
    yield return new WaitForSeconds(5);

    while (true)
    {
        Instantiate(prefab, posicoes[Random.Range(0, 3)], Quaternion.identity);
        yield return new WaitForSeconds(tempo);
    }
}
}