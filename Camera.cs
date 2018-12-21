﻿using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatchetEdit {
    class Camera {
        //Camera variables
        public float speed = 0.2f;
        public float pitch = 0f;
        public float yaw = -0.75f;
        public Vector3 position = new Vector3(0, 0, 0);

        public void setPosition(Vector3 position) {
            this.position = position;
        }

        public void setPosition(float x, float y, float z) {
            this.position = new Vector3(x,y,z);
        }

        public void setRotation(float pitch, float yaw) {
            this.pitch = pitch;
            this.yaw = yaw;
        }

        public void moveBehind(LevelObject levelObject, float distanceToObject = 5) {
            float zRotation = 0;

            if (levelObject as Moby != null) { //If object is moby, load its rotation.
                zRotation = ((Moby)levelObject).rotz;
            }

            float pitch = 0;
            float yaw = zRotation - (float)Math.PI / 2;
            setRotation(pitch, yaw);

            float xpos = (float)-Math.Cos(zRotation);
            float ypos = (float)-Math.Sin(zRotation);
            setPosition(new Vector3(
                levelObject.x + xpos * distanceToObject,
                levelObject.y + ypos * distanceToObject,
                levelObject.z + distanceToObject / 2
            ));
        }
    }
}
