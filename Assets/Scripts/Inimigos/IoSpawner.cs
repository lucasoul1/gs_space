using System.Collections;
using UnityEngine;

public class IoSpawner : MonoBehaviour
{
    private Vector2 posicao;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float posicaoX;
    [SerializeField] private float posicaoY;
    [SerializeField] private float tempo;


    void Start()
    {
        posicao.x = posicaoX;
        posicao.y = posicaoY;
        StartCoroutine(spawnar());
    }

    IEnumerator spawnar()
    {
        yield return new WaitForSeconds(tempo);

        while (true)
        {
            Instantiate(prefab, posicao, Quaternion.identity);
            yield return new WaitForSeconds(tempo);
        }
    }
}