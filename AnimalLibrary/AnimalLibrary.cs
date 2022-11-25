using System;

namespace AnimalLibrary
{
    [System.AttributeUsage( System.AttributeTargets.Class )]
    public class CommentAtt : System.Attribute
    {
        public string Comment { get; set; }
        public CommentAtt( string comment )
        {
            Comment = comment;
        }
    }
    public enum eAnimalClassification
    {
        Herbivores,
        Carnivores,
        Omnivores
    }

    public enum eFavouriteFood
    {
        Meat,
        Plants,
        Everything
    }

    [CommentAtt( "Абстрактный класс для объектов, представляющих животных" )]
    public abstract class Animal
    {
        private eAnimalClassification classification;

        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public bool HideFromOtherAnimals { get; set; }

        public abstract void SayHello();
        public abstract eFavouriteFood GetFavouriteFood();
        public eAnimalClassification GetClassification 
        { 
            get => classification; 
        }

        public Animal( string country, string name, string description, bool hideFromOtherAnimals )
        {
            Name = name;
            Country = country;
            Description = description;
            HideFromOtherAnimals = hideFromOtherAnimals;
        }

        public void Deconstruct( string out_name ) 
        { 
            out_name = Name; 
        }
        public void Deconstruct( string out_name, string out_desc ) 
        { 
            out_name = Name; 
            out_desc = Description; 
        }
        public void Deconstruct( string out_name, string out_desc, string out_count ) 
        { 
            out_name  = Name;
            out_count = Country;
            out_desc  = Description; 
        }
        public void Deconstruct( string out_name, string out_desc, string out_count, bool out_hide ) 
        { 
            out_name  = Name;
            out_count = Country;
            out_desc  = Description; 
            out_hide  = HideFromOtherAnimals; 
        }
    }

    [CommentAtt( "Класс описания коровы" )]
    public class Cow : Animal
    {
        public Cow( string country, string name, string description, bool hideFromOtherAnimals ) :
            base( country, name, description, hideFromOtherAnimals )
        {
            Name = name;
            Country = country;
            Description = description;
            HideFromOtherAnimals = hideFromOtherAnimals;
        }

        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Plants;
        }

        public override void SayHello()
        {
            Console.WriteLine( "Мууу\n" );
        }
    }

    [CommentAtt( "Класс описания льва" )]
    public class Lion : Animal
    {
        public Lion( string country, string name, string description, bool hideFromOtherAnimals ) : 
            base( country, name, description, hideFromOtherAnimals )
        {
            Name = name;
            Country = country;
            Description = description;
            HideFromOtherAnimals = hideFromOtherAnimals;
        }

        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Meat;
        }

        public override void SayHello()
        {
            Console.WriteLine( "Рррр\n" );
        }
    }

    [CommentAtt( "Класс описания свиньи" )]
    public class Pig : Animal
    {
        public Pig( string country, string name, string description, bool hideFromOtherAnimals ) : 
            base( country, name, description, hideFromOtherAnimals )
        {
            Name = name;
            Country = country;
            Description = description;
            HideFromOtherAnimals = hideFromOtherAnimals;
        }

        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Everything;
        }

        public override void SayHello()
        {
            Console.WriteLine( "Хрю\n" );
        }
    }
}