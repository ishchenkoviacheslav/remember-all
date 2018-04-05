//using System;

//namespace rememberAll
//{
//    class MyClass
//    {
//        public int MyProperty { get; set; }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            MyClass c = new MyClass() { MyProperty = 3 };
//            c = null;
//            Console.WriteLine(c?.MyProperty);//no exception - nothing writed...
//            Console.WriteLine(c.MyProperty);//nullrefference exception
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using ClassLibrary1;
namespace rememberAll
{
    //class MyClass
    //{
    //}
    //class MyGenericClass<MyClass> 
    //{
    //    public void fu(T obj)
    //    {

    //    }

    //}
    interface IInterface
    {
        void Fu();
    }
    //class MyClass<IInterface>
    class MyClass<T> where T: IInterface
    {
        public Guid MyProperty { get; } = Guid.NewGuid();

    }
    class TypeClass
    {
        private int myData;
        public int MyProperty
        {
            set
            {
                myData = value;
            }
            get
            {
                Console.WriteLine("Enter data: ");
                myData = int.Parse(Console.ReadLine());
                return myData;
            }

        }
    }
    [Flags]
    enum MyEnum
    {
        one = 0x01,
        two = 0x02,
        three = 0x04
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<Type, int> list = new Dictionary<Type, int>();
            //TypeClass obj = new TypeClass();
            //list.Add(typeof(TypeClass), 5);
            //list.Add(typeof(TypeClass), 6);
            //Console.WriteLine($"list {list.GetValueOrDefault(typeof(TypeClass),9)}");
            ////MyGenericClass<int> a = new MyGenericClass<int>();
            ////a.
            ////Class1 obj = new Class1();
            ////obj.breakPoint();
            //MyClass<IInterface> ob2j = new MyClass<IInterface>();
            //Console.WriteLine(ob2j.MyProperty);
            //Console.WriteLine(ob2j.MyProperty);

            //MyEnum EnumVar = MyEnum.one | MyEnum.two;

            //Console.WriteLine(EnumVar);
            //if((EnumVar & MyEnum.one)==MyEnum.one)
            //Console.WriteLine(true);
            //TypeClass obj = new TypeClass();

            //Console.WriteLine(obj.MyProperty);

            //need some app-email account 
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.Timeout = 10000;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("ishchenkoviacheslav@gmail.com", "R@jPr^89&IQ3883");

            MailMessage objeto_mail = new MailMessage();
            objeto_mail.From = new MailAddress("ishchenkoviacheslav@gmail.com");
            objeto_mail.To.Add(new MailAddress("ishchenkoviacheslav@live.com"));
            objeto_mail.Subject = "Subject for letter";
            objeto_mail.Body = "Text test";
            client.Send(objeto_mail);


            //ip adress and some port instead of localhost:1300 
            HttpListener listener = null;
            try
            {
                listener = new HttpListener();
                listener.Prefixes.Add("http://localhost:1300/simpleserver3/");
                //listener.Prefixes.Add("http://localhost:1300/simpleserver2/");
                listener.Start();
                while (true)
                {
                    Console.WriteLine("waiting...");
                    HttpListenerContext context = listener.GetContext();
                    string msg = "registration confirmed";
                    context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(msg);
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    using (Stream stream = context.Response.OutputStream)
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.Write(msg);
                        }
                    }
                    Console.WriteLine("Sent message...");
                    //listener.Prefixes.Remove("http://localhost:1300/simpleserver2/");

                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Status);
            }
        }
    }
}
