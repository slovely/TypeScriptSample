using System;

namespace TypeScriptSample.Models
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
    }

    public enum MaritalStatus
    {
        Single,
        Married,
        Divorced,
        Separated,
        CommonLaw,
    }
}
