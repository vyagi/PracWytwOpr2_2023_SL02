namespace SingletonPattern;


//Singleton idealny = thread safe, zwięzły i lazy
public class Singleton
{
    public DateTime CreatedAt { get; }

    private Singleton() => CreatedAt = DateTime.Now;

    private static readonly Lazy<Singleton> Lazy = new (() => new Singleton());

    public static Singleton GetInstance() => Lazy.Value;
}


//Prawie idealny, ale instancja utworzy się od razu, jak tylko w jakiś sposób odwołam się do tego typu
//public class Singleton
//{
//    private static readonly Singleton Instance = new();

//    public DateTime CreatedAt { get; }

//    private Singleton() => CreatedAt = DateTime.Now;

//    public static Singleton GetInstance() => Instance;
//}

//Długie to, prawda?
//public class Singleton
//{
//    private static readonly object PadLock = new();

//    private static volatile Singleton _instance;

//    public DateTime CreatedAt { get; }

//    private Singleton() => CreatedAt = DateTime.Now;

//    public static Singleton GetInstance()
//    {
//        if (_instance != null)
//            return _instance;

//        lock (PadLock)
//        {
//            if (_instance == null)
//                _instance = new Singleton();
//        }

//        return _instance;
//    }
//}


//Słaba efektywność
//public class Singleton
//{
//    private static object PadLock = new ();

//    private static Singleton _instance;

//    public DateTime CreatedAt { get; }

//    private Singleton() => CreatedAt = DateTime.Now;

//    public static Singleton GetInstance()
//    {
//        lock (PadLock)
//        {
//            if (_instance == null) 
//                _instance = new Singleton();
//        }

//        return _instance;
//    }
//}

//Nie używać w środowisku wielowątkowym
//public class Singleton
//{
//    private static Singleton _instance;

//    public DateTime CreatedAt { get; }

//    private Singleton() => CreatedAt = DateTime.Now;

//    public static Singleton GetInstance()
//    {
//        if (_instance == null)
//          _instance = new Singleton();

//        return _instance;
//    }
//}