# Wavefront OBJ loader
### Usage
     SimpleMesh simpleMesh;
     using (var reader = new StreamReader("G:\\cube2.obj"))
     {
     	simpleMesh = SimpleMesh.LoadFromObj(reader);
     }
### SimpleMesh structure
    class SimpleMesh
    {
        public List<Vector3> vertices;
        public List<Vector3> normals;
        public List<Vector3> uvw;
        public List<List<int>> facesVertsIndxs;
        public List<List<int>> facesUVwIndxs;
        public List<List<int>> facesNormsIndxs;
    }
