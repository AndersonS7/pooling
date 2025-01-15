using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Pool.PoolingManager
{
    public class PoolingManager : MonoBehaviour
    {
        public static PoolingManager instance;
        public int maxClonesSpawn;

        private int totalClonesGenerated;
        private int totalActiveClones;
        private int totalDeactivatedClones;

        public List<GameObject> clones;
        public List<GameObject> activeClones;
        public List<GameObject> clonesDeactivated;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            clones = new List<GameObject>();
            activeClones = new List<GameObject>();
            clonesDeactivated = new List<GameObject>();
        }

        //pooling - cria a lista de objetos pré renderizados 
        public void ObjectPooling(List<GameObject> pooledObject, GameObject prefab, int sizePooling)
        {
            pooledObject.Clear();

            for (int i = 0; i < sizePooling; i++)
            {
                GameObject p = Instantiate(prefab);
                p.SetActive(false);

                pooledObject.Add(p);
            }
        }

        // retorna objeto ativo
        public GameObject GetPooledObjects(List<GameObject> pooledBullets)
        {
            for (int i = 0; i < pooledBullets.Count; i++)
            {
                if (!pooledBullets[i].activeInHierarchy)
                {
                    return pooledBullets[i];
                }
            }

            return null;
        }

        // referencia do instantiate Unity
        ///https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Object.Instantiate.html

        public GameObject Spawn(GameObject prefab)
        {
            if (clones.Count > 0)
            {
                for (int i = 0; i < clones.Count; i++)
                {
                    if (!clones[i].activeInHierarchy)
                    {
                        if (clonesDeactivated.Contains(clones[i]))
                        {
                            clonesDeactivated.Remove(clones[i]);
                            activeClones.Add(clones[i]);
                        }

                        return clones[i];
                    }
                }
            }

            //caso todos os clones já criado tiverem sido ativos
            GameObject clone = Instantiate(prefab);
            clones.Add(clone);
            activeClones.Add(clone);

            totalClonesGenerated = clones.Count;

            return clone;
        }

        // desativa o elemento da lista
        public void Despawn(GameObject clone)
        {
            if (activeClones.Contains(clone))
            {
                activeClones.Remove(clone);
                clonesDeactivated.Add(clone);
                clone.SetActive(false);
            }

        }

        //-- ESSE PROJETO DEVE CONTER --

        // GET -> TOTAL DE CLONES ATIVOS EM SCENA
        public int ActiveClones
        {
            get
            {
                return activeClones.Count;
            }
        }

        // GET -> TOTAL DE CLONES DESATIVADOS EM CENA
        public int ClonesDeactivated
        {
            get
            {
                return clonesDeactivated.Count;
            }
        }

        // GET -> TOTAL DE CLONES GERADOS (CLONES ATIVOS + CLONES DESATIVADOS)
        public int TotalClones
        {
            get
            {
                return totalClonesGenerated;
            }
        }

        // LIST -> COM OS CLONES GERADOS

        // LIST -> COM CLONES ATIVOS

        // LIST -> COM CLONES DESATIVADOS

        // MÉTODO -> ESPAWN DE OBJETOS ASSIM QUE INICIALIZAR

        // MÉTODO -> ESPAWN PARA IR GERANDO NOVOS CLONES E APROVEITANDO OS QUE JÁ EXISTE

        // MÉTODO - CRIAR TODOS AS SOBRECARGAS DO MÉTODO INSTANTIATE

        // MÉTODO ESTUDAR UM ALGORITMO DE POOLING BEM APLICADO AFIM DE GERAR UM SISTEMA EFICIENTE DE RECICLAR OS CLONES

        // TRATAMENTO DE ERRO E DEBUGS

    }
}

