using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class SingletonBase<T> where T : SingletonBase<T>
{
    private static T _instance;

    public static T Instance => _instance ??= CreateInstanceOfT();


    private static T CreateInstanceOfT()
    {
        try
        {
            return Activator.CreateInstance(typeof(T), true) as T;

        }
        catch(Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return null;
    }
}

