using UnityEngine;

namespace Common.Destruction
{
    [RequireComponent(typeof(Rigidbody))]
    public class DestructibleObjectBase : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float timeToDeleteDestructiblePrefab = 1f;
        [SerializeField] private GameObject destructiblePrefab;
        
        
        protected void DestroyObject()
        {
            var obj = Instantiate(destructiblePrefab);
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            Timer.Timer.StartTimer(timeToDeleteDestructiblePrefab, () => Destroy(obj));
            
            gameObject.SetActive(false);
        }
    }
}
