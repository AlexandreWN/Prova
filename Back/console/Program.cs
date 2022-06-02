using System;
using System.Text;
using Model;

//CREATE
using (var context = new Context())
{
    context.Database.EnsureCreated();
}