using System;
using TGC.Core.Mathematica;
using TGC.Core.SceneLoader;


namespace TGC.Group.Model
{
    class Car
    {

        private static String MediaPath = "\\Vehiculos\\CamionCemento\\CamionCemento-TgcScene.xml";
        private static float DRAG = 0.1f;
        private static float STEERING_SPEED = 100f;

        private float speed;
        private float acceleration;
        private TgcMesh mesh;
        private TGCVector3 direction;

       // public float Speed { get => speed; set => speed = value; }
       // public float Acceleration { get => acceleration; set => acceleration = value; }
       // public TgcMesh Mesh { get => mesh; set => mesh = value; }
public float Acceleration
        {
            get
            {
                return acceleration;
            }

            set
            {
                acceleration = value;
            }
        }

        public float Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public TgcMesh Mesh
        {
            get
            {
                return mesh;
            }

            set
            {
                mesh = value;
            }
        }

        public void InitializeCar(String MediaDir)
        {

            speed = 0;

            //Cargo el unico mesh que tiene la escena.
            mesh = new TgcSceneLoader().loadSceneFromFile(MediaDir + "\\Vehiculos\\Auto\\Auto-TgcScene.xml").Meshes[0];
            //Defino una escala en el modelo logico del mesh que es muy grande.
            mesh.Scale = new TGCVector3(0.5f, 0.5f, 0.5f);

            direction = new TGCVector3(0f, 0f, -1f);
            //mainMesh.RotateY(150f);
        }

        public TGCVector3 getCarPosition()
        {
            return mesh.Position;
        }

        
        public void rotateDirection(String rotateDir, float ElapsedTime)
        {
            float rotAngle;
            if (rotateDir.Equals("LEFT"))
            {
                rotAngle = -STEERING_SPEED * ElapsedTime * (3.141592654f / 180.0f);
            }
            else
            {
                rotAngle = STEERING_SPEED * ElapsedTime * (3.141592654f / 180.0f);
            }

            mesh.RotateY(rotAngle);
            
        }


        public void Move(float ElapsedTime)
        {

            var z = (float)Math.Cos(mesh.Rotation.Y) * -speed * DRAG;
            var x = (float)Math.Sin(mesh.Rotation.Y) * -speed * DRAG;

            TGCVector3 movement = TGCVector3.Empty;
            movement.Z = z;
            movement.X = x;

            movement *= ElapsedTime;

            mesh.Move(movement);
        }


    }
}
