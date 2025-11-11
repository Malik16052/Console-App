namespace a;

public class Helper
{
    public class StudentNotFoundException : Exception
    {
        public override string Message => "Bele bir telebe tapilmadi";
    }

    public class ClassroomNotFoundException : Exception
    {
        public override string Message => "Sinif tapilmadi";
    }

    public class InvalidName : Exception
    {

    }
}
