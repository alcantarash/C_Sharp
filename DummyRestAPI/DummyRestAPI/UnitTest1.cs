﻿using System;
using System.Collections.Generic;
using System.Net;
using DummyRestAPI.Libraries;
using DummyRestAPI.Models;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Text.RegularExpressions;

namespace DummyRestAPI
{
    [TestFixture]
    public class UnitTest1
    {
        Employee a;
        public string url = "http://dummy.restapiexample.com/api/v1/";
        [Test]
        public void TestMethod1()
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("employees", Method.GET);
            IRestResponse restResponse = client.Execute(request);

            string response = restResponse.Content;

            if (!response.Contains("160705"))
            {
                Assert.Fail("Wrong ID");
            }
        }
        [Test]
        public void GetRequestbyID()
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("employee/{id}", Method.GET);

            request.AddUrlSegment("id", 156702);
            var response = client.Execute(request);

            JObject obs = JObject.Parse(response.Content);
            Assert.That(obs["employee_name"].ToString(), Is.EqualTo("test333"), "Nome do empregado Ok!");
        }
        [Test]
        public void PostRequest()
        {
            for (int i = 0; i <= 500; i++)
            {
                RestClient client = new RestClient(url);
                RestRequest request = new RestRequest("create", Method.POST)
                {
                   RequestFormat = DataFormat.Json
                };
            
                    a = new Employee("AmitLoser"+i, i*100, i);
                    request.AddJsonBody(a);

                    var response = client.Execute(request);
                    int statusCode = (int)response.StatusCode;
         
                    Match match = Regex.Match(response.Content, "\"name\":\"" +a.name+ "\",\"salary\":\"" +a.salary+ "\",\"age\":\"" +a.age+ "\"",
                    RegexOptions.IgnoreCase);

                    if (statusCode == 200)
                    {
                        if (match.Success)
                        {
                            var id_employee = response.DeserializeResponse()["id"];
                            var name_employee = response.DeserializeResponse()["name"];
                            Console.WriteLine("This is ID code generated: " + id_employee);
                    }
                        else
                        {
                            Console.WriteLine(response.Content);
                            Assert.Fail("Error Request! - First Else");
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.Content);
                        Assert.Fail("Error Request! - Second Else\nStatusCode: "+statusCode);
                    }
                }

            //client.CookieContainer = new CookieContainer();

        }
        [Test]
        public void PutRequest()
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("update/{id}", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
            a = new Employee("Who", 1, 1);
            request.AddJsonBody(a);
            request.AddUrlSegment("id", 163008);

            var response = client.Execute(request);

            Match match = Regex.Match(response.Content, "\"name\":\"" + a.name + "\",\"salary\":\"" + a.salary + "\",\"age\":\"" + a.age + "\"",
            RegexOptions.IgnoreCase);

            //Console.WriteLine(response.Content);

            int statusCode = (int)response.StatusCode;
            if (statusCode == 200)
            {
                if (match.Success)
                {
                    var result = response.DeserializeResponse()["name"];
                    Assert.That(result, Is.EqualTo("Raj"), "Assertion Failed!");
                    Console.WriteLine(response.Content);
                }
                else
                {
                    Console.WriteLine(response.Content);
                    Assert.Fail("Error Request! - First Else");
                }
            }
        }
        [Test]
        public void DeleteRequest()
        {
            for (int j = 0; j<20000; j++)
            {
                RestClient client = new RestClient(url);
                RestRequest request = new RestRequest("delete/{id}", Method.DELETE)
                {
                    RequestFormat = DataFormat.Json
                };
                request.AddUrlSegment("id", 6262+j);

                var response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                Match match = Regex.Match(response.Content, "\"success\":{\"text\":\"successfully! deleted Records\"}",
                RegexOptions.IgnoreCase);

                if (statusCode == 200)
                {
                    if (match.Success)
                    {
                        Console.WriteLine(response.Content);
                    }
                }
                else
                {
                    Console.WriteLine("Status Code -> " + statusCode);
                    Console.WriteLine(response.Content);
                }
            }
        }
    }
}
