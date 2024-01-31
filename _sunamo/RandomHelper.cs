namespace SunamoCollections._sunamo;

public class RandomHelper
{
    //public static Func<int> RandomInt;
    static Random s_rnd = new Random();
    public static int RandomInt()
    {
        return s_rnd.Next(0, int.MaxValue);
    }
}
