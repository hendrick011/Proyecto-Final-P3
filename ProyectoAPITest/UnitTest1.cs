using Model;
using Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProyectoAPITest
{
    public class ClienteTest
    {
       [Fact]
        public void Task_GetPosts_Return_OkResult()
        {
            var cliente = new Cliente();
            var result = Cliente.ToString();
            Assert.IsNotNull(result);
        }
    }
}
