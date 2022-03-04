using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    // public class TodoItem
    // {
    //     public ICollection<CasosDom> issues { get; set; }
    // }
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Tracker
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Status
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Priority
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Author
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class AssignedTo
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class CustomField
    {
        public int id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Issue
    {
        public int id { get; set; }
        public Project project { get; set; }
        public Tracker tracker { get; set; }
        public Status status { get; set; }
        public Priority priority { get; set; }
        public Author author { get; set; }
        public AssignedTo assigned_to { get; set; }
        public Category category { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public string start_date { get; set; }
        public object due_date { get; set; }
        public int done_ratio { get; set; }
        public bool is_private { get; set; }
        public object estimated_hours { get; set; }
        public List<CustomField> custom_fields { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }
        public object closed_on { get; set; }
    }

    public class Root
    {
        public List<Issue> issues { get; set; }
        public int total_count { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
    }


}
