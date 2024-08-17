using UnityEngine;

namespace SOLID
{
    public sealed class OpenClosedPrinciple
    {
        /// <summary>
        ///   Главной концепцией данного принципа является то, что класс должен быть открыт для расширений,
        ///   но закрыт от модификаций. Наш модуль должен быть разработан так, чтобы новая функциональность 
        ///   могла быть добавлена только при создании новых требований. «Закрыт для модификации» означает, 
        ///   что мы уже разработали класс, и он прошел модульное тестирование. Мы не должны менять его, пока не найдем ошибки. 
        ///   Как говорится, класс должен быть открытым только для расширений и в C# мы можем использовать для этого наследование.
        /// </summary>
        public void Case()
        {
            Table table = new Table();

            ITableDecoration tableDecoration = new TableClothDecoration();

            tableDecoration.Decoration(table);

            tableDecoration = new TableFlowerDecoration();

            tableDecoration.Decoration(table);
        }
    }

    #region BadCase
    //пример нарушения OCP
    public class TableDecoration
    {
        public string DecorationType { get; private set; }

        public void Decoration(Table table)
        {
            if (DecorationType == "Украсить скатертью")
            {

            }
            else if (DecorationType == "Украсить цветами")
            {

            }
        }
    }

    public class Table { }

    #endregion

    #region GoodCase
    //пример реализации OCP 
    public abstract class ITableDecoration
    {
        public virtual void Decoration(Table table)
        {
            Debug.Log("Base realisation");
        }
    }

    public class TableFlowerDecoration : ITableDecoration
    {
        public override void Decoration(Table table)
        {
            Debug.Log("Flower realisation");
        }
    }

    public class TableClothDecoration : ITableDecoration
    {
        public override void Decoration(Table table)
        {
            Debug.Log("Tablecloth realisation");
        }
    }
    #endregion
}
