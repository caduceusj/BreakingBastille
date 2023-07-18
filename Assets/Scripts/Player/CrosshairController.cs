using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    public Color defaultColor; // Cor padrão da crosshair (quando não estiver mirando em inimigo)
    public Color enemyColor;   // Cor da crosshair quando estiver mirando em um inimigo

    private RawImage crosshairImage;

    private void Start()
    {
        crosshairImage = GetComponent<RawImage>();
        //crosshairImage.color = defaultColor;
    }

    private void FixedUpdate()
    {
        // Crie um raio a partir do centro da câmera para frente (direção da mira)
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        // Se o raio atingir um objeto com a tag "Enemy"
        if (Physics.Raycast(ray, out hit)){
            print(hit.transform.gameObject.tag);

        }
        
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Enemy"))
        {
            crosshairImage.color = enemyColor; // Altera a cor da crosshair para a cor de inimigo
        }
        else
        {
            crosshairImage.color = defaultColor; // Volta para a cor padrão
        }
    }
}
