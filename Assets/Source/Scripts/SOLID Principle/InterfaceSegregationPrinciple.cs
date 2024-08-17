using UnityEditor;
using UnityEngine;

namespace SOLID
{
    /// <summary>
    /// Данный принцип гласит, что «вы должны иметь возможность использовать любой производный 
    /// класс вместо родительского класса и вести себя с ним таким же образом без внесения изменений».
    /// Этот принцип прост, но очень важен для понимания.
    /// Класс Child не должен нарушать определение типа родительского класса и его поведение.
    /// </summary>
    public class InterfaceSegregationPrinciple
    {
        public void Case()
        {

        }
    }

    #region BadCase
    //пример нарушения ISP



    #endregion

    #region GoodCase
    //пример реализации ISP 

    #endregion
}