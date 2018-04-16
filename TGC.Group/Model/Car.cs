using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.Mathematica;
using TGC.Core.SceneLoader;

namespace TGC.Group.Model
{
    class Car
    {

        private static String MediaPath = "\\Vehiculos\\CamionCemento\\CamionCemento-TgcScene.xml";
        private static float DRAG = 0.1f;

        private float speed;
        private float acceleration;
        private float rotation;
        private TgcMesh mesh;
        private TGCVector3 direction;

        public float Speed { get => speed; set => speed = value; }
        public float Acceleration { get => acceleration; set => acceleration = value; }
        public TgcMesh Mesh { get => mesh; set => mesh = value; }
        


        public void InitializeCar(String MediaDir)
        {

            speed = 0;

            //Cargo el unico mesh que tiene la escena.
            mesh = new TgcSceneLoader().loadSceneFromFile(MediaDir + "\\Vehiculos\\CamionCemento\\CamionCemento-TgcScene.xml").Meshes[0];
            //Defino una escala en el modelo logico del mesh que es muy grande.
            mesh.Scale = new TGCVector3(0.5f, 0.5f, 0.5f);

            direction = new TGCVector3(0f, 0f, -1f);
            //mainMesh.RotateY(150f);
        }

        public TGCVector3 getCarPosition()
        {
            return mesh.Position;
        }

        
        public void rotateDirection()
        {
            
        }


        public void Move(float ElapsedTime)
        {
            TGCVector3 movement = TGCVector3.Empty;
            movement.Z = direction.Z * speed * DRAG;

            movement *= ElapsedTime;

            mesh.Move(movement);
        }


    }
}
