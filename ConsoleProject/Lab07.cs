using System;
using System.Reflection;
using AnimalLibrary;

namespace Lab07
{
    public class Lab07
    {
        static IEnumerable<Type> GetClasses( string nameSpace )
        {
            var asm = System.Reflection.Assembly.Load(nameSpace);
            return asm.GetTypes()
               .Where( type => type.Namespace == nameSpace );
            //  .Select(type => type.Name);
        }

        public static void Main( string[] args )
        {
            StreamWriter fout = new StreamWriter(@"..\..\..\..\MyLibrary.xml");
            fout.WriteLine( "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" );  // windows-1251
            fout.WriteLine( "<Library>" );
            fout.WriteLine( "<name>ClassLibrary1</name>" );

            foreach (var MyType in GetClasses( "AnimalLibrary" ))
            {
                Console.WriteLine( "typename=" + MyType.Name + ":" );
                Console.WriteLine( "abstract=" + MyType.IsAbstract + ";" );
                Console.WriteLine( "public="   + MyType.IsPublic + ";" );
                Console.WriteLine( "basetype=" + MyType.BaseType.Name + ";" );
                fout.WriteLine( "\t<type>" );
                fout.WriteLine( "\t\t<name>" + MyType.Name + "</name>" );

                if (MyType.IsPublic || MyType.IsAbstract)
                {
                    fout.Write( "\t\t<modifiers>" );
                    if (MyType.IsPublic) fout.Write( "public " );
                    if (MyType.IsAbstract) fout.Write( "abstract" );

                    fout.WriteLine( "</modifiers>" );
                }
                fout.WriteLine( "\t\t<basetype>" + MyType.BaseType.Name + "</basetype>" );

                //  foreach (MemberInfo member in MyType.GetMembers())
                foreach (MemberInfo member in MyType.GetMembers( BindingFlags.DeclaredOnly
                            |BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static ))
                {
                    fout.WriteLine( "\t\t<member>" );
                    fout.WriteLine( "\t\t\t<name>"   + member.Name + "</name>" );
                    fout.WriteLine( "\t<membertype>" + member.MemberType + "</membertype>" );
                    Console.WriteLine( "\tname=" + member.Name );
                    Console.WriteLine( "\tmembertype=" + member.MemberType );

                    if (member.MemberType == MemberTypes.Field)
                    {
                        FieldInfo field = MyType.GetField(member.Name);
                        if (field != null)
                        {
                            Type mytype = field.FieldType;
                            Console.WriteLine( "\t\ttype=" + mytype.Name );
                            fout.WriteLine( "\t\t\t<fieldtype>" + mytype.Name + "</fieldtype>" );
                        }
                    }

                    if (member.MemberType == MemberTypes.Property)
                    {
                        PropertyInfo prop = MyType.GetProperty(member.Name);
                        if (prop != null)
                        {
                            Type mytype = prop.PropertyType;
                            Console.WriteLine( "\t\ttype=" + mytype.Name );
                            fout.WriteLine( "\t\t\t<propertytype>" + mytype.Name + "</propertytype>" );
                        }
                    }

                    fout.WriteLine( "\t\t</member>" );
                }
                Console.WriteLine();
                fout.WriteLine( "\t</type>" );
            }
            fout.WriteLine( "</Library>" );
            fout.Close();
        }
    }
}
