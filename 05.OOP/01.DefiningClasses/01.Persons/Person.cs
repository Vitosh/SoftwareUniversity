﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Person
{
    private string name;
    private int age;
    private string email;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cannot be empty or null");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 1 || value > 100)
            {
                throw new ArgumentOutOfRangeException("Age must be in the range [1...100]");
            }
            this.age = value;
        }
    }

    public string Email
    {
        get { return this.email; }
        set
        {
            if (value != null && !value.Contains("@"))
            {
                throw new ArgumentException("Invalid Email!");
            }
            this.email = value;
        }
    }

    public Person(string name, int age, string email)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
    }

    public Person(string name, int age)
        : this(name, age, null)
    {

    }

    public override string ToString()
    {
        return string.Format("Name: {0}, Age: {1}",this.Name,this.Age)+(this.Email == null ? "" : ", Email : " + this.Email);
    }
}