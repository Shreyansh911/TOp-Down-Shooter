using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] BaseGun pistolPrefab;
    [SerializeField] BaseGun dualPistolPrefab;

    BaseGun m_currentGun;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipGun(pistolPrefab);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipGun(dualPistolPrefab);
        }
    }

    void EquipGun(BaseGun newGun)
    {
        if (m_currentGun != null)
            Destroy(m_currentGun.gameObject);
        m_currentGun = Instantiate(newGun, transform);
    }
}
