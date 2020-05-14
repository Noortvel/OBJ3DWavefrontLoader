using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;

namespace OBJ3DWavefrontLoader
{
    public class SimpleMesh
    {
        public List<Vector3> vertices = new List<Vector3>();
        public List<Vector3> normals = new List<Vector3>();
        public List<Vector3> uvw = new List<Vector3>();
        public List<List<int>> facesVertsIndxs = new List<List<int>>();
        public List<List<int>> facesUVwIndxs = new List<List<int>>();
        public List<List<int>> facesNormsIndxs = new List<List<int>>();
        public static SimpleMesh LoadFromObj(StreamReader reader)
        {
            var obj = new SimpleMesh();
            List<int> vertsIndxs;
            List<int> uvsIndxs;
            List<int> normsIndxs;
            Vector3 vertice;
            Vector3 normal;
            Vector3 uvw;
            for (var str = reader.ReadLine(); str != null; str = reader.ReadLine())
            {
                if (OBJParser.TryParseFace(str, out vertsIndxs, out uvsIndxs, out normsIndxs))
                {
                    obj.facesVertsIndxs.Add(vertsIndxs);
                    obj.facesUVwIndxs.Add(uvsIndxs);
                    obj.facesNormsIndxs.Add(normsIndxs);
                } 
                else if(OBJParser.TryParseVertice(str, out vertice))
                {
                    obj.vertices.Add(vertice);
                } 
                else if(OBJParser.TryParseNormal(str, out normal))
                {
                    obj.normals.Add(normal);
                } 
                else if(OBJParser.TryParseUVw(str, out uvw))
                {
                    obj.uvw.Add(uvw);
                }
            }
            return obj;
        }
    }
}

