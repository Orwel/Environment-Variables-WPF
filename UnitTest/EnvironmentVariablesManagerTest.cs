using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvironmentVariablesWPF.BLL;
using EnvironmentVariablesWPF.BO;


namespace UnitTest
{
    [TestClass]
    public class EnvironmentVariablesManagerTest
    {
        [TestMethod]
        public void Getter_Test()
        {
            Assert.AreNotEqual(null, EnvironmentVariableManager.ListMachineVariables);
            Assert.AreNotEqual(null, EnvironmentVariableManager.ListUserVariables);
        }

        [TestMethod]
        public void ApplyToRegistry_Test()
        {
            string addName = "addName";
            string addValue = "addValue";
            string editVaue = "editValue";
            if (Environment.GetEnvironmentVariable(addName, EnvironmentVariableTarget.User) != null)
                Environment.SetEnvironmentVariable(addName, null,EnvironmentVariableTarget.User);
            Assert.AreEqual(null, Environment.GetEnvironmentVariable(addName, EnvironmentVariableTarget.User));
            //Test Add new environment variable
            EnvironmentVariableManager.ListUserVariables.Add(addName, addValue);
            EnvironmentVariableManager.ApplyToRegistry();
            Assert.AreEqual(addValue,Environment.GetEnvironmentVariable(addName,EnvironmentVariableTarget.User));
            //Test Edit environment variable
            EnvironmentVariableManager.ListUserVariables[addName].Value = editVaue;
            EnvironmentVariableManager.ApplyToRegistry();
            Assert.AreEqual(editVaue, Environment.GetEnvironmentVariable(addName, EnvironmentVariableTarget.User));
            //Test Delete environment variable
            EnvironmentVariableManager.ListUserVariables[addName].IsDelete = true; ;
            EnvironmentVariableManager.ApplyToRegistry();
            Assert.AreEqual(null, Environment.GetEnvironmentVariable(addName, EnvironmentVariableTarget.User));
        }
    }
}
