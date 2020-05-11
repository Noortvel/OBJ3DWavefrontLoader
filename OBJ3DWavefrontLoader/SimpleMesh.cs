using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;

namespace OBJ3DWavefrontLoader
{

    class SimpleMesh
    {
        public List<Vector3> vertices = new List<Vector3>();
        public List<List<int>> facesVerts = new List<List<int>>();
        public List<List<int>> faceseUV = new List<List<int>>();
        public List<List<int>> facesNorms = new List<List<int>>();
        public static SimpleMesh LoadFromObj(Stream file)
        {
            var reader = new StreamReader(file);
            var obj = new SimpleMesh();
            for (var str = reader.ReadLine(); str != null; str = reader.ReadLine())
            {
                ObjParseVerteces(obj, str);
                ObjParseFaces(obj, str);
            }
            return obj;
        }
        private static void ObjParseVerteces(SimpleMesh obj, string str)
        {
            if (str[0] == 'v' && str[1] == ' ')
            {
                var tokens = str.Split(' ');
                float x = float.Parse(tokens[1], CultureInfo.InvariantCulture);
                float y = float.Parse(tokens[2], CultureInfo.InvariantCulture);
                float z = float.Parse(tokens[3], CultureInfo.InvariantCulture);
                obj.vertices.Add(new Vector3(x, y, z));
            }
        }
        private static void ObjParseFaces(SimpleMesh obj, string str)
        {
            if (str[0] == 'f')
            {
                var tokens = str.Split(' ');
                int index = obj.facesVerts.Count;
                obj.facesVerts.Add(new List<int>());
                obj.faceseUV.Add(new List<int>());
                obj.facesNorms.Add(new List<int>());
                foreach (var x in tokens)
                {
                    var t2 = x.Split('/');
                    if (t2.Length == 0)
                    {
                        obj.facesVerts[index].Add(int.Parse(x));
                    }
                    else if (t2.Length == 2)
                    {
                        obj.facesVerts[index].Add(int.Parse(t2[0]));
                        obj.faceseUV[index].Add(int.Parse(t2[1]));
                    }
                    else if (t2.Length == 3)
                    {
                        int uv;
                        if (int.TryParse(t2[1], out uv))
                        {
                            obj.faceseUV[index].Add(uv);
                        }
                        obj.facesVerts[index].Add(int.Parse(t2[0]));
                        obj.facesNorms[index].Add(int.Parse(t2[2]));
                    }
                }
            }
        }
    }
}

