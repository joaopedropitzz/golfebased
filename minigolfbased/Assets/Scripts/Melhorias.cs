
using UnityEngine;

public class Melhorias : MonoBehaviour
{
    public Transform bola;
    public float raio = 2f;
    public float forca = 20f;
    public float forcaFinal = 40f;

    Rigidbody rb;
    bool atracaoDesligada = false;
    bool foiPuxadoUmaVez = false;

    void Start()
    {
        rb = bola.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (bola == null || rb == null || atracaoDesligada)
            return;

        float d = Vector3.Distance(bola.position, transform.position);

        if (foiPuxadoUmaVez)
        {
            atracaoDesligada = true;
            return;
        }

        if (d > raio)
            return;

        Vector3 dir = (transform.position - bola.position).normalized;

        foiPuxadoUmaVez = true;

        if (d < 0.6f)
            rb.AddForce(dir * forcaFinal, ForceMode.Acceleration);
        else
            rb.AddForce(dir * forca, ForceMode.Acceleration);
    }
}
