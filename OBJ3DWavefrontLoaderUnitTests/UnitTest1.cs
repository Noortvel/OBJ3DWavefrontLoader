using Microsoft.VisualStudio.TestTools.UnitTesting;
using OBJ3DWavefrontLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Resources;

namespace OBJ3DWavefrontLoaderUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoadMesh1Test()
        {
            try
            {
                SimpleMesh simpleMesh;
                using (var memstream = new MemoryStream(Properties.Resources.cube2))
                {
                    using (var reader = new StreamReader(memstream))
                    {
                        simpleMesh = SimpleMesh.LoadFromObj(reader);
                    }
                }
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void VerticesEquals1Test()
        {
            SimpleMesh simpleMesh;
            using (var reader = new StreamReader("G:\\cube2.obj"))
            {
                simpleMesh = SimpleMesh.LoadFromObj(reader);
            }
            var vertices = new List<Vector3>();
            vertices.Add(new Vector3(100.000000f, 100.000000f, -100.000000f));
            vertices.Add(new Vector3(100.000000f, -100.000000f, -100.000000f));
            vertices.Add(new Vector3(100.000000f, 100.000000f, 100.000000f));
            vertices.Add(new Vector3(100.000000f, -100.000000f, 100.000000f));
            vertices.Add(new Vector3(-100.000000f, 100.000000f, -100.000000f));
            vertices.Add(new Vector3(-100.000000f, -100.000000f, -100.000000f));
            vertices.Add(new Vector3(-100.000000f, 100.000000f, 100.000000f));
            vertices.Add(new Vector3(-100.000000f, -100.000000f, 100.000000f));
            Assert.IsTrue(simpleMesh.vertices.SequenceEqual(vertices));
        }
        [TestMethod]
        public void NormalsEquals1Test()
        {
            SimpleMesh simpleMesh;
            using (var memstream = new MemoryStream(Properties.Resources.cube2))
            {
                using (var reader = new StreamReader(memstream))
                {
                    simpleMesh = SimpleMesh.LoadFromObj(reader);
                }
            }
            var normals = new List<Vector3>();
            normals.Add(new Vector3(0, 1, 0));
            normals.Add(new Vector3(0, 0, 1));
            normals.Add(new Vector3(-1, 0, 0));
            normals.Add(new Vector3(0, -1, 0));
            normals.Add(new Vector3(1, 0, 0));
            normals.Add(new Vector3(0, 0, -1));
            Assert.IsTrue(simpleMesh.normals.SequenceEqual(normals));
        }
        [TestMethod]
        public void UVWEquals1Test()
        {
            var uvw = new List<Vector3>();
            uvw.Add(new Vector3(0.625f, 0.5f, 0));
            uvw.Add(new Vector3(0.875f, 0.5f, 0));
            uvw.Add(new Vector3(0.875f, 0.75f, 0));
            uvw.Add(new Vector3(0.625f, 0.75f, 0));
            uvw.Add(new Vector3(0.375f, 0.75f, 0));
            uvw.Add(new Vector3(0.625f, 1f, 0));
            uvw.Add(new Vector3(0.375f, 1f, 0));
            uvw.Add(new Vector3(0.375f, 0, 0));
            uvw.Add(new Vector3(0.625f, 0, 0));
            uvw.Add(new Vector3(0.625f, 0.25f, 0));
            uvw.Add(new Vector3(0.375f, 0.25f, 0));
            uvw.Add(new Vector3(0.125f, 0.5f, 0));
            uvw.Add(new Vector3(0.375f, 0.5f, 0));
            uvw.Add(new Vector3(0.125f, 0.75f, 0));
            SimpleMesh simpleMesh;
            using (var memstream = new MemoryStream(Properties.Resources.cube2))
            {
                using (var reader = new StreamReader(memstream))
                {
                    simpleMesh = SimpleMesh.LoadFromObj(reader);
                }
            }
            Assert.IsTrue(simpleMesh.uvw.SequenceEqual(uvw));
        }
        [TestMethod]
        public void FacesInfoEquals1Test()
        {
            SimpleMesh simpleMesh;
            using (var memstream = new MemoryStream(Properties.Resources.cube2))
            {
                using (var reader = new StreamReader(memstream))
                {
                    simpleMesh = SimpleMesh.LoadFromObj(reader);
                }
            }

            var vertsIndxs = new List<List<int>>();
            var uvsIndxs = new List<List<int>>();
            var normsIndxs = new List<List<int>>();

            for (int i = 0; i < 6; i++)
            {
                vertsIndxs.Add(new List<int>());
                uvsIndxs.Add(new List<int>());
                normsIndxs.Add(new List<int>());
            }
            //0
            vertsIndxs[0].Add(1);
            uvsIndxs[0].Add(1);
            normsIndxs[0].Add(1);

            vertsIndxs[0].Add(5);
            uvsIndxs[0].Add(2);
            normsIndxs[0].Add(1);

            vertsIndxs[0].Add(7);
            uvsIndxs[0].Add(3);
            normsIndxs[0].Add(1);

            vertsIndxs[0].Add(3);
            uvsIndxs[0].Add(4);
            normsIndxs[0].Add(1);
            //1
            vertsIndxs[1].Add(4);
            uvsIndxs[1].Add(5);
            normsIndxs[1].Add(2);

            vertsIndxs[1].Add(3);
            uvsIndxs[1].Add(4);
            normsIndxs[1].Add(2);

            vertsIndxs[1].Add(7);
            uvsIndxs[1].Add(6);
            normsIndxs[1].Add(2);

            vertsIndxs[1].Add(8);
            uvsIndxs[1].Add(7);
            normsIndxs[1].Add(2);
            //2
            vertsIndxs[2].Add(8);
            uvsIndxs[2].Add(8);
            normsIndxs[2].Add(3);

            vertsIndxs[2].Add(7);
            uvsIndxs[2].Add(9);
            normsIndxs[2].Add(3);

            vertsIndxs[2].Add(5);
            uvsIndxs[2].Add(10);
            normsIndxs[2].Add(3);

            vertsIndxs[2].Add(6);
            uvsIndxs[2].Add(11);
            normsIndxs[2].Add(3);
            //3
            vertsIndxs[3].Add(6);
            uvsIndxs[3].Add(12);
            normsIndxs[3].Add(4);

            vertsIndxs[3].Add(2);
            uvsIndxs[3].Add(13);
            normsIndxs[3].Add(4);

            vertsIndxs[3].Add(4);
            uvsIndxs[3].Add(5);
            normsIndxs[3].Add(4);

            vertsIndxs[3].Add(8);
            uvsIndxs[3].Add(14);
            normsIndxs[3].Add(4);
            //4
            vertsIndxs[4].Add(2);
            uvsIndxs[4].Add(13);
            normsIndxs[4].Add(5);

            vertsIndxs[4].Add(1);
            uvsIndxs[4].Add(1);
            normsIndxs[4].Add(5);

            vertsIndxs[4].Add(3);
            uvsIndxs[4].Add(4);
            normsIndxs[4].Add(5);

            vertsIndxs[4].Add(4);
            uvsIndxs[4].Add(5);
            normsIndxs[4].Add(5);
            //5
            vertsIndxs[5].Add(6);
            uvsIndxs[5].Add(11);
            normsIndxs[5].Add(6);

            vertsIndxs[5].Add(5);
            uvsIndxs[5].Add(10);
            normsIndxs[5].Add(6);

            vertsIndxs[5].Add(1);
            uvsIndxs[5].Add(1);
            normsIndxs[5].Add(6);

            vertsIndxs[5].Add(2);
            uvsIndxs[5].Add(13);
            normsIndxs[5].Add(6);

            bool isEqual = true;
            for(int i = 0; i < vertsIndxs.Count; i++)
            {
                bool s1 = simpleMesh.facesVertsIndxs[i].SequenceEqual(vertsIndxs[i]);
                bool s2 = simpleMesh.facesUVwIndxs[i].SequenceEqual(uvsIndxs[i]);
                bool s3 = simpleMesh.facesNormsIndxs[i].SequenceEqual(normsIndxs[i]);
                isEqual = s1 && s2 && s3;
                if (!isEqual)
                {
                    break;
                }
            }
            Assert.IsTrue(isEqual);
        }
    }
}
