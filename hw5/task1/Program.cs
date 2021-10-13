using System;

namespace task1
{
    delegate void newPost(Object publisher, EventArgs eventArgs);

    class Publisher
    {
        public event newPost Poster;

        private string name = "poster ?";

        public Publisher(string text)
        {
            this.name = text;
        }

        public void Post()
        {
            Console.WriteLine($"{name} posted new post");
            PostNotification();
        }

        protected virtual void PostNotification()
        {
            Poster?.Invoke(this, EventArgs.Empty);
        }
    }

    class Subscriber
    {
        private string name = "?";

        public Subscriber(string name)
        {
            this.name = name;
        }

        public void OnEvent(Object publisher, System.EventArgs e)
        {
            Console.WriteLine($"{name} get notification about new post");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Publisher("poster 1");
            var s1 = new Subscriber("sub 1");
            var p2 = new Publisher("poster 2");
            var s2 = new Subscriber("sub 2");

            p1.Poster += s1.OnEvent;
            p1.Post();

            p1.Poster += s2.OnEvent;
            p2.Poster += s2.OnEvent;
            p1.Post();
            p2.Post();

            p1.Poster -= s2.OnEvent;
            p1.Post();
        }
    }
}
