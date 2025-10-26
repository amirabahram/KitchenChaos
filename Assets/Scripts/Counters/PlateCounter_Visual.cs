using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounter_Visual : MonoBehaviour
{
    [SerializeField] PlateCounter plateCounter;
    [SerializeField] Transform platePrefab;
    [SerializeField] Transform spawnPoint;
    private List<GameObject> plates;

    private void Awake()
    {
        plates = new List<GameObject>();
        plateCounter.OnPlateSpawn += PlateCounter_OnPlateSpawn;
    }

    private void PlateCounter_OnPlateSpawn(object sender, EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(platePrefab, spawnPoint);
        float plateOffsetY = 0.1f;
        plateVisualTransform.localPosition = new Vector3 (0, plateOffsetY*plates.Count, 0);
        plates.Add(plateVisualTransform.gameObject);
    }
}
