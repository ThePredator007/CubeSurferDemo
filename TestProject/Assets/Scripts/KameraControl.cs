using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraControl : MonoBehaviour
{

    [SerializeField]
    GameObject PlayerCube;

    private Vector3 offset;
    void Start()
    {
        offset = transform.position - PlayerCube.transform.position; // offset ile arada ki mesafeyi alýyoruz

    }

    void LateUpdate()
    {
        transform.position = PlayerCube.transform.position + offset; // arada ki mesefayi (offset)i ekleyince kamera player obejmiz ile mesafesini korumuþ oluyor
    }
}
