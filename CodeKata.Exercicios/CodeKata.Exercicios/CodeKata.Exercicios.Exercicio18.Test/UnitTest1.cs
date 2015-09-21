using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKata.Exercicios.Exercicio18.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void test_basic()
        {
            var dep = new Dependencies();
            dep.add_direct("A", new string[] { "B", "C" });
            dep.add_direct("B", new string[] { "C", "E" });
            dep.add_direct("C", new string[] { "G" });
            dep.add_direct("D", new string[] { "A", "F" });
            dep.add_direct("E", new string[] { "F" });
            dep.add_direct("F", new string[] { "H" });

            CollectionAssert.AreEqual(new string[] { "B", "C", "E", "F", "G", "H" }, dep.dependencies_for("A"));
            CollectionAssert.AreEqual(new string[] { "C", "E", "F", "G", "H" }, dep.dependencies_for("B"));
            CollectionAssert.AreEqual(new string[] { "G" }, dep.dependencies_for("C"));
            CollectionAssert.AreEqual(new string[] { "A", "B", "C", "E", "F", "G", "H" }, dep.dependencies_for("D"));
            CollectionAssert.AreEqual(new string[] { "F", "H" }, dep.dependencies_for("E"));
            CollectionAssert.AreEqual(new string[] { "H" }, dep.dependencies_for("F"));
        }
    }
}
