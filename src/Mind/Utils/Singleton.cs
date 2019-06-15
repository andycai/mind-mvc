namespace Mind.Utils
{
    /// <summary>
    /// 1. public class NewClass : Singleton<NewClass>
    /// 2. public static NewClass GetInstance() {
    ///         return Singleton<NewClass>.GetInstance();
    ///    }
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : class, new() 
    {
        private static T _instance;
        private static readonly object syslock = new object();

        public static T Instance
        {
			get
			{
				if (_instance == null)
				{
					lock (syslock)
					{
						if (_instance == null)
						{
							_instance = new T();
						}
					}
				}
				return _instance;
			}
        }
    }
}