using System;

namespace Worker.App.FluentValidation.Entities
{
    public sealed class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Gender Gender { get; private set; }
        public int Weight { get; private set; }
        public string Mail { get; private set; }
        public string Phone { get; set; }
        public User(string name, int age, Gender gender, int weight, string mail, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Gender = gender;
            Weight = weight;
            Mail = mail;
            Phone = phone;
        }
    }
}