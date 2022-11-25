using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private Carro[] _carros;
    private GameObject[] _carrosGO;
    [SerializeField] private Semaforo[] _semaforos;
    [SerializeField] private Step[] _steps;
    [SerializeField] private int carCounter;
    [SerializeField] private int semaforoCounter;

    // Start is called before the first frame update
    void Start()
    {
        _carrosGO = new GameObject[_carros.Length];
        carCounter = 0;

        for(int i = 0; i < _carros.Length; i++)
        {
            _carrosGO[i] = CarPoolManager.Instance.ActivarObjeto(Vector3.zero);
        }

        PosicionarCarros();
    }

    private void PosicionarCarros() 
    {
        for(int i = 0; i < _carros.Length; i++)
        {
            _carrosGO[i].transform.position = new Vector3(
                    _carros[i].x,  0, _carros[i].z
                );
        }
    }

    // Update is called once per frame
  /*  void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){

            // simulando un update en datos
            for(int i = 0; i < _carros.Length; i++){
                _carros[i].x = Random.Range(0f, 10f);
                _carros[i].z = Random.Range(0f, 10f);
            }

            PosicionarCarros();
        }
    }*/

  IEnumerator Posiciones(GeneralInfo datos)
  {
      for (int i = 0; i < datos.Steps.Length; i++)
      {
          _carros = datos.Steps[i].carros;
          PosicionarCarros();
          yield return new WaitForSeconds(0.01f);
      }
  }

    public void EscucharRequestSinArgumentos() {

        print("HUBO UN REQUEST MUY INTERESANTE!");
    }

   public void EscucharRequestConArgumentos(GeneralInfo datos)
    {
        print("DATOS: " + datos);


        _carros = datos.cars;
        _semaforos = datos.semaphores;
        _steps = datos.Steps;
        // invocar PosicionarCarros()
        Start();
        StartCoroutine(Posiciones(datos));
        // CambiarPosicion(datos);
        // PosicionarSemaforos();
    }

   
}
