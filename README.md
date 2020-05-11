# Wavefront OBJ loader
### Usage
    var stream = File.OpenRead("rabbit.obj");
    var simpleMesh = SimpleMesh.LoadFromObj(stream);
### SimpleMesh structure
    class SimpleMesh
    {
        public List<Vector3> vertices;
        public List<List<int>> facesVerts;
        public List<List<int>> faceseUV;
        public List<List<int>> facesNorms;
    }
