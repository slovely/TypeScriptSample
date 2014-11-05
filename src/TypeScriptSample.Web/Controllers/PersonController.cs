using System;
using System.Collections.Generic;
using System.Web.Http;
using TypeScriptSample.Models;

namespace TypeScriptSample.Web.Controllers
{
    public class PersonController : ApiController
    {
        public IEnumerable<Person> Get()
        {
            return new[]
            {
                new Person
                {
                    DateOfBirth = new DateTime(1980, 01, 01),
                    Name = "Simon",
                    MaritalStatus = MaritalStatus.Married,
                },
                new Person
                {
                    DateOfBirth = new DateTime(1988, 01, 01),
                    Name = "Lucy",
                    MaritalStatus = MaritalStatus.Married,
                },
                new Person
                {
                    DateOfBirth = new DateTime(1981, 01, 01),
                    Name = "Dave",
                    MaritalStatus = MaritalStatus.Single,
                },
                new Person
                {
                    DateOfBirth = new DateTime(1977, 01, 01),
                    Name = "Jane",
                    MaritalStatus = MaritalStatus.Divorced,
                }
            };
        }

        public void Post([FromBody]Person person)
        {
        }
    }
}
