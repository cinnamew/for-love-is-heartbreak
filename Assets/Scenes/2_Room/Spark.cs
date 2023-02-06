// =================================	
// Namespaces.
// =================================

using UnityEngine;

// =================================	
// Define namespace.
// =================================
/*namespace ParticleSystems
    {

            // =================================	
            // Classes.
            // =================================

            //[ExecuteInEditMode]
            [System.Serializable]

            //[RequireComponent(typeof(TrailRenderer))]*/

            public class Spark : MonoBehaviour
            {
                // =================================	
                // Nested classes and structures.
                // =================================

                // ...

                // =================================	
                // Variables.
                // =================================

                // ...

                public float speed = 8.0f;
                public float distanceFromCamera = 5.0f;
                public ParticleSystem ps;

                public void UpdateQualitySettings()
                {
                    //print(QualitySettings.GetQualityLevel());
                    if(QualitySettings.GetQualityLevel() == 0) {
                        ps.Play(true);
                    }else if(QualitySettings.GetQualityLevel() == 1) {
                        ps.Play(false);
                    }else {
                        ps.Stop(true);
                    }
                }


                void Start()
                {
                    //ps.Simulate(1);
                    //print(QualitySettings.GetQualityLevel());
                    UpdateQualitySettings();
                    
                }

                public Camera cam;

                void Update()
                {
                    Vector3 mousePosition = Input.mousePosition;
                    mousePosition.z = distanceFromCamera;

                    Vector3 mouseScreenToWorld = cam.ScreenToWorldPoint(mousePosition);

                    Vector3 position = Vector3.Lerp(transform.position, mouseScreenToWorld, 1.0f - Mathf.Exp(-speed * Time.deltaTime));

                    transform.position = position;
                }


                void LateUpdate()
                {

                }

            }

            // =================================	
            // End namespace.
            // =================================

        //}