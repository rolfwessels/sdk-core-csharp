/*
 * Copyright 2016 MasterCard International.
 *
 * Redistribution and use in source and binary forms, with or without modification, are 
 * permitted provided that the following conditions are met:
 *
 * Redistributions of source code must retain the above copyright notice, this list of 
 * conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright notice, this list of 
 * conditions and the following disclaimer in the documentation and/or other materials 
 * provided with the distribution.
 * Neither the name of the MasterCard International Incorporated nor the names of its 
 * contributors may be used to endorse or promote products derived from this software 
 * without specific prior written permission.
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY 
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES 
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT 
 * SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
 * INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
 * TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; 
 * OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER 
 * IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING 
 * IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF 
 * SUCH DAMAGE.
 *
 */


using System;
using MasterCard.Core;
using MasterCard.Core.Model;
using MasterCard.Core.Security.OAuth;
using Newtonsoft.Json;
using NUnit.Framework;

namespace TestMasterCard
{
    [TestFixture]
    public class ParametersTest
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            var currentPath = Util.GetCurrenyAssemblyPath();
            var authentication =
                new OAuthAuthentication(
                    "gVaoFbo86jmTfOB4NUyGKaAchVEU8ZVPalHQRLTxeaf750b6!414b543630362f426b4f6636415a5973656c33735661383d",
                    currentPath + "\\Test\\prod_key.p12", "alias", "password");
            ApiConfig.setAuthentication(authentication);
            ApiConfig.setSandbox(true);
        }

        #endregion


        [Test]
        public void method_GiventestingFor_Shouldresult()
        {
            // arrange
            Setup();
            // action
            dynamic request = new {CurrentRow = 1, Offset = 25};

            var response = Parameters.QueryDynamic(request);
            // assert
            Assert.That("NO", Is.EqualTo((string)response.ParameterList.ParameterArray.Parameter[1].Ecomm).IgnoreCase);
            Assert.That("Quarterly", Is.EqualTo((string)response.ParameterList.ParameterArray.Parameter[1].Period).IgnoreCase);
            Assert.That("NO", Is.EqualTo((string)response.ParameterList.ParameterArray.Parameter[2].Ecomm).IgnoreCase);
            Assert.That("NO", Is.EqualTo((string)response.ParameterList.ParameterArray.Parameter[0].Ecomm).IgnoreCase);
            Assert.That("U.S. Natural and Organic Grocery Stores", Is.EqualTo((string)response.ParameterList.ParameterArray.Parameter[0].Sector).IgnoreCase);
            Assert.That("U.S. Natural and Organic Grocery Stores", Is.EqualTo((string)response.ParameterList.ParameterArray.Parameter[1].Sector).IgnoreCase);
            Assert.That("U.S. Natural and Organic Grocery Stores", Is.EqualTo((string)response.ParameterList.ParameterArray.Parameter[2].Sector).IgnoreCase);
            Assert.That("Monthly", Is.EqualTo((string)response.ParameterList.ParameterArray.Parameter[0].Period).IgnoreCase);
            Assert.That("Success", Is.EqualTo((string)response.ParameterList.Message).IgnoreCase);
            Assert.That("3", Is.EqualTo((string)response.ParameterList.Count.ToString()).IgnoreCase);
            Assert.That("US", Is.EqualTo((string)response.ParameterList.ParameterArray.Parameter[0].Country).IgnoreCase);
            Assert.That("Weekly", Is.EqualTo((string)response.ParameterList.ParameterArray.Parameter[2].Period).IgnoreCase);
            Assert.That("US", Is.EqualTo((string)response.ParameterList.ParameterArray.Parameter[1].Country).IgnoreCase);
            Assert.That("US", Is.EqualTo((string)response.ParameterList.ParameterArray.Parameter[2].Country).IgnoreCase);
        }



        [Test]
        public void example_parameters_Test()
        {
            var parameters = new RequestMap();

            parameters.Set("CurrentRow", "1");
            parameters.Set("Offset", "25");


            var response = Parameters.Query(parameters);
            Assert.That("NO", Is.EqualTo(response["ParameterList.ParameterArray.Parameter[1].Ecomm"]).IgnoreCase);
            Assert.That("Quarterly", Is.EqualTo(response["ParameterList.ParameterArray.Parameter[1].Period"]).IgnoreCase);
            Assert.That("NO", Is.EqualTo(response["ParameterList.ParameterArray.Parameter[2].Ecomm"]).IgnoreCase);
            Assert.That("NO", Is.EqualTo(response["ParameterList.ParameterArray.Parameter[0].Ecomm"]).IgnoreCase);
            Assert.That("U.S. Natural and Organic Grocery Stores",Is.EqualTo(response["ParameterList.ParameterArray.Parameter[0].Sector"]).IgnoreCase);
            Assert.That("U.S. Natural and Organic Grocery Stores",Is.EqualTo(response["ParameterList.ParameterArray.Parameter[1].Sector"]).IgnoreCase);
            Assert.That("U.S. Natural and Organic Grocery Stores",Is.EqualTo(response["ParameterList.ParameterArray.Parameter[2].Sector"]).IgnoreCase);
            Assert.That("Monthly", Is.EqualTo(response["ParameterList.ParameterArray.Parameter[0].Period"]).IgnoreCase);
            Assert.That("Success", Is.EqualTo(response["ParameterList.Message"]).IgnoreCase);
            Assert.That("3", Is.EqualTo(response["ParameterList.Count"].ToString()).IgnoreCase);
            Assert.That("US", Is.EqualTo(response["ParameterList.ParameterArray.Parameter[0].Country"]).IgnoreCase);
            Assert.That("Weekly", Is.EqualTo(response["ParameterList.ParameterArray.Parameter[2].Period"]).IgnoreCase);
            Assert.That("US", Is.EqualTo(response["ParameterList.ParameterArray.Parameter[1].Country"]).IgnoreCase);
            Assert.That("US", Is.EqualTo(response["ParameterList.ParameterArray.Parameter[2].Country"]).IgnoreCase);
        }
    }
}