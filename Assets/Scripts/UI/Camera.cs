using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform Astronauta;
    [SerializeField] float alturaMin = 0f;
    [SerializeField] float alturaMax = 20f;
    [SerializeField] float delay = 0.1f;

    


      void LateUpdate()
{
    float LimiteDeAltura = Mathf.Clamp(Astronauta.position.y, alturaMin, alturaMax);

    if (LimiteDeAltura < transform.position.y)
        LimiteDeAltura = Mathf.Lerp(transform.position.y, LimiteDeAltura, delay * Time.deltaTime);

    transform.position = new Vector3(transform.position.x, LimiteDeAltura, transform.position.z);
}

}
