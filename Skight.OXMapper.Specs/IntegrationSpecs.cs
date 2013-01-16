using System;
using System.IO;
using Machine.Specifications;
using Skight.OXMapper.Mapping;

namespace Skight.OXMapper.Specs
{
    public class IntegrationSpecs
    {

        Establish context = () =>
            {
                session= Fluently.Configure()
                        .Path(@"C:\Temp\XMLMapper")
                        .Register<MyClassMap>()
                        .BuildSessionFactory()
                        .GetCurrentSession();
                obj = new MyClass
                    {
                        Guid = Guid.NewGuid(),
                        Name = "WangHao",
                        Value = 12
                    };

            };

        Because of = () =>
            {
                 session.save(obj);
                 session.Dispose();
            };
        private It should_generate_xml =
            () => File.Exists(@"C:\Temp\XMLMapper\MyClass.xml").ShouldBeTrue();

        private It xml_content_should_generated_from_classes_value;
          
        private static Session session;
        private static MyClass obj;

        class MyClassMap:XMLMap<MyClass>
        {
            public MyClassMap()
            {
                Id(x => x.Guid);
                Map(x => x.Name);
            }
        }
        private class MyClass
        {
            public Guid Guid { get; set; }
            public string Name { get; set; }
            public int Value { get; set; }
        }
    }
}