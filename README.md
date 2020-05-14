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
        public List<Vector3> vertices = new List<Vector3>();
        public List<Vector3> normals = new List<Vector3>();
        public List<Vector3> uvw = new List<Vector3>();
        public List<List<int>> facesVertsIndxs = new List<List<int>>();
        public List<List<int>> facesUVwIndxs = new List<List<int>>();
        public List<List<int>> facesNormsIndxs = new List<List<int>>();
    }
