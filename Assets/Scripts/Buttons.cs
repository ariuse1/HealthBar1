using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Heallth _health; 
    [SerializeField] private float _damage = 10f; 
    [SerializeField] private float _treatment = 10f; 
 
    public void Increase()
    {        
        _health.TakeHealth(_treatment);
    }

    public void Decrease()
    {
        _health.TakeDamage(_damage);
    }
}
